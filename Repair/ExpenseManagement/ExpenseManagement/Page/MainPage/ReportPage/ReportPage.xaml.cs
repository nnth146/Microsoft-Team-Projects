using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class ReportPage : Page
    {
        public ReportPage()
        {
            this.InitializeComponent();
        }

        private void Monthly_Click(object sender, RoutedEventArgs e)
        {
            Monthly.Background = new SolidColorBrush(Color.FromArgb(255, 255, 209, 36));
            Annual.Background = new SolidColorBrush(Colors.White);
            SelectedAnnual.Visibility = Visibility.Collapsed;
            SelectedMonthly.Visibility = Visibility.Visible;
        }

        private void Annual_Click(object sender, RoutedEventArgs e)
        {
            Annual.Background = new SolidColorBrush(Color.FromArgb(255, 255, 209, 36));
            Monthly.Background = new SolidColorBrush(Colors.White);
            SelectedMonthly.Visibility = Visibility.Collapsed;
            SelectedAnnual.Visibility = Visibility.Visible;
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            Income.Background = new SolidColorBrush(Color.FromArgb(255, 255, 209, 36));
            Expense.Background = new SolidColorBrush(Colors.White);
            ListViewExpenseItem.Visibility = Visibility.Collapsed;
            ListViewIcomeItem.Visibility = Visibility.Visible;
        }

        private void Expense_Click(object sender, RoutedEventArgs e)
        {
            Expense.Background = new SolidColorBrush(Color.FromArgb(255, 255, 209, 36));
            Income.Background = new SolidColorBrush(Colors.White);
            ListViewIcomeItem.Visibility = Visibility.Collapsed;
            ListViewExpenseItem.Visibility = Visibility.Visible;
        }

        private void ListViewItemIcome_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*ListViewItemIcome.Visibility = Visibility.Collapsed;
            ListViewSubItem.Visibility = Visibility.Visible;*/
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            /*ListViewSubItem.Visibility = Visibility.Collapsed;
            ListViewItemIcome.Visibility = Visibility.Visible;*/
        }

        private void SaveMonth_Click(object sender, RoutedEventArgs e)
        {
            MonthltFlyout.Hide();
        }

        private void SaveYear_Click(object sender, RoutedEventArgs e)
        {
            YearFlyout.Hide();
        }
    }
}
