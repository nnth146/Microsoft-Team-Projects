using FocusTask.Models;
using FocusTask.View.Dialog;
using FocusTask.ViewModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Core.Service;
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
using static FocusTask.Messenger.Messenger;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FocusTask.View
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog editDialog = new DeleteDialog();
            await editDialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewTop.SelectedItem = ListViewTop.Items[0];
        }

        private void ListViewTop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem listViewItem = e.AddedItems[0] as ListViewItem;
            switch (listViewItem.Tag)
            {
                case "Myday":
                    contentFrame.Navigate(typeof(MydayPage));
                    break;
                case "Tomorrow":
                    contentFrame.Navigate(typeof(StaticPage), "Tomorrow");
                    break;
                case "Upcoming":
                    contentFrame.Navigate(typeof(StaticPage), "Upcoming");
                    break;
                case "Someday":
                    contentFrame.Navigate(typeof(StaticPage), "Someday");
                    break;
                case "Completed":
                    contentFrame.Navigate(typeof(StaticPage), "Completed");
                    break;
            }
        }
    }
}
