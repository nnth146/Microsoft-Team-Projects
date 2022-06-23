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

namespace MoneyLover.View.Dialog
{
    public sealed partial class WaitingDialog : ContentDialog
    {

        DispatcherTimer timer;

        private int _second = 1;
        private bool _canClose = false;

        public WaitingDialog()
        {
            this.InitializeComponent();
            this.Closing += WaitingDialog_Closing;

            Second.Text = "1";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
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
                timer.Stop();
                _canClose = true;
                this.Hide();
            }
            _second--;
            Second.Text = _second.ToString();
        }
    }
}
