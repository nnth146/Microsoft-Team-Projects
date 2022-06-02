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
    public class EditTransactionDialogViewModel : ServiceObservableObject
    {
        public EditTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
            colors = new ObservableCollection<Color>();
            for (int i = 1; i <= 20; i++)
            {
                colors.Add(new Color("transaction" + i));
            }
            NameTransaction = transaction.Name;
            for(int i = 0; i < colors.Count; i++)
            {
                if (transaction.Color == "transaction" + (i+1))
                {
                    selectedColor = colors[i];
                }
            }
        }

        public ObservableCollection<Transaction> transactions { get; set; }
        public ObservableCollection<Color> colors { get; set; }
        public Transaction transaction { get; set; }
        public Color selectedColor { get; set; }
        public string NameTransaction { get; set; }

        private RelayCommand _editTransactionCommand;
        public RelayCommand EditTransactionCommand
        {
            get
            {
                if (_editTransactionCommand == null)
                {
                    _editTransactionCommand = new RelayCommand(() =>
                    {
                        for(int i = 0; i < transactions.Count; i++)
                        {
                            if(transactions[i].Id == transaction.Id)
                            {
                                transaction.Name = String.IsNullOrEmpty(NameTransaction) ? "Transaction..." : NameTransaction;
                                transaction.Color = selectedColor.name;
                                transactions[i] = transaction;
                                break;
                            }
                        }
                    });
                }
                return _editTransactionCommand;
            }
        }
    }
}
