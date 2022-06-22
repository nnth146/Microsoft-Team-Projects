using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpenseManagement.View.Dialog
{
    public sealed partial class WaitingDialog : ContentDialog
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private int _second = 1;
        private bool _canClose = false;

        public WaitingDialog()
        {
            this.InitializeComponent();

            this.Closing += WaitingDialog_Closing;

            Second.Text = "1";

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void WaitingDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (args.Result == ContentDialogResult.None)
            {
                args.Cancel = true;
            }

            if (_canClose)
            {
                args.Cancel = false;
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            if (_second == 0)
            {
                _timer.Stop();
                _canClose = true;
                this.Hide();
            }
            _second--;
            Second.Text = _second.ToString();
        }
    }
}
