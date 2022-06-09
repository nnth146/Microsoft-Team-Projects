using FocusTask.Messenger;
using Microsoft.Toolkit.Mvvm.Messaging;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FocusTask.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            this.InitializeComponent();

            RegisterMessenger();
        }

        private void RegisterMessenger()
        {
            WeakReferenceMessenger.Default.Register<SetDisplayDueDateMessage>(this, (r, m) =>
            {
                DateTimeOffset date = new DateTimeOffset(m.DueDate);
                DueDateCalendar.SelectedDates.Clear();
                DueDateCalendar.SelectedDates.Add(date);
            });

            WeakReferenceMessenger.Default.Register<SetDisplayReminderMessage>(this, (r, m) =>
            {
                DateTimeOffset date = new DateTimeOffset(m.Reminder);
                ReminderCalendar.SelectedDates.Clear();
                ReminderCalendar.SelectedDates.Add(date);
            });

            WeakReferenceMessenger.Default.Register<NoteValueChanged>(this, (r, m) =>
            {
                NoteTask.Document.SetText(Windows.UI.Text.TextSetOptions.None, m.Value ?? "");
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            WeakReferenceMessenger.Default.UnregisterAll(this);
            WeakReferenceMessenger.Default.UnregisterAll(DataContext);
        }

        private void DueDateCalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (args.AddedDates.Count > 0)
            {
                DueDateChangedCommand.Command.Execute(args.AddedDates[0]);
            }
            else
            {
                DueDateChangedCommand.Command.Execute(null);
            }

        }
        #region Hide Flyout Event
        private void HideDueFlyout_Event(object sender, RoutedEventArgs e)
        {
            DueDateFlyout.Hide();
        }

        private void HidePriorityFlyout_Event(object sender, TappedRoutedEventArgs e)
        {
            ChoosePriorityFlyout.Hide();
        }

        private void HideChangeProjectFlyout_Event(object sender, TappedRoutedEventArgs e)
        {
            ChangeProjectFlyout.Hide();
        }

        private void HideChooseProjectFlyout_Event(object sender, TappedRoutedEventArgs e)
        {
            ChooseProjectFlyout.Hide();
        }

        private void HideReminderFlyout_Event(object sender, RoutedEventArgs e)
        {
            ReminderFlyout.Hide();
        }

        private void HideRepeatFlyout_Event(object sender, RoutedEventArgs e)
        {
            RepeatFlyout.Hide();
        }
        #endregion

        private void ReminderCalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (args.AddedDates.Count > 0)
            {
                ReminderChangedCommand.Command.Execute(args.AddedDates[0]);
            }
            else
            {
                ReminderChangedCommand.Command.Execute(null);
            }
        }

        private void NoteTask_LostFocus(object sender, RoutedEventArgs e)
        {
            string value;
            NoteTask.Document.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out value);
            SaveNoteCommand.Command.Execute(value);
        }
    }
}
