using Avalonia;
using Avalonia.Controls;

using Avalonia.Controls.Documents;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Remote.Protocol.Input;
using Avalonia.Styling;
using Avalonia.Threading;
using Avalonia.VisualTree;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using NiL.JS.Expressions;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MultiHtmlCraft.AvaroniaControl
{
    public class MultiversalAvaroniaControl : Avalonia.Controls.Control, ICHtmlMultiversalControlInterface, ILogicalScrollable
    {
        // Cache SKFont / SKPaint per typeface+size to avoid repeated allocations and reflection
        private static readonly object _skCacheLock = new object();
        private static readonly System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKFont> _skFontCache = new System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKFont>();
        private static readonly System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKPaint> _skPaintCache = new System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKPaint>();
        CHtmlGraphicContainer? _avaloniaGraphicContainer = null;


        private readonly Canvas _canvas;


        private static SkiaSharp.SKFont GetOrCreateSkFont(SkiaSharp.SKTypeface tf, float size)
        {
            var key = (tf, size);
            lock (_skCacheLock)
            {
                if (_skFontCache.TryGetValue(key, out var existing) && existing != null)
                    return existing;
                var nf = new SkiaSharp.SKFont(tf, size);
                _skFontCache[key] = nf;
                return nf;
            }
        }
        public bool skipWebAuthorityCheck
        {
            get
            {
                if (___multiversalWindow != null)
                {
                    return ___multiversalWindow.skipWebAuthorityCheck;
                }
                return false;
            }
            set
            {
                if (___multiversalWindow != null)
                {
                    ___multiversalWindow.skipWebAuthorityCheck = value;
                }
            }
        }
        // shared list of registered font files (populated on demand)
        private static readonly object _fontFilesLock = new object();
        private static readonly System.Collections.Generic.List<string> ___fontFiles = new System.Collections.Generic.List<string>();

        private static SkiaSharp.SKPaint GetOrCreateSkPaint(SkiaSharp.SKTypeface tf, float size)
        {
            var key = (tf, size);
            lock (_skCacheLock)
            {
                if (_skPaintCache.TryGetValue(key, out var existing) && existing != null)
                    return existing;
                var np = new SkiaSharp.SKPaint { Typeface = tf, TextSize = size, IsAntialias = true };
                _skPaintCache[key] = np;
                return np;
            }
        }
        private MultiHtmlCraft.Core.CHtmlMultiversalWindow? ___multiversalWindow;
        private MultiHtmlCraft.Core.CHtmlDocument? ___document;
        // paint counter used for debug/log throttling
        private int _documentPaintCount = 0;

        public event EventHandler? DocumentLoaded;

        public MultiversalAvaroniaControl()
        {
            Focusable = true;
            // create a multiversal window instance similar to WinForms control
            try
            {
                ___multiversalWindow = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);
                
                if (___multiversalWindow != null)
                {
                    ___multiversalWindow.setMultiversalControl(this);
                    setMultiversalScriptScriptEngineType(IMultiversalScriptScriptEngineType.ClearScriptV8);
                }
            }
            catch
            {
                // keep constructor lightweight - failures will be surfaced when navigate is called
            }
            try
            {                 // ensure shared HttpClient is initialized similar to WinForms control behavior
                if (___multiversalWindow != null && ___multiversalWindow.hasHttpClient == false)
                {
                    var handler = new System.Net.Http.HttpClientHandler
                    {
                        AutomaticDecompression = System.Net.DecompressionMethods.All
                    };
                    var httpClient = new System.Net.Http.HttpClient(handler);
                    commonHTML.setHttpClientDefalutRequestHeaders(httpClient);
                    httpClient.Timeout = TimeSpan.FromMilliseconds(30000);
                    MultiHtmlCraft.Core.CHtmlMultiversalWindow.setHttpClient(httpClient);
                }
            }
            catch (Exception e)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("MultiversalAvaroniaControl constructor HttpClient init exception: {0}", e);
                }

            }
            try
            {
                CHtmlSkiaFontsCache.InitSkiaFontsCache();
            }
            catch (Exception e)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("MultiversalAvaroniaControl constructor exception: {0}", e);
                }
            }
            this._canvas = new Canvas();

            var scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = _canvas
            };

            // スクロール値が変更されたときのイベントハンドラーを登録
            scrollViewer.PropertyChanged += CachedScrollViewer_PropertyChanged;

            VisualChildren.Add(scrollViewer);
            LogicalChildren.Add(scrollViewer);

            // キャッシュに登録
            _cachedScrollViewer = scrollViewer;
            _isScrollViewerCacheValid = true;


            this.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            this.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;


            this.AttachedToVisualTree += MultiversalAvaroniaControl_AttachedToVisualTree;
            this.DetachedFromVisualTree += MultiversalAvaroniaControl_DetachedFromVisualTree;
        }

        // 削除: ScrollViewer_PropertyChanged メソッド（CachedScrollViewer_PropertyChanged に統合）

        event EventHandler? ILogicalScrollable.ScrollInvalidated
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void MultiversalAvaroniaControl_AttachedToVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            Debug.WriteLine($"Attached. Bounds={Bounds}");

            // 内部で作成した ScrollViewer がある場合はそれを使用
            // 外部の ScrollViewer は探さない
            if (_cachedScrollViewer == null || !_isScrollViewerCacheValid)
            {
                FindAndCacheScrollViewer();
            }

            CacheRenderScaling();
            InvalidateVisual();
        }

        private void MultiversalAvaroniaControl_DetachedFromVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            ClearAllCache();
        }

        // Minimal navigate implementation: creates document via core library and raises DocumentLoaded when done.
        public async Task navigate(string URL, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(URL))
                throw new ArgumentException("URL is null or empty", nameof(URL));

            string strUrl = URL.Trim();
            if (!strUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                // not throwing here to be tolerant, but log if available
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl.navigate: invalid url {strUrl}");
                }
                return;
            }

            if (___multiversalWindow == null)
            {
                ___multiversalWindow = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);
                ___multiversalWindow.setMultiversalControl(this);
            }

            // preserve last requested url
            ___multiversalWindow.___URL_Request_Current = URL;

            // ensure shared HttpClient is initialized similar to WinForms control behavior
            if (___multiversalWindow.hasHttpClient == false)
            {
                var handler = new System.Net.Http.HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.All
                };
                var httpClient = new System.Net.Http.HttpClient(handler);
                commonHTML.setHttpClientDefalutRequestHeaders(httpClient);
                httpClient.Timeout = TimeSpan.FromMilliseconds(30000);
                MultiHtmlCraft.Core.CHtmlMultiversalWindow.setHttpClient(httpClient);
            }

            try
            {
                // call into core to create document
                var requestData = (args != null && args.Length > 0 && args[0] is CHtmlRequestData rd) ? rd : null;
                ___document = await MultiHtmlCraft.Core.CHtmlDocument.createDocument(CHtmlDomModeType.HTMLDOM, strUrl, ___multiversalWindow, requestData);
                int iControlCount = 0;

                if (___document != null)
                {
                    if (___document.___ManagedControlPendingElementList != null)
                    {
                        iControlCount = ___document.___ManagedControlPendingElementList.Count;
                        if (iControlCount >= 0)
                        {
                            createAvaloniaControlFromDocument(___document);
                        }
                    }
                    if (___document.body != null)
                    {
                        CHtmlElement _body = ___document.body as CHtmlElement;
                        var bodyBounds = _body.offsetScreenBounds;
                        setScrollViewerSize(bodyBounds);
                    }
                }



                // notify listeners that a document was loaded
                DocumentLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.navigate exception: {0}", ex);
                }
                throw;
            }
        }

        internal void setScrollViewerSize(RectangleFSpec rectSpec)
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl.setScrollViewerSize: {rectSpec.X}, {rectSpec.Y}, {rectSpec.Width}, {rectSpec.Height}");
            }

            // VisualTree が確立されるまで遅延
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (_cachedScrollViewer == null)
                {
                    FindAndCacheScrollViewer();
                }

                if (_cachedScrollViewer != null)
                {
                    // Canvas のサイズを設定
                    if (rectSpec.Width > 0 && rectSpec.Height > 0)
                    {
                        _canvas.Width = rectSpec.Width;
                        _canvas.Height = rectSpec.Height;
                        _extent = new Avalonia.Size(rectSpec.Width, rectSpec.Height);
                    }

                    // スクロールバーの表示設定
                    _cachedScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    _cachedScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

                    // レイアウトを無効化して再計算を強制
                    _cachedScrollViewer.InvalidateMeasure();
                    _cachedScrollViewer.InvalidateArrange();
                    InvalidateMeasure();
                    InvalidateArrange();

                    if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                    {
                        MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: Canvas size set to {rectSpec.Width}x{rectSpec.Height}, ScrollBars - Vertical: {_cachedScrollViewer.VerticalScrollBarVisibility}, Horizontal: {_cachedScrollViewer.HorizontalScrollBarVisibility}");
                    }
                }
            }, Avalonia.Threading.DispatcherPriority.Normal);
        }
        internal void createAvaloniaControlFromDocument(CHtmlDocument ___doc)
        {
            bool isAvaloniaControlCreationSuccess = false;
            int iContolCont = ___doc.___ManagedControlPendingElementList.Count;

            try
            {
                for (int i = 0; i < iContolCont; i++)
                {
                    if (i >= ___doc.___ManagedControlPendingElementList.Count)
                    {
                        break;
                    }
                    int __oid = ___doc.___ManagedControlPendingElementList.Keys[i];
                    CHtmlElement __element = ___doc.___ManagedControlPendingElementList.Values[i];
                    if (__element != null)
                    {
                        if (___doc.___isElementParentTraceableToDocument(__element) == true)
                        {
                            createAvaloniaControlFromDocumentForElement(___doc, __element);
                        }
                        else
                        {
                            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                            {
                                MultiHtmlCraft.Core.commonLog.LogEntry("Control creation is skipped...");
                            }
                        }
                    }
                    ___doc.___ManagedControlPendingElementList.RemoveAt(i);
                    if (i >= 0 && ___doc.___ManagedControlPendingElementList.Count > 0)
                    {
                        i--;
                    }
                    if (___doc.___ManagedControlJobDoneList != null)
                    {
                        ___doc.___ManagedControlJobDoneList[__oid] = __element;
                    }
                }
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry("createAvaloniaControlFromDocument error: {0}", ex.Message);
                }
                isAvaloniaControlCreationSuccess = false;
                return;
            }
            isAvaloniaControlCreationSuccess = true;
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("createAvaloniaControlFromDocument success");
            }
            return;
        }
        public void AddControl(Avalonia.Controls.Control control, double left = 0, double top = 0)
        {
            Canvas.SetLeft(control, left);
            Canvas.SetTop(control, top);
            _canvas.Children.Add(control);

            InvalidateVisual();
            InvalidateMeasure();
            InvalidateArrange();


        }
        internal void createAvaloniaControlFromDocumentForElement(CHtmlDocument ___document, CHtmlElement __element)
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"{this}.createAvaloniaControlFromDocumentForElement {__element}");
            }

            Avalonia.Controls.Control? avaloniaControl = null;

            switch (__element.___elementTagType)
            {
                case CHtmlElementType.BUTTON:
                    {
                        var buttonControl = new Avalonia.Controls.Button();
                        buttonControl.Content = __element.textContent ?? "Button";
                        buttonControl.Width = 200;
                        buttonControl.Height = 100;

                        buttonControl.Background = Avalonia.Media.Brush.Parse("#B0B0B0");
                        buttonControl.Resources["ButtonBackground"] = Avalonia.Media.Brush.Parse("#B0B0B0");



                        buttonControl.Resources["ButtonBackgroundPressed"] = Avalonia.Media.Brush.Parse("#707070");


                        buttonControl.Resources["ButtonBackgroundFocused"] = Avalonia.Media.Brush.Parse("#707070");

                        

                        createEventForAvaloniaControl(buttonControl, __element);


                        avaloniaControl = buttonControl;
                        break;
                    }

                case CHtmlElementType.INPUT:
                    {
                        var typeAttr = __element.getAttribute("type");
                        var inputType = ((typeAttr ?? "text") as string).ToLower().Trim();

                        if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                        {
                            MultiHtmlCraft.Core.commonLog.LogEntry($"INPUT element: type attribute = '{typeAttr}', normalized type = '{inputType}'");
                        }

                        switch (inputType)
                        {
                            case "text":
                                var inputTextBox = new Avalonia.Controls.TextBox();
                                createEventForAvaloniaControl(inputTextBox, __element);


                                avaloniaControl = inputTextBox; 

                                break;
                            case "password":
                                var passwordBox = new Avalonia.Controls.TextBox();
                                passwordBox.PasswordChar = '*';
                                createEventForAvaloniaControl(passwordBox, __element);
                                avaloniaControl = passwordBox;
                                break;


                            case "checkbox":
                                var checkboxPanel  = new Avalonia.Controls.StackPanel();
                                checkboxPanel.Width = 300;
                                checkboxPanel.Height = 100;
                                var chekedBtn = new Avalonia.Controls.CheckBox();
                                createEventForAvaloniaControl(chekedBtn, __element);
                                chekedBtn.Content = __element.innerText;
                                checkboxPanel.Children.Add(chekedBtn);
                                avaloniaControl = checkboxPanel;
                                break;

                            case "radio":
                                var radioBtnPanel = new Avalonia.Controls.StackPanel();
                                radioBtnPanel.Orientation = Avalonia.Layout.Orientation.Horizontal;
                                radioBtnPanel.Spacing = 20;
                                radioBtnPanel.Width =  300;
                                radioBtnPanel.Height = 150;
                                radioBtnPanel.Background = Avalonia.Media.Brush.Parse("#B0B0B0");

                            
                                var radioBtn = new Avalonia.Controls.RadioButton();
                                radioBtn.Width = 300;
                                radioBtn.Height = 150;
                                radioBtn.Content = "RADIO";
                                createEventForAvaloniaControl(radioBtn, __element);
                                radioBtn.Content = __element.innerText;
                                radioBtnPanel.Children.Add(radioBtn);
                                avaloniaControl = radioBtnPanel;
                                break;
                            case "submit":
                                var btnSubmit = new Avalonia.Controls.Button();
                                btnSubmit.Content = "Submit";
                                btnSubmit.Height = 150;
                                avaloniaControl = btnSubmit;
                                break;
                            case "reset":
                                var btnReset = new Avalonia.Controls.Button();
                                btnReset.Content = "Reset";
                                avaloniaControl = btnReset;
                                break;
                            case "file":
                                var btnFile = new Avalonia.Controls.Button();
                                btnFile.Content = "Choose File";
                                avaloniaControl = btnFile;
                                break;
                            case "hidden":
                             
                                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                                {
                                    MultiHtmlCraft.Core.commonLog.LogEntry($"Hidden input field skipped");
                                }
                                return;
                            case "button":
                                var btn = new Avalonia.Controls.Button();
                                btn.Content = "Button";
                                avaloniaControl = btn;
                                break;
                            case "image":
                                var btnImage = new Avalonia.Controls.Button();
                                btnImage.Content = "Choose Image";
                                avaloniaControl = btnImage;
                                break;
                            case "color":
                                var btnColor = new Avalonia.Controls.Button();
                                btnColor.Content = "Choose Color";
                                avaloniaControl = btnColor;
                                break;
                            case "date":
                                var btnDate = new Avalonia.Controls.DatePicker();
                                btnDate.Width = 400;
                                btnDate.Height = 300;
                                btnDate.SelectedDateChanged += (s, e) => OnControlDateTimePickerDateSelectedInternal(btnDate);
                                avaloniaControl = btnDate;
                                break;
                            case "datetime-local":
                                var btnDateTime = new Avalonia.Controls.DatePicker();
                                btnDateTime.Width = 400;
                                btnDateTime.Height = 100; 
                   
                                avaloniaControl = btnDateTime;
                                break;
                            case "email":
                                var emailBox = new Avalonia.Controls.TextBox();
                                emailBox.Watermark = "Enter email";
                                avaloniaControl = emailBox;
                                break;
                            case "month":
                                var btnMonth = new Avalonia.Controls.Button();
                                btnMonth.Content = "Choose Month";
                                avaloniaControl = btnMonth;
                                break;
                            case "number":
                                var numberBox = new Avalonia.Controls.NumericUpDown();
                                avaloniaControl = numberBox;
                                break;
                            case "range":
                                var slider = new Avalonia.Controls.Slider();
                                slider.Minimum = 0;
                                slider.Maximum = 100;
                                avaloniaControl = slider;
                                break;
                            case "search":
                                var searchBox = new Avalonia.Controls.TextBox();
                                searchBox.Watermark = "Search...";
                                avaloniaControl = searchBox;
                                break;
                            case "tel":
                                var telBox = new Avalonia.Controls.TextBox();
                                telBox.Watermark = "Enter phone";
                                avaloniaControl = telBox;
                                break;
                            case "time":
                                var btnTime = new Avalonia.Controls.Button();
                                btnTime.Content = "Choose Time";
                                avaloniaControl = btnTime;
                                break;
                            case "url":
                                var urlBox = new Avalonia.Controls.TextBox();
                                urlBox.Watermark = "Enter URL";
                                avaloniaControl = urlBox;
                                break;
                            case "week":
                                var btnWeek = new Avalonia.Controls.Button();
                                btnWeek.Content = "Choose Week";
                                avaloniaControl = btnWeek;
                                break;
                            default:
                                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                                {
                                    MultiHtmlCraft.Core.commonLog.LogEntry($"Unknown INPUT type: '{inputType}', creating TextBox as fallback");
                                }
                                avaloniaControl = new Avalonia.Controls.TextBox();
                                break;
                        }
                        break;
                    }

                case CHtmlElementType.SELECT:
                    {
                        var comboBox = new Avalonia.Controls.ComboBox();
                        comboBox.Width = 200;
                        comboBox.Height = 30;
                        comboBox.Background = Avalonia.Media.Brush.Parse("#DD5733");
                        avaloniaControl = comboBox;
                        break;
                    }

                case CHtmlElementType.TEXTAREA:
                    {
                        var textArea = new Avalonia.Controls.TextBox();
                        textArea.Width = 200;
                        textArea.Height = 60;
                        textArea.AcceptsReturn = true;
                        avaloniaControl = textArea;
                        break;
                    }

                default:
                    {
                        if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                        {
                            MultiHtmlCraft.Core.commonLog.LogEntry($"{this}.createAvaloniaControlFromDocumentForElement - No control created for element type: {__element.___elementTagType}");
                        }
                        break;
                    }
            }

            if (avaloniaControl != null)
            {
                // デフォルトサイズを設定
                if (avaloniaControl.Width == 0 || double.IsNaN(avaloniaControl.Width))
                {
                    // CheckBox/RadioButtonは小さく、他はデフォルト100
                    if (avaloniaControl is Avalonia.Controls.CheckBox || avaloniaControl is Avalonia.Controls.RadioButton)
                        avaloniaControl.Width = 20;
                    else
                        avaloniaControl.Width = 100;
                }

                if (avaloniaControl.Height == 0 || double.IsNaN(avaloniaControl.Height))
                {
                    // CheckBox/RadioButtonは小さく、他はデフォルト30
                    if (avaloniaControl is Avalonia.Controls.CheckBox || avaloniaControl is Avalonia.Controls.RadioButton)
                        avaloniaControl.Height = 20;
                    else
                        avaloniaControl.Height = 30;
                }

                avaloniaControl.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
                avaloniaControl.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;

                __element.___ManagedControlWeakReference = new WeakReference(avaloniaControl);
                AddControl(avaloniaControl, __element.___offsetScreenBounds.Left, __element.___offsetScreenBounds.Top);

                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"Control created: {avaloniaControl.GetType().Name} Size=({avaloniaControl.Width}x{avaloniaControl.Height}) at ({__element.___offsetScreenBounds.Left}, {__element.___offsetScreenBounds.Top})");
                }
            }
        }

        private void OnControlDateTimePickerDateSelectedInternal(DatePicker btnDate)
        {
            throw new NotImplementedException();
        }

        private void createEventForAvaloniaControl(Avalonia.Controls.Control avaloniaControl, CHtmlElement element)
        {
            string strElementInputAttributeTypeValue = null;
            CHtmlElement ownerFornElemenent = null;
            bool IsAvalonivaOwnerFormElementFound = false;
            if (avaloniaControl != null && element != null)
            {
                avaloniaControl.Tag = element;


                switch(element.___elementTagType)
                {
           
                    case CHtmlElementType.BUTTON:
                        var buttonControl = avaloniaControl as Avalonia.Controls.Button;
                        buttonControl.Click += (s, e) => OnControlClickInternal(e);
                        buttonControl.PointerPressed += (s, e) => OnControlPointerPressedInternal(e);
                        buttonControl.PointerReleased += (s, e) => OnControlPointerReleasedInternal(e);
                        buttonControl.PointerMoved += (s, e) => OnControlPointerMovedInternal(e);

                        CHtmlAttribute elementInputAttributeType = null;
                        if (element.___attributes.TryGetValue("type", out elementInputAttributeType))
                        {
                            strElementInputAttributeTypeValue = elementInputAttributeType.value.ToString();
                        }
                        break;
                    case CHtmlElementType.TEXTAREA:
                        break;

                    case CHtmlElementType.INPUT:
                        var elementInputType = String.Format("{0}", element.getAttribute("type")).ToLower();
                        switch(elementInputType)
                        {
                            case "text":
                                var txtBox = avaloniaControl as Avalonia.Controls.TextBox;
                                txtBox.TextChanged += (s, e) => OnControlTextChangedInternal(e);
                                break;
                            case "password":
                                var txtPasswordBox = avaloniaControl as Avalonia.Controls.TextBox;
                                txtPasswordBox.TextChanged += (s, e) => OnControlTextChangedInternal(e);
                                break;
                            case "checkbox":
                                break;
                            case "radio":
                                break;
                            case "number":
                                break;
                            case "color":
                                break;
                            case "range":
                                break;
                            case "file":
                                break;
                            case "button":
                                break;
                            case "date":
                                var datePicker = avaloniaControl as Avalonia.Controls.DatePicker;
                                datePicker.SelectedDateChanged += (s, e) => OnControlDateTimePickerDateSelectedInternal(datePicker);
                                break;
                                
                        }
                        break;
                }






            }
            return;
        }


        // synchronous helper
        public void NavigateSync(string URL)
        {
            navigate(URL).GetAwaiter().GetResult();
        }

        // Interface implementations - provide simple, non-UI stubs so core can call into this control.
        public void Invalidate()
        {
            // schedule visual invalidation on the UI thread
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore dispatcher exceptions
            }
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.Invalidate called");
            }
        }

        public void Invalidate(RectangleFSpec rectFSpec)
        {
            // For now just invalidate the whole control; rectangle-based invalidation could be mapped
            // to InvalidateVisual with a clip in a more advanced implementation.
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore
            }
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.Invalidate(RectangleFSpec) called: {0}", rectFSpec);
            }
        }

        public void DrawImage(object imagde, RectangleFSpec rectFSpec)
        {
            // Core may provide System.Drawing.Image for WinForms; Avalonia uses its own types.
            // For now, accept the call and log. UI-specific drawing must be implemented in an Avalonia control wrapper.
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.DrawImage called with image type: {0}, rect: {1}", imagde?.GetType().FullName, rectFSpec);
            }

            // trigger a visual update; a real implementation would convert the provided image to an Avalonia Bitmap
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore
            }
        }



        private static readonly Random _rand = new Random();

        protected override Size MeasureOverride(Size availableSize)
        {
            // 無限サイズは有限値に制限
            var constrainedSize = new Size(
                double.IsInfinity(availableSize.Width) ? 800 : availableSize.Width,
                double.IsInfinity(availableSize.Height) ? 600 : availableSize.Height
            );

            // ScrollViewer に利用可能なサイズを渡す
            if (_cachedScrollViewer != null)
            {
                _cachedScrollViewer.Measure(constrainedSize);
                return constrainedSize;
            }
            return constrainedSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // ScrollViewer を最終サイズに配置
            if (_cachedScrollViewer != null)
            {
                _cachedScrollViewer.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            }
            return finalSize;
        }

        public override void Render(DrawingContext context)
        {
            var grCon = this.CreateGraphicContainer(context);
            if (grCon == null) return;
            grCon.IsUIThreadPaint = true;
            grCon.AvaloniaDrawingContext = context;
            grCon.PaintRectangle = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
            if (___document != null && ___document.documentElement is CHtmlElement documentRootElement)
            {
                if (_documentPaintCount >= int.MaxValue)
                    _documentPaintCount = 0;
                _documentPaintCount++;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 15 && _documentPaintCount == 1)
                {
                    commonUtils.LogElementDOMTree(documentRootElement, "", commonUtils.CJHtmlDOMElementLogModeType.ElementWidthAndHeight);
                }

                ___document.drawRootElementRecursively(documentRootElement, ref grCon);

            }
            base.Render(context);
