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
using static FocusTask.Messenger.Messenger;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FocusTask.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MydayPage : Page
    {
        public MydayPage()
        {
            this.InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            btn_show.Visibility = Visibility.Collapsed;
            btn_hide.Visibility = Visibility.Visible;
            ListViewCompleted.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ListViewCompleted.Visibility = Visibility.Collapsed;
            btn_hide.Visibility = Visibility.Collapsed;
            btn_show.Visibility = Visibility.Visible;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplitViewTask.IsPaneOpen = true;
        }

        private void HideSpitView(object sender, RoutedEventArgs e)
        {
            SplitViewTask.IsPaneOpen= false;
        }

        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            DueDateFlyout.Hide();
        }

        private void ListViewProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            FlyoutProject.Hide();
        }
    }
}
