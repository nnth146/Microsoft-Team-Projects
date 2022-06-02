using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KeepSafeForPassword.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();

            WeakReferenceMessenger.Default.Register<HomePageFrameRequestMessage>(this, (r, m) =>
            {
                m.Reply(SubFrame);
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            WeakReferenceMessenger.Default.UnregisterAll(this);
            WeakReferenceMessenger.Default.UnregisterAll(DataContext);

            
        }

        private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            NavViewItem itemSelected = args.SelectedItem as NavViewItem;
            if (itemSelected != null)
            {
                switch (itemSelected.Title)
                {
                    case "All Password":
                        if(SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewPasswordPage));
                        break;
                    case "Address":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewAddressPage));
                        break;
                    case "Contact":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewContactPage));
                        break;
                    case "Database":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewDatabasePage));
                        break;
                    case "Secure Note":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewSecureNotePage));
                        break;
                    case "Server":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewServerPage));
                        break;
                    case "Wifi":
                        if (SubFrame.CanGoBack) SubFrame.GoBack(null);
                        SubFrame.Navigate(typeof(ViewWifiPage));
                        break;
                }
            }
        }

        private void SubFrame_Loaded(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(WaitingPage));
        }
    }
}
