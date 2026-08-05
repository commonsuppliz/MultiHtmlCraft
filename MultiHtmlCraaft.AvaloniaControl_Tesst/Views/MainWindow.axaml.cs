using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using MultiHtmlCraaft.AvaloniaControl_Tesst.Controls;
using MultiHtmlCraft.Core;
using System;
using static System.Net.WebRequestMethods;

namespace MultiHtmlCraaft.AvaloniaControl_Tesst.Views
{
    public partial class MainWindow : Window
    {
        private MultiversalAvaroniaView? _multiView;

        public MainWindow()
        {
            InitializeComponent();

            _multiView = this.FindControl<MultiversalAvaroniaView>("MultiversalAvaroniaView");
            var txt = this.FindControl<TextBox>("txtUrl");
            var btnGo = this.FindControl<Button>("btnGo");

            // set a default URL into the textbox when the window/control is loaded
            if (txt != null)
            {
                // txt.Text = "http://localhost/html/SimpleHTMLDoc2.html"; // set your desired default URL here
                //txt.Text = "http://localhost/canvas/CanvasDrawLineTest1.html"; // Canvas Draw Lines Test
                // txt.Text = "http://localhost/canvas/CanvasQuadraricCurvetoTest1.html";
                // txt.Text = "http://localhost/canvas/CanvasBezierCavasTest1.html"; // Canvas Bezier Curve Test
                // txt.Text = "http://localhost/canvas/CanvasDrawImageSimpleTest1.html";
                //txt.Text = "http://localhost/html/ImgTest.html";// ___drawImage() OK
                //txt.Text = "http://localhost/canvas/RequestAnimationFrameTest1.html"; // Animation Frame Test
                //txt.Text = "http://localhost/canvas/CanvasFillRectTest2.html"; // Fill Rect Test OK
                // txt.Text = "http://localhost/canvas/CanvasMeasureTextTest.html";
                // txt.Text = "http://localhost/canvas/CanvasImageMove4.html"; // Canvas Image Move Test OK
                // txt.Text = "http://localhost/jstest/SetIntervalTestSimple.html";
                //txt.Text = "http://localhost/canvas/CanvasClipTest1.html";// Canvas Clip Test OK
                //txt.Text = "http://localhost/jstest/SetTimeoutTest1.html";// SetTimeout Test OK
                //  txt.Text= "http://localhost/canvas/RequestAnimationFrameRGBATest1.html";//
                //txt.Text = "http://localhost/phoria.js-master/test3_noGUI.html";
                //txt.Text = "http://localhost/phoria.js-master/test1d_nogui.html";
                // txt.Text ="http://localhost/canvas/jagarikin/angelic_weapon.html";// Angelic Weapon Test by jagarikin HSLA
                //txt.Text ="http://localhost/canvas/jagarikin/angelic_weapon_RGBA.html";// Angelic Weapon Test by jagarikin RGBA
                // txt.Text = "http://localhost/canvas/CanvasBeginPathClosePathMove.html"; // Canvas BeginPath ClosePath MoveTo Test OK
                // txt.Text = "http://localhost/phoria.js-master/test1t_noGUI.html"; // Phoria Textbure
                // txt.Text = "http://localhost/canvas/CanvasClipTest1.html"; // Canvas Clip Test OK
                //txt.Text = "http://localhost/mariohtml5-master/minTest.html"; // Mario HTML5 Test OnProgress
                //txt.Text = "http://localhost/phoria.js-master/test4g_NoGUI.Q"; // Phoria 3D Test Slow on progress but works
                // txt.Text = "http://localhost/canvas/tmrDevelop/cosmos.html"; // Cosmos Test by tmrDevelop 
                //txt.Text = "http://localhost/jstest/jqueryTest/JQuwey371Test1.html"; // JQuert 371 Test document.createElement Fail
                //txt.Text = "http://localhost/jstest/AudioCanPlayTypeTest1.html";//
                //txt.Text = "http://localhost/canvas/CanvasImageMove4.html"; // Canvas Image Move Test OK
                // txt.Text = "http://localhost/canvas/jagarikin/angelic_weapon.html"; // Angelic Weapon Test by jagarikin
                //txt.Text = "http://localhost/jstest/ImageTeset1.html"; // 3 image load test with promise
                //txt.Text = "http://localhost/jstest/FetchJSonTest.html"; // Fetch JSON Test OK
                // txt.Text = "http://localhost/canvas/DonkeyKongTest.html";// Donkey Kong Test   onload function is set before src is set
                //txt.Text = "http://localhost/canvas/DonkeyKongTestAfterSrcIsSet.html";// Donkey Kong Test   onload function is set after src is set
                // txt.Text = "http://localhost/jstest/KeyDownTest1.html"; // KeyDown Test 
                // txt.Text = "http://localhost/jstest/DocumentAddEventListerTest1.html";//
                // txt.Text = "http://localhost/canvas/canvasEllpseTest1.html"; // Canvas Ellipse Test OK
                // txt.Text = "http://localhost/canvas/CanvasGradius3.html"; // Space Harior Javascript Canvas Test 
                ///txt.Text = "http://localhost/canvas/CanvasMouseMoveTest1.html"; //
                // txt.Text = "http://localhost/jstest/SimpleMouseMoveTest1.html"; // Simple Mouse Move Test
                // txt.Text = "http://localhost/jstest/SimpleMouseDownTest1.html";// Simple Mouse Down Test
                // txt.Text = "http://localhost/canvas/SpaceHarrior.html";// Space Harrior Canvas Test 
                // txt.Text = "http://localhost/canvas/DoruagaTower.html";// 
                //txt.Text = "http://localhost/canvas/CrazyClimber.html";// Crazy Climber Canvas Test KeyDown Event Works
                //txt.Text = "http://localhost/jstest/KeyBoardEvent_WithKeyTest1.html";// Keyboard Event with Key Test
                //  txt.Text = "http://localhost/canvas/gradius-master/index.html";// Gradius Test
                //txt.Text = "http://localhost/canvas/CreateImageDataTest1.html";// Canvas createImageData Test, OK
                // txt.Text = "http://localhost/canvas/CanvasGetImageDataSample.html"; // Canvas GetImageData
                //txt.Text = "http://localhost/html/CSSBackgroundImageRepeat.html";// Image Repeat
                // txt.Text = "http://localhost/jstest/jqueryTest/JQuwey4_4_0_0_Test1.html"; // JQuery 4.0.0 Test matches Error
                //txt.Text = "http://localhost/jstest/jqueryTest/SimpleMatchesTest1.html";// elementMatches Test
                //txt.Text = "http://localhost/jstest/WindowDocumentAddEventListenerTesst1.html"; // Window Document AddEventListener Test OK
                //txt.Text = "http://localhost/canvas/CanvasBackBufferTest1.html";// Canvas Back Buffer Test 1 OK
                // txt.Text = "http://localhost/canvas/CanvasBackBufferTest3.html";// Canvas Back Buffer Test 3 OK
                //txt.Text = "http://localhost/mariohtml5-master/minTest_NonJquery.html"; // Mario HTML5 Test Non JQuery Test 
                //txt.Text = "https://www.joshuakgoldberg.com/FullScreenMario/Source/"; // Canvas Fill Style Test OKE“ï½E
                //txt.Text = "http://localhost/jstest/AudioPlayTest1.html"; // Audio Play Test 1 OK
                //  txt.Text = "http://localhost/html/HtmlControlTest1.html"; // Html Control Test 1 OK
                //txt.Text = "http://localhost/html/QuerySelectorAllTest1.html";//
                //txt.Text = "http://localhost/canvas/CanvasGradius4.html";// Canvas Gradius 4 Test OK
                //txt.Text = "http://localhost/canvas/WindowOnloadTest1.html"; // Window onload Test
                //txt.Text = "http://localhost/canvas/CanvasBrushTest1.html"; // Canvas Brush Test 1 OK
                //txt.Text = "http://localhost/canvas/CanvasCreatePatternTest1.html";//
                // txt.Text = "http://localhost/html/HtmlControlTest1.html"; // Html Post Test 1
                // txt.Text = "http://localhost/html/HtmlPostTest2.html"; // Html Post Test 2 OK
                // txt.Text = "http://localhost/html/FetchTest1.html"; // HTML Fetch Test
                //txt.Text = "http://localhost/html/FetchTest2NoArrowFunction.html"; // HTML Fetch Test
                //txt.Text = "http://localhost/html/DocumentFunctionTest1.html"; // HTML Fetch Test  OK
                txt.Text = "http://localhost/html/DeferScriptTest.html"; // defer script Test
            }

            if (btnGo != null && txt != null && _multiView != null)
            {
                // When the Go button is clicked, await navigation and then ensure the view is focused
                btnGo.Click += async (_, __) =>
                {
                    string? url = txt.Text;
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        try
                        {
                            await _multiView.Navigate(url);

                            // ensure the view gets focus and is invalidated so it will render updated content
                            Dispatcher.UIThread.Post(() =>
                            {
                                try
                                {
                                    _multiView.Focus();
                                    _multiView.InvalidateVisual();
                                }
                                catch { }
                            });
                        }
                        catch
                        {
                            // errors are logged by the control; keep UI responsive
                        }
                    }
                };

                // handle Enter key on the URL textbox
                txt.KeyDown += TxtUrl_KeyDown;
            }

