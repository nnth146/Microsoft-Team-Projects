using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpenseManagement.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ListViewTransaction_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListViewBasic.SelectedItem = null;
        }

        private void ListViewBasic_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListViewTransaction.SelectedItem = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewBasic.SelectedItem = ListViewBasic.Items[0];
        }
    }
}
