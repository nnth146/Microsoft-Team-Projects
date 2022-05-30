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
    public sealed partial class StaticPage : Page
    {
        public StaticPage()
        {
            this.InitializeComponent();
        }

        private void Repeat_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            List<string> list = new List<string>()
            {
                "Days",
                "Weeks",
                "Months",
                "Years"
            };
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 1;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            List<string> list = new List<string>();
            for(int i  = 0; i <= 9999; i++)
            {
                list.Add(i.ToString());
            }
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 10;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter.ToString() == "Myday")
            {
                contentFrame.Navigate(typeof(MydayPage));
                NameProject.Text = "Myday";
            }
            if (e.Parameter.ToString() == "Tomorrow")
            {
                contentFrame.Navigate(typeof(TomorrowPage));
                NameProject.Text = "Tomorrow";
            }
            if (e.Parameter.ToString() == "Upcoming")
            {
                contentFrame.Navigate(typeof(UpcomingPage));
                NameProject.Text = "Upcoming";
            }
            if (e.Parameter.ToString() == "Someday")
            {
                contentFrame.Navigate(typeof(SomedayPage));
                NameProject.Text = "Someday";
            }
            if (e.Parameter.ToString() == "Completed")
            {
                contentFrame.Navigate(typeof(CompletedPage));
                NameProject.Text = "Completed";
            }
        }
    }
}
