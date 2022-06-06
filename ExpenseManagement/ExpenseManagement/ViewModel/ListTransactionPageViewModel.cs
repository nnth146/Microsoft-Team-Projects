using ExpenseManagement.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Mvvm.Core.Helper;
using UWP.Mvvm.Core.Service;

namespace ExpenseManagement.ViewModel
{
    public class ListTransactionPageViewModel : ServiceObservableObject
    {
        public ListTransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            listSort = new ObservableCollection<string>()
            {
                "Sort by Name",
                "Sort by Date"
            };
        }

        public void getSort()
        {
            if(selectedSort == "Sort by Name")
            {
                transactions = new ObservableCollection<Transaction>(transactions.OrderBy(transaction => transaction.Name));
            } else
            {
                transactions = new ObservableCollection<Transaction>(transactions.OrderBy(transaction => transaction.Create_On));
            }
            OnPropertyChanged(nameof(transactions));
        }

        public ObservableCollection<Transaction> transactions { get; set; }
        public ObservableCollection<string> listSort { get; set; }
        public string selectedSort { get; set; }

        private RelayCommand _sortChangedCommand;
        public RelayCommand SortChangedCommand
        {
            get
            {
                if (_sortChangedCommand == null)
                {
                    _sortChangedCommand = new RelayCommand(() =>
                    {
                        Debug.WriteLine("Slected: " + selectedSort);
                        getSort();
                    });
                }
                return _sortChangedCommand;
            }
        }
    }
}
