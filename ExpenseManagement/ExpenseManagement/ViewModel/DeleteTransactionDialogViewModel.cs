using ExpenseManagement.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Mvvm.Core.Helper;
using UWP.Mvvm.Core.Service;
using static ExpenseManagement.Messenger.Messenger;

namespace ExpenseManagement.ViewModel
{
    public class DeleteTransactionDialogViewModel : ServiceObservableObject
    {
        public DeleteTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
        }
        public ObservableCollection<Transaction> transactions { get; set; }
        public Transaction transaction { get; set; }

        private RelayCommand _deleteTransactionCommand;
        public RelayCommand DeleteTransactionCommand
        {
            get
            {
                if (_deleteTransactionCommand == null)
                {
                    _deleteTransactionCommand = new RelayCommand(() =>
                    {
                        transactions.Remove(transaction);
                    });
                }
                return _deleteTransactionCommand;
            }
        }
    }
}
