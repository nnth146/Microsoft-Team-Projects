using FocusTask.Models;
using FocusTask.ViewModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MydayPageViewModel myday = DataContext as MydayPageViewModel;
            ObservableCollection<TaskModel> taskModels = e.Parameter as ObservableCollection<TaskModel>;
            if(myday != null)
            {
                myday.taskModels = taskModels;
                ObservableCollection<TaskModel> taskUnCompletedModels = new ObservableCollection<TaskModel>();
                ObservableCollection<TaskModel> taskCompletedModels = new ObservableCollection<TaskModel>();
                for (int i = 0; i < taskModels.Count; i++)
                {
                    if(taskModels[i].is_completed)
                        taskCompletedModels.Add(taskModels[i]);
                    else taskUnCompletedModels.Add(taskModels[i]);
                }
                myday.taskCompletedModels = taskCompletedModels;
                myday.taskUncompletedModels = taskUnCompletedModels;
            }
        }

        private void ListViewCompleted_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplitViewTask.IsPaneOpen = true;
            ListViewUnCompleted.SelectedItem = null;
        }

        private void ListViewUnCompleted_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplitViewTask.IsPaneOpen = true;
            ListViewCompleted.SelectedItem = null;
        }

        private void HideFlyoutTaskProject(object sender, ItemClickEventArgs e)
        {
            FlyoutTaskProject.Hide();
        }

        private void HideRepeatTaskFlyout(object sender, RoutedEventArgs e)
        {
            RepeatTaskFlyout.Hide();
        }

        private void HidePriorityFlyout(object sender, ItemClickEventArgs e)
        {
            PriorityFlyout.Hide();
        }
    }
}
