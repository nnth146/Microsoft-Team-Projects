using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace ExpenseManagement.ViewModel
{
    public class DeleteTransactionDialogViewModel : ViewModelBase
    {
        public DeleteTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            Transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public Transaction Transaction { get; set; }

        private RelayCommand _deleteTransactionCommand;
        public RelayCommand DeleteTransactionCommand => _deleteTransactionCommand ?? (_deleteTransactionCommand = new RelayCommand(() =>
        {
            Transactions.Remove(Transaction);
        })); 
    }
}
