using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace ExpenseManagement.ViewModel
{
    public class ListTransactionPageViewModel : ViewModelBase
    {
        public ListTransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            ListSort = new ObservableCollection<string>()
            {
                "Sort by Name",
                "Sort by Date"
            };
        }

        public void GetSort()
        {
            if (SelectedSort == "Sort by Name")
            {
                Transactions = new ObservableCollection<Transaction>(Transactions.OrderBy(transaction => transaction.Name));
            }
            else
            {
                Transactions = new ObservableCollection<Transaction>(Transactions.OrderBy(transaction => transaction.CreatedOn));
            }
            OnPropertyChanged(nameof(Transactions));
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<string> ListSort { get; set; }
        public string SelectedSort { get; set; }

        private RelayCommand _sortChangedCommand;
        public RelayCommand SortChangedCommand => _sortChangedCommand ?? (_sortChangedCommand = new RelayCommand(() =>
        {
            GetSort();
        }));
    }
}
