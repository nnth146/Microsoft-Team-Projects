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

namespace FocusTask.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
        }

        private void ListViewSetting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewSetting != null)
            {
                ListViewItem listViewItem = e.AddedItems[0] as ListViewItem;
                switch(listViewItem.Tag)
                {
                    case "ShopPrimeum":
                        settingFrame.Navigate(typeof(PrimeumPage));
                        shopPrimeum.Visibility = Visibility.Collapsed;
                        shopPrimeumSelected.Visibility = Visibility.Visible;
                        about.Visibility = Visibility.Visible;
                        aboutSelected.Visibility = Visibility.Collapsed;
                        break;
                    case "About":
                        settingFrame.Navigate(typeof(AboutPage));
                        about.Visibility = Visibility.Collapsed;
                        aboutSelected.Visibility = Visibility.Visible;
                        shopPrimeum.Visibility = Visibility.Visible;
                        shopPrimeumSelected.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
