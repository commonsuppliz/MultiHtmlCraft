using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MultiHtmlCraft.AvaroniaControl;
using System;
using System.Threading.Tasks;
using Avalonia.Input;

namespace MultiHtmlCraaft.AvaloniaControl_Tesst.Controls
{
    public partial class MultiversalAvaroniaView : UserControl
    {
        private MultiversalAvaroniaControl? _avaloniaMultiHtmlCraftControl;
        private TextBlock? _statusText;
        private Control? _controlHost;

        public TextBox? UrlTextBox => this.FindControl<TextBox>("txtUrl") ?? null;

        public Button? BackButton => this.FindControl<Button>("btnBack");
        public Button? ForwardButton => this.FindControl<Button>("btnForward");
        public Button? ReloadButton => this.FindControl<Button>("btnReload");
        public Button? GoButton => this.FindControl<Button>("btnGo");

        public MultiversalAvaroniaView()
        {
            InitializeComponent();

            _statusText = this.FindControl<TextBlock>("StatusText");
            _controlHost = this.FindControl<Control>("ControlHost");

            // create and hook up the control
            try
            {
                _avaloniaMultiHtmlCraftControl = new MultiversalAvaroniaControl();
                _avaloniaMultiHtmlCraftControl.skipWebAuthorityCheck = true; // for testing, skip authority check to allow loading any URL
                _avaloniaMultiHtmlCraftControl.DocumentLoaded += Control_DocumentLoaded;
                // attach the control to the visual tree so its Render will be called
                try
                {
                    if (_controlHost != null)
                    {
                        var prop = _controlHost.GetType().GetProperty("Content");
                        if (prop != null && prop.CanWrite)
                        {
                            prop.SetValue(_controlHost, _avaloniaMultiHtmlCraftControl);
                        }
                    }
                }
                catch
                {
                    // ignore
                }
                if (_statusText != null)
                    _statusText.Text = "MultiversalAvaroniaControl created.";

                // hook Enter key on URL textbox to navigate
                var urlBox = UrlTextBox;
                if (urlBox != null)
                {
                    urlBox.KeyDown += UrlTextBox_KeyDown;
                }

                // no visual currently, but you can place any Avalonia control into ControlHost later
            }
            catch (Exception ex)
            {
                if (_statusText != null)
                    _statusText.Text = $"Error creating control: {ex.Message}";
            }
        }

        public Task Navigate(string url)
        {
            if (_avaloniaMultiHtmlCraftControl != null && !string.IsNullOrWhiteSpace(url))
            {
                var task = _avaloniaMultiHtmlCraftControl.navigate(url);

                // after navigate completes, set focus to control host so keyboard events go there
                _ = task.ContinueWith(t =>
                {
                    Dispatcher.UIThread.Post(() =>
                    {
                        try
                        {
                            _avaloniaMultiHtmlCraftControl.Invalidate();
                            
                            _avaloniaMultiHtmlCraftControl.Focus();
                        }
                        catch
                        {
                            // ignore focus exceptions
                        }
                    });
                });

                return task;
            }
            return Task.CompletedTask;
        }

        // Expose the underlying control's script engine type so the host window can display it
        public object? getMultiversalScriptScriptEngineType()
        {
            return _avaloniaMultiHtmlCraftControl != null ? _avaloniaMultiHtmlCraftControl.getMultiversalScriptScriptEngineType() : null;
        }

        private void Control_DocumentLoaded(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.Post(() =>
            {
                if (_statusText != null)
                    _statusText.Text = "Document loaded.";

                // set focus to control host when the document is loaded
                try
                {
                    _avaloniaMultiHtmlCraftControl.Invalidate();
                    _controlHost?.Focus();
                }
                catch
                {
                    // ignore
                }
            });
        }

        private async void UrlTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var txt = UrlTextBox?.Text;
                if (!string.IsNullOrWhiteSpace(txt))
                {
                    try
                    {
                        await Navigate(txt!);
                    }
                    catch
                    {
                        // keep UI responsive; errors are logged by the control
                    }
                }

                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
