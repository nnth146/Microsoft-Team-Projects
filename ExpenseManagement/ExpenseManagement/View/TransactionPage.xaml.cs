using ExpenseManagement.Model;
using ExpenseManagement.ViewModel;
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

namespace ExpenseManagement.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TransactionPage : Page
    {
        public TransactionPage()
        {
            this.InitializeComponent();
        }

        private void addTransaction_btn_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TransactionPageViewModel transactionPageViewModel = DataContext as TransactionPageViewModel;
            if(transactionPageViewModel != null)
            {
                Transaction transaction = e.Parameter as Transaction;
                transactionPageViewModel.transaction = transaction;
                transactionPageViewModel.spendings = Database.getSpendingByWhere("where id_transaction = " + transaction.Id);
                transactionPageViewModel.getCategory();
            }
        }

        private void HideSplitView(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            splitView.IsPaneOpen = true;
            AddSpending.Visibility = Visibility.Collapsed;
            EditSpending.Visibility = Visibility.Collapsed;
            ViewSpending.Visibility = Visibility.Visible;
        }

        private void EditSpending_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
            AddSpending.Visibility = Visibility.Collapsed;
            ViewSpending.Visibility = Visibility.Collapsed;
            EditSpending.Visibility = Visibility.Visible;
        }
    }
}
