using FocusTask.Models;
using FocusTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class UpcomingPage : Page
    {
        public UpcomingPage()
        {
            this.InitializeComponent();
        }
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplitViewTask.IsPaneOpen = true;
        }

        private void HideSpitView(object sender, RoutedEventArgs e)
        {
            SplitViewTask.IsPaneOpen = false;
        }

        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            DueDateFlyout.Hide();
        }

        private void ListViewProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            FlyoutProject.Hide();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpcomingPageViewModel upcoming = DataContext as UpcomingPageViewModel;
            ObservableCollection<TaskModel> taskModels = e.Parameter as ObservableCollection<TaskModel>;
            if (upcoming != null)
            {
                upcoming.taskModels = taskModels;
            }
        }

        private void HidePriorityFlyout(object sender, ItemClickEventArgs e)
        {
            PriorityFlyout.Hide();
        }

        private void HideFlyoutTaskProject(object sender, ItemClickEventArgs e)
        {
            FlyoutTaskProject.Hide();
        }

        private void HideRepeatTaskFlyout(object sender, RoutedEventArgs e)
        {
            RepeatTaskFlyout.Hide();
        }
    }
}