            // Build the status/title string and log it
            try
            {
                var scriptEngineType = _multiView?.getMultiversalScriptScriptEngineType()?.ToString() ?? "(none)";
                string strMultiHtmlCraftLibraries = $"MultiHtmlCraft .Net: {System.Environment.Version} GraphicAPI: {commonHTML.GraphicApiType} ScriptEngines: {scriptEngineType} Managed Thread ID {System.Threading.Thread.CurrentThread.ManagedThreadId}";

                // set the window title
                this.Title = strMultiHtmlCraftLibraries;

                // log application start
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry($"Application Started : {strMultiHtmlCraftLibraries}");
                }
            }
            catch (Exception ex)
            {
                // avoid throwing during window construction; log if possible
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("MainWindow: Error setting title/logging: {0}", ex);
                }
            }
        }

        private async void TxtUrl_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var txt = sender as TextBox;
                string? url = txt?.Text;
                if (!string.IsNullOrWhiteSpace(url) && _multiView != null)
                {
                    try
                    {
                        await _multiView.Navigate(url);

                        // ensure the view gets focus and is invalidated so it will render updated content
                        Dispatcher.UIThread.Post(() =>
                        {
                            try
                            {
                                _multiView.Focus();
                                _multiView.InvalidateVisual();
                            }
                            catch { }
                        });
                    }
                    catch
                    {
                        // errors are logged by the control; keep UI responsive
                    }

                    e.Handled = true;
                }
            }
        }
    }
}