#if !WINDOWS

            if (___document != null)
            {
                ___document.ApplyPendingAvaloniaRelocations();
            }
#endif
        }


        private CHtmlGraphicContainer? CreateGraphicContainer(DrawingContext context)
        {
            try
            {
                if (_avaloniaGraphicContainer == null)
                    _avaloniaGraphicContainer = new CHtmlGraphicContainer(GraphicAPIType.Avalonia);

                _avaloniaGraphicContainer.AvaloniaDrawingContext = context;
                _avaloniaGraphicContainer.PaintRectangle = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
                _avaloniaGraphicContainer.ControlBounds = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
                return _avaloniaGraphicContainer;
            }
            catch
            {
                return null;
            }
        }

        public System.Drawing.Rectangle GetPaintRectScrollbar()
        {
            double width = this.Bounds.Width;
            double height = this.Bounds.Height;
            double scale = 1.0;
            double offsetX = 0.0;
            double offsetY = 0.0;

            try
            {
                // キャッシュされた RenderScaling を使用
                if (_isRenderScalingCacheValid)
                {
                    scale = _cachedRenderScaling;
                }
                else
                {
                    CacheRenderScaling();
                    scale = _cachedRenderScaling;
                }

                // キャッシュされた ScrollViewer から Offset を取得
                if (_isScrollViewerCacheValid && _cachedScrollViewer != null)
                {
                    offsetX = _cachedScrollOffset.X;
                    offsetY = _cachedScrollOffset.Y;
                }
                else
                {
                    // キャッシュが無効な場合は再探索
                    FindAndCacheScrollViewer();
                    if (_isScrollViewerCacheValid)
                    {
                        offsetX = _cachedScrollOffset.X;
                        offsetY = _cachedScrollOffset.Y;
                    }
                }
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl.GetPaintRectScrollbar error: {ex.Message}");
                }
                // エラーの場合は既定値を使用
            }

            int pixelWidth = Math.Max(0, (int)System.Math.Ceiling(width * scale));
            int pixelHeight = Math.Max(0, (int)System.Math.Ceiling(height * scale));

            int pixelOffsetX = (int)System.Math.Floor(offsetX * scale);
            int pixelOffsetY = (int)System.Math.Floor(offsetY * scale);

            return new System.Drawing.Rectangle(pixelOffsetX, pixelOffsetY, pixelWidth, pixelHeight);
        }
        // Expose the loaded document for consumers
        public MultiHtmlCraft.Core.CHtmlDocument? Document => ___document;

        // Allow setting/getting script engine type as WinForms control provides
        public void setMultiversalScriptScriptEngineType(IMultiversalScriptScriptEngineType value)
        {
            if (___multiversalWindow != null)
            {
                ___multiversalWindow.___muultiversalScriptScriptEngineType = value;
            }
        }

        public object? getMultiversalScriptScriptEngineType()
        {
            return ___multiversalWindow != null ? ___multiversalWindow.___muultiversalScriptScriptEngineType : null;
        }

        // Focus notifications for UI integration - these will write to the common log when focus changes.
        public void NotifyGotFocus()
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl: Got focus");
            }
        }

        public void NotifyLostFocus()
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl: Lost focus");
            }
        }

        // ScrollViewer キャッシュ用のフィールド
        private ScrollViewer? _cachedScrollViewer = null;
        private Vector _cachedScrollOffset = new Vector(0, 0);
        private double _cachedRenderScaling = 1.0;
        private bool _isScrollViewerCacheValid = false;
        private bool _isRenderScalingCacheValid = false;

        // Minimal ILogicalScrollable / IScrollable implementation so the control can participate
        // in logical scrolling. These provide safe defaults; behavior can be extended later.
        private bool _canHorizontallyScroll = false;
        private bool _canVerticallyScroll = false;
        private bool _isLogicalScrollEnabled = false;
        private Avalonia.Size _scrollSize = new Avalonia.Size(16, 16);
        private Avalonia.Size _pageScrollSize = new Avalonia.Size(100, 100);
        private Avalonia.Size _extent = new Avalonia.Size(0, 0);
        private Avalonia.Vector _offset = new Avalonia.Vector(0, 0);
        private Avalonia.Size _viewport = new Avalonia.Size(0, 0);

        // ILogicalScrollable
        public bool CanHorizontallyScroll
        {
            get => _canHorizontallyScroll;
            set => _canHorizontallyScroll = value;
        }
        public bool CanVerticallyScroll
        {
            get => _canVerticallyScroll;
            set => _canVerticallyScroll = value;
        }
        public bool IsLogicalScrollEnabled => _isLogicalScrollEnabled;
        public Avalonia.Size ScrollSize => _scrollSize;
        public Avalonia.Size PageScrollSize => _pageScrollSize;

        public event EventHandler? ScrollInvalidated;

        public void RaiseScrollInvalidated(EventArgs e)
        {
            ScrollInvalidated?.Invoke(this, e);
        }

        public Avalonia.Controls.Control? GetControlInDirection(NavigationDirection direction, Avalonia.Controls.Control from)
        {
            // Default: no logical navigation support
            return null;
        }

        public bool BringIntoView(Avalonia.Controls.Control control, Avalonia.Rect rect)
        {
            // No special bring-into-view handling; return false to indicate not handled.
            return false;
        }

        // IScrollable
        public Avalonia.Size Extent => _extent;
        public Avalonia.Vector Offset
        {
            get => _offset;
            set => _offset = value;
        }
        public Avalonia.Size Viewport => _viewport;

        bool ILogicalScrollable.CanHorizontallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool ILogicalScrollable.CanVerticallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool ILogicalScrollable.IsLogicalScrollEnabled => throw new NotImplementedException();

        Size ILogicalScrollable.ScrollSize => throw new NotImplementedException();

        Size ILogicalScrollable.PageScrollSize => throw new NotImplementedException();

        Size IScrollable.Extent => throw new NotImplementedException();

        Vector IScrollable.Offset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        Size IScrollable.Viewport => throw new NotImplementedException();

        // キャッシュ関連メソッド
        // RenderScaling をキャッシュするメソッド（リフレクションなし）
        private void CacheRenderScaling()
        {
            try
            {
                var visualRoot = this.VisualRoot;
                if (visualRoot is TopLevel topLevel)
                {
                    _cachedRenderScaling = topLevel.RenderScaling;
                    _isRenderScalingCacheValid = true;
                }
                else if (visualRoot is Window window)
                {
                    _cachedRenderScaling = window.RenderScaling;
                    _isRenderScalingCacheValid = true;
                }
                else
                {
                    // フォールバック：デフォルト値を使用
                    _cachedRenderScaling = 1.0;
                    _isRenderScalingCacheValid = true;
                }
            }
            catch
            {
                _cachedRenderScaling = 1.0;
                _isRenderScalingCacheValid = true;
            }
        }

        // ScrollViewer を探してキャッシュするメソッド
        private void FindAndCacheScrollViewer()
        {
            try
            {
                Visual? parent = this.GetVisualParent();
                while (parent != null)
                {
                    if (parent is ScrollViewer sv)
                    {
                        // 前のScrollViewerからイベントハンドラを削除
                        if (_cachedScrollViewer != null)
                        {
                            _cachedScrollViewer.PropertyChanged -= CachedScrollViewer_PropertyChanged;
                        }

                        _cachedScrollViewer = sv;
                        _cachedScrollOffset = sv.Offset;
                        _isScrollViewerCacheValid = true;

                        // Offsetの変更を監視
                        _cachedScrollViewer.PropertyChanged += CachedScrollViewer_PropertyChanged;

                        if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                        {
                            MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: ScrollViewer cached with offset {_cachedScrollOffset}");
                        }
                        return;
                    }
                    parent = parent.GetVisualParent();
                }

                // ScrollViewer が見つからなかった場合
                ClearScrollViewerCache();
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: Error caching ScrollViewer: {ex.Message}");
                }
                ClearScrollViewerCache();
            }
        }


        private void CachedScrollViewer_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if ((e.Property.Name == nameof(ScrollViewer.Offset) || e.Property.Name == "Offset") && sender is ScrollViewer sv)
            {
                _cachedScrollOffset = sv.Offset;

                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"ScrollViewer Offset changed: X={sv.Offset.X}, Y={sv.Offset.Y}");
                }

                InvalidateVisual();
            }
        }


        private void ClearScrollViewerCache()
        {
            if (_cachedScrollViewer != null)
            {
                _cachedScrollViewer.PropertyChanged -= CachedScrollViewer_PropertyChanged;
            }
            _cachedScrollViewer = null;
            _cachedScrollOffset = new Vector(0, 0);
            _isScrollViewerCacheValid = false;
        }

        // すべてのキャッシュをクリアするメソッド
        private void ClearAllCache()
        {
            ClearScrollViewerCache();
            _cachedRenderScaling = 1.0;
            _isRenderScalingCacheValid = false;
        }


        public (double HOffset, double VOffset) GetScrollOffsets()
        {
            if (_isScrollViewerCacheValid)
            {
                return (_cachedScrollOffset.X, _cachedScrollOffset.Y);
            }

            FindAndCacheScrollViewer();
            return (_cachedScrollOffset.X, _cachedScrollOffset.Y);
        }

        public double GetRenderScaling()
        {
            if (_isRenderScalingCacheValid)
            {
                return _cachedRenderScaling;
            }

            CacheRenderScaling();
            return _cachedRenderScaling;
        }


        public void InvalidateScrollViewerCache()
        {
            _isScrollViewerCacheValid = false;
            FindAndCacheScrollViewer();
        }

        public void InvalidateRenderScalingCache()
        {
            _isRenderScalingCacheValid = false;
            CacheRenderScaling();
        }
        protected override void OnKeyDown(Avalonia.Input.KeyEventArgs e)
        {

            bool isShift = e.KeyModifiers.HasFlag(KeyModifiers.Shift);


            bool isCtrl = e.KeyModifiers.HasFlag(KeyModifiers.Control);


            bool isAlt = e.KeyModifiers.HasFlag(KeyModifiers.Alt);


            bool isMeta = e.KeyModifiers.HasFlag(KeyModifiers.Meta);
            base.OnKeyDown(e);
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: KeyDown - {e.Key}");
            }
            if (this.___multiversalWindow != null)
            {
                var keyboardEventArgsSpec = new CHtmlMultiversalKeyboardEventArgsSpec()
                {
                    Key = ToJsCode(e.Key),
                    code = ToJsCode(e.Key),
                    KeyCode = ToJavaScriptKeyCode(e.Key),

                    AltKey = isAlt,
                    CtrlKey = isCtrl,
                    ShiftKey = isShift,
                    MetaKey = isMeta,
                };
                ___fireWindoworDocumentEvent("keydown", null, keyboardEventArgsSpec);
            }
        }
        protected override void OnKeyUp(Avalonia.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            bool isShift = e.KeyModifiers.HasFlag(Avalonia.Input.KeyModifiers.Shift);


            bool isCtrl = e.KeyModifiers.HasFlag(KeyModifiers.Control);


            bool isAlt = e.KeyModifiers.HasFlag(KeyModifiers.Alt);


            bool isMeta = e.KeyModifiers.HasFlag(KeyModifiers.Meta);
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: KeyUp - {e.Key}");
            }
            if (this.___multiversalWindow != null)
            {
                var keyboardEventArgsSpec = new CHtmlMultiversalKeyboardEventArgsSpec()
                {
                    Key = ToJsCode(e.Key),
                    code = ToJsCode(e.Key),
                    KeyCode = ToJavaScriptKeyCode(e.Key),
                    AltKey = isAlt,
                    CtrlKey = isCtrl,
                    ShiftKey = isShift,
                    MetaKey = isMeta,




                };


                ___fireWindoworDocumentEvent("keyup", null, keyboardEventArgsSpec);
            }


        }


        private void ___fireWindoworDocumentEvent(string eventName, CHtmlMultiversalMouseEventArgsSpec? mouseArgSpec)
        {
            ___fireWindoworDocumentEvent(eventName, mouseArgSpec, null);
        }
        private void ___fireWindoworDocumentEvent(string eventName, CHtmlMultiversalMouseEventArgsSpec? mouseArgSpec, CHtmlMultiversalKeyboardEventArgsSpec? keyArgSpec)
        {
            string logPrefix = "___fireWindoworDocumentEvent";
            if (mouseArgSpec != null)
            {
                logPrefix = ($"{logPrefix} called with eventName: {eventName}, x: {mouseArgSpec.X}, y: {mouseArgSpec.Y}, button: {mouseArgSpec.Button}, clicks: {mouseArgSpec.Clicks} delta {mouseArgSpec.DeltaY}");
                this.___multiversalWindow?.___updateMousePosition(mouseArgSpec);
            }
            if (keyArgSpec != null)
            {

                logPrefix = ($"{logPrefix} called with eventName: {eventName}, keyArgSpec.Keys :{keyArgSpec.Key} keyArgs.Shift :{keyArgSpec.ShiftKey} keyCode : {keyArgSpec.KeyCode}");
                this.___multiversalWindow?.___updateKeyboardState(keyArgSpec.Key, keyArgSpec.ShiftKey, keyArgSpec.CtrlKey, keyArgSpec.AltKey, keyArgSpec.MetaKey);
            }
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"{logPrefix}");
                }
                switch (eventName)
                {
                    case "mousemove":
                    case "mousedown":
                    case "mouseleave":
                    case "mouseup":
                    case "click":
                    case "dblclick":
                    case "mousewheel":
                    case "wheel":
                    case "contextmenu":
                    case "mousehover":
                    case "mouseover":
                    case "mouseout":
                    case "mouseenter":

                        ___executeWindowDocumentEventFunction(eventName, mouseArgSpec);
                        this.___multiversalWindow?.___event.___resetToDefaults();
                        return;
                        break;
                    case "keydown":
                    case "keypress":
                    case "keyup":

                        var keyEvent = keyArgSpec;
                        ___executeWindowDocumentEventFunction(eventName, keyArgSpec);
                        this.___multiversalWindow?.___event.___resetToDefaults();
                        return;
                        break;
                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry($"___fireWindoworDocumentEvent Not Implemented {logPrefix}, {ex}");
                }
            }
            return;
        }

        private void ___executeWindowDocumentEventFunction(string eventType, object eventObj)
        {

            var window = this.___multiversalWindow;
            var doc = window?.___document;
            if (doc == null || doc.___IsHtmlParseCompleted == false)
                return;
            bool isWindowFuncExist = false;
            bool isDocumentFuncExist = false;
            object? winFunc = null;
            object? docFunc = null;
            switch (eventType)
            {
                case "dblclick":
                    winFunc = doc.ondblclick;
                    break;
                case "keydown":

                    winFunc = doc.___WindowKeyDownFunctionWeakReference != null ? doc.___WindowKeyDownFunctionWeakReference.Target : null;
                    if (winFunc == null)
                    {
                        winFunc = doc.___WindowKeyDownFunctionStrongRef;
                    }
                    break;
                case "keypress":
                    winFunc = doc.___WindowKeyDownFunctionWeakReference != null ? doc.___WindowKeyDownFunctionWeakReference.Target : null;
                    break;
                case "keyup":
                    winFunc = doc.___WindowKeyUpFunctionWeakReference != null ? doc.___WindowKeyUpFunctionWeakReference.Target : null;
                    if (winFunc == null)
                    {
                        winFunc = doc.___WindowKeyUpFunctionStrongRef;
                    }
                    break;

                case "click":

                    winFunc = doc.onclick;

                    break;
                case "mouseleave":
                    winFunc = doc.onmousedown;
                    break;


                case "mousemove":


                    winFunc = doc.onmousemove;
                    if (winFunc != null)
                    {
                        isWindowFuncExist = true;
                        goto WindowOrDocumentFunctionFound;
                        break;
                    }
                    docFunc = doc.___WindowMouseMoveFunctionWeakReference != null ? doc.___WindowMouseMoveFunctionWeakReference.Target : null;
                    if (docFunc != null)
                    {
                        isDocumentFuncExist = true;
                        goto WindowOrDocumentFunctionFound;
                        break;
                    }
                    break;



                case "mousedown":

                    docFunc = doc.___WindowMouseDownFunctionWeakReference != null ? doc.___WindowMouseDownFunctionWeakReference.Target : null;
                    break;
                case "mousewheel":

                    docFunc = doc.___WindowMouseWheelFunctionWeakReference != null ? doc.___WindowMouseWheelFunctionWeakReference.Target : null;
                    break;
                case "mouseup":
                    winFunc = doc.onmouseup;
                    docFunc = doc.___WindowMouseUpFunctionWeakReference != null ? doc.___WindowMouseUpFunctionWeakReference.Target : null;
                    break;


                default:
                    break;
            }


        WindowOrDocumentFunctionFound:

            try
            {
                if (winFunc != null)
                {
                    window.___executeEventFunction(eventType, null, winFunc, new object[] { eventObj }, 1);
                }
                else if (docFunc != null)
                {
                    window.___executeEventFunction(eventType, null, docFunc, new object[] { eventObj }, 1);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___executeWindowDocumentEventFunction Exception: {0}", ex);
                }
            }
            return;
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var pos = e.GetPosition(this);
            mouseArg.X = (int)Math.Round(pos.X);
            mouseArg.Y = (int)Math.Round(pos.Y);


            if (this.___multiversalWindow != null && this.___multiversalWindow.document != null &&
              this.___multiversalWindow.___document.___WindowMouseMoveFunctionWeakReference != null)
            {
                ___fireWindoworDocumentEvent("mousemove", mouseArg);

            }
        }
        protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
        {
            base.OnPointerCaptureLost(e);
        }
        protected override void OnPointerEntered(PointerEventArgs e)
        {
            base.OnPointerEntered(e);
        }
        protected override void OnPointerExited(PointerEventArgs e)
        {
            base.OnPointerExited(e);
            CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var pos = e.GetPosition(this);
            mouseArg.X = (int)pos.X;
            mouseArg.Y = (int)pos.Y;

            ___fireWindoworDocumentEvent("mouseleave", mouseArg);
        }
        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
        }
        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            base.OnPointerWheelChanged(e);
        }
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
        }
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            this.Focus();
            CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var mouseInfo = e.GetCurrentPoint(this);
            mouseArg.X = (int)mouseInfo.Position.X;
            mouseArg.Y = (int)mouseInfo.Position.Y;
            if (mouseInfo.Properties.IsLeftButtonPressed)
            {
                mouseArg.Button = 0;
            }
            else if (mouseInfo.Properties.IsMiddleButtonPressed)
            {
                mouseArg.Button = 1;
            }
            else if (mouseInfo.Properties.IsRightButtonPressed)
            {
                mouseArg.Button = 2;
            }

            ___fireWindoworDocumentEvent("mousedown", mouseArg);

        }



        public static int ToJavaScriptKeyCode(Avalonia.Input.Key key)
        {
            // 計算用に数値を保持
            int kv = (int)key;

            return key switch
            {
                Avalonia.Input.Key.LeftShift => 16,
                Avalonia.Input.Key.RightShift => 16,
                Avalonia.Input.Key.LeftCtrl => 17,
                Avalonia.Input.Key.RightCtrl => 17,
                Avalonia.Input.Key.LeftAlt => 18,
                Avalonia.Input.Key.RightAlt => 18,

                // 特殊キー
                Avalonia.Input.Key.Back => 8,
                Avalonia.Input.Key.Tab => 9,
                Avalonia.Input.Key.Enter => 13,
                Avalonia.Input.Key.Pause => 19,
                Avalonia.Input.Key.CapsLock => 20,
                Avalonia.Input.Key.Escape => 27,
                Avalonia.Input.Key.Space => 32,
                Avalonia.Input.Key.PageUp => 33,
                Avalonia.Input.Key.PageDown => 34,
                Avalonia.Input.Key.End => 35,
                Avalonia.Input.Key.Home => 36,
                Avalonia.Input.Key.Left => 37,
                Avalonia.Input.Key.Up => 38,
                Avalonia.Input.Key.Right => 39,
                Avalonia.Input.Key.Down => 40,
                Avalonia.Input.Key.PrintScreen => 44,
                Avalonia.Input.Key.Insert => 45,
                Avalonia.Input.Key.Delete => 46,

                // 数字 (0-9) : keyCode 48-57
                _ when key >= Avalonia.Input.Key.D0 && key <= Avalonia.Input.Key.D9
                    => kv - (int)Avalonia.Input.Key.D0 + 48,

                // アルファベット (A-Z) : keyCode 65-90
                _ when key >= Avalonia.Input.Key.A && key <= Avalonia.Input.Key.Z
                    => kv - (int)Avalonia.Input.Key.A + 65,

                // テンキー (0-9) : keyCode 96-105
                _ when key >= Avalonia.Input.Key.NumPad0 && key <= Avalonia.Input.Key.NumPad9
                    => kv - (int)Avalonia.Input.Key.NumPad0 + 96,

                // F1-F12 : keyCode 112-123
                _ when key >= Avalonia.Input.Key.F1 && key <= Avalonia.Input.Key.F12
                    => kv - (int)Avalonia.Input.Key.F1 + 112,

                // 記号類
                Avalonia.Input.Key.OemSemicolon => 186,
                Avalonia.Input.Key.OemPlus => 187,
                Avalonia.Input.Key.OemComma => 188,
                Avalonia.Input.Key.OemMinus => 189,
                Avalonia.Input.Key.OemPeriod => 190,
                Avalonia.Input.Key.OemQuestion => 191,
                Avalonia.Input.Key.OemTilde => 192,
                Avalonia.Input.Key.OemOpenBrackets => 219,
                Avalonia.Input.Key.OemPipe => 220,
                Avalonia.Input.Key.OemCloseBrackets => 221,
                Avalonia.Input.Key.OemQuotes => 222,

                _ => 0
            };
        }
        public static string ToJsCode(Avalonia.Input.Key key)
        {
            return key switch
            {
                // 矢印キー
                Avalonia.Input.Key.Left => "ArrowLeft",
                Avalonia.Input.Key.Right => "ArrowRight",
                Avalonia.Input.Key.Up => "ArrowUp",
                Avalonia.Input.Key.Down => "ArrowDown",

                // 特殊キー
                Avalonia.Input.Key.Back => "Backspace",
                Avalonia.Input.Key.Escape => "Escape",
                Avalonia.Input.Key.Tab => "Tab",
                Avalonia.Input.Key.Enter => "Enter",
                Avalonia.Input.Key.Space => " ",
                Avalonia.Input.Key.Delete => "Delete",

                // 修飾キー
                Avalonia.Input.Key.LWin => "MetaLeft",
                Avalonia.Input.Key.RWin => "MetaRight",
                Avalonia.Input.Key.LeftShift => "ShiftLeft",
                Avalonia.Input.Key.RightShift => "ShiftRight",
                Avalonia.Input.Key.LeftCtrl => "ControlLeft",
                Avalonia.Input.Key.RightCtrl => "ControlRight",
                Avalonia.Input.Key.LeftAlt => "AltLeft",
                Avalonia.Input.Key.RightAlt => "AltRight",


                _ when key >= Avalonia.Input.Key.D0 && key <= Avalonia.Input.Key.D9
                    => $"Digit{key.ToString().Substring(1)}",


                _ when key >= Avalonia.Input.Key.A && key <= Avalonia.Input.Key.Z
                    => $"Key{key}",


                _ when key >= Avalonia.Input.Key.NumPad0 && key <= Avalonia.Input.Key.NumPad9
                    => key.ToString().Replace("NumPad", "Numpad"),


                _ => key.ToString()
            };
        }

        bool ILogicalScrollable.BringIntoView(Avalonia.Controls.Control target, Rect targetRect)
        {
            throw new NotImplementedException();
        }

        Avalonia.Controls.Control? ILogicalScrollable.GetControlInDirection(NavigationDirection direction, Avalonia.Controls.Control? from)
        {
            throw new NotImplementedException();
        }

        void ILogicalScrollable.RaiseScrollInvalidated(EventArgs e)
        {
            throw new NotImplementedException();



        }
        #region  AvaloniaControl Events
        internal void OnControlPointerPressedInternal(PointerPressedEventArgs e)
        {
            OnPointerPressed(e);
        }
        internal void OnControlPointerReleasedInternal(PointerReleasedEventArgs e)
        {
            OnPointerReleased(e);
        }
        internal void OnControlTextChangedInternal(TextChangedEventArgs e)
        {
            var source = e.Source;
            if (source != null)
            {
                var control = source as Avalonia.Controls.TextBox;
                var element = control.Tag as MultiHtmlCraft.Core.CHtmlElement;
                var textContent = control.Text ?? string.Empty;
                if (String.IsNullOrEmpty(textContent) == false)
                {
                    element.setAttribute("value", textContent);

                };
            }
        }
        internal void OnControlDateTimePickerDateSelectedInternal(DatePicker datePicker, DateTimeOffset? selectedDate)
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlDateTimePickerDateSelectedInternal - Selected Date: {selectedDate}");
            }
            if (selectedDate.HasValue)
            {
                // Handle the selected date as needed
                // For example, you might want to update a bound property or trigger an event
            }
        }
        internal void OnControlPointerMovedInternal(PointerEventArgs e)
        {
            OnPointerMoved(e);
        }
        internal void OnControlPointerWheelChangedInternal(PointerWheelEventArgs e)
        {
            OnPointerWheelChanged(e);
        }
        internal void OnControlPointerEnteredInternal(PointerEventArgs e)
        {
            OnPointerEntered(e);
        }   
        internal void OnControlDateTimePickerDateSelectedInternal(DateTimeOffset? selectedDate)
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlDateTimePickerDateSelectedInternal - Selected Date: {selectedDate}");
            }
            if (selectedDate.HasValue)
            {
                // Handle the selected date as needed
                // For example, you might want to update a bound property or trigger an event
            }
        }
        internal  async Task OnControlClickInternal(Avalonia.Interactivity.RoutedEventArgs e)
        {
            var source = e.Source; 
            if (source != null)
            {
                var control = source as Avalonia.Controls.Control;
                var element = control.Tag as MultiHtmlCraft.Core.CHtmlElement;
                if(element != null)
                {
                    if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                    {
                        MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlClickInternal - Element: {element.toLogString()}, ID: {element.id}");
                    }
                    var ownerForm = commonHTML.GetParentElementFromElement(element, CHtmlElementType.FORM, 3);
                    if(ownerForm != null)
                    {
                        if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                        {
                            MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlClickInternal - Found parent form: {ownerForm.toLogString()}, ID: {ownerForm.id}");
                        }
                        var elementType = String.Format("{0}", element.getAttribute("type"));

                        switch (elementType.ToLower())
                        {

                            case "reset":
                                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                                {
                                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlClickInternal - Resetting form: {ownerForm.toLogString()}, ID: {ownerForm.id}");
                                }
                                //ownerForm.reset();
                                break;
                            case "submit":
                            default:
                                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                                {
                                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlClickInternal - Submitting form: {ownerForm.toLogString()}, ID: {ownerForm.id}");
                                }
                                var formMethod = String.Format("{0}", ownerForm.getAttribute("method"));
                                var formAction = String.Format("{0}", ownerForm.getAttribute("action")) ;
                                string strUrl = commonHTML.GetAbsoluteUri(___document.___URL , null, formAction);
                                StringBuilder sbPostData = new StringBuilder();

                                commonHTML.createFormPostData(ownerForm, ref sbPostData);
                                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled && MultiHtmlCraft.Core.commonLog.LogLevel >= 10)
                                {
                                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: OnControlClickInternal - Form Post Data: {sbPostData.ToString()} for {strUrl} with method {formMethod}");
                                }
                                CHtmlMultiversalWebHistory historyItem = new CHtmlMultiversalWebHistory();
                                historyItem.Url = formAction;
                                historyItem.FileLocation = null;
                                historyItem.ContentType = "application/x-www-form-urlencoded";
                                historyItem.LastModified = DateTimeOffset.Now;
                                historyItem.Window = this.___multiversalWindow;
                                historyItem.Document = this.Document;
                                if(this.___multiversalWindow != null && this.___multiversalWindow.___document != null)
                                {
                                    historyItem.Document = this.___multiversalWindow.___document;
                                };


                                CHtmlMultiversalHistoryList.CHtmlMultiversalWebHistoryCache[new DateTimeOffset()] = historyItem;
                                resetMultiversalWindow();


                                var requestData = new CHtmlRequestData();
                                requestData.fields.Add("Method", formMethod); 
                                requestData.fields.Add("PostData", sbPostData.ToString());
                                requestData.fields.Add("ContentType", "application/x-www-form-urlencoded");
                                this._canvas.Children.Clear();


                                ___document = await MultiHtmlCraft.Core.CHtmlDocument.createDocument(CHtmlDomModeType.HTMLDOM, strUrl, ___multiversalWindow, requestData);



                                break;
                        }

                    }
                   
                }
            }
        }
        internal void resetMultiversalWindow()
        {
            ___multiversalWindow = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);

            if (___multiversalWindow != null)
            {
                ___multiversalWindow.setMultiversalControl(this);
                setMultiversalScriptScriptEngineType(IMultiversalScriptScriptEngineType.ClearScriptV8);
            }
            this.___document = null;
        }
        private async Task<DateTimeOffset?> ShowDynamicDateDialogAsync(Window parentWindow)
        {
            // 1. ダイアログ用のウィンドウを動的に作成
            var dialog = new Window
            {
                Title = "日付の選択",
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                SizeToContent = SizeToContent.Height // コンテンツに合わせて高さを自動調整
            };

            // 2. コントロールの配置と設定
            var stackPanel = new StackPanel { Margin = new Avalonia.Thickness(20), Spacing = 15 };
            var textBlock = new TextBlock { Text = "日付を入力してください:" };

            // DatePicker の生成
            var datePicker = new DatePicker
            {
                SelectedDate = DateTimeOffset.Now // 初期値を今日に設定
            };

            // ボタンエリアの作成
            var buttonPanel = new StackPanel
            {
                Orientation = Avalonia.Layout.Orientation.Horizontal,
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                Spacing = 10
            };

            var okButton = new Avalonia.Controls.Button
            { Content = "OK", IsDefault = true };
            var cancelButton = new Avalonia.Controls.Button 
            { Content = "Cancel", IsCancel = true };

            // 3. イベントハンドラーの登録（戻り値をセットして閉じる）
            DateTimeOffset? selectedDate = null;

            okButton.Click += (s, e) =>
            {
                selectedDate = datePicker.SelectedDate;
                dialog.Close();
            };

            cancelButton.Click += (s, e) =>
            {
                dialog.Close(); // selectedDate は null のまま閉じる
            };

            // 4. レイアウトの組み立て
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(datePicker);
            stackPanel.Children.Add(buttonPanel);

            dialog.Content = stackPanel;

            // 5. モーダルダイアログとして表示し、閉じるのを待つ
            await dialog.ShowDialog(parentWindow);

            return selectedDate;
        }

        #endregion 
    }
}
