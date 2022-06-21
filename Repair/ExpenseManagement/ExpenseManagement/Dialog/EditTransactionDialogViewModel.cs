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
    public class EditTransactionDialogViewModel : ViewModelBase
    {
        public EditTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            Transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
            Colors = new ObservableCollection<Color>();
            for (int i = 1; i <= 20; i++)
            {
                Colors.Add(new Color("transaction" + i));
            }
            NameTransaction = Transaction.Name;
            for (int i = 0; i < Colors.Count; i++)
            {
                if (Transaction.Color == "transaction" + (i + 1))
                {
                    SelectedColor = Colors[i];
                }
            }
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public Transaction Transaction { get; set; }

        public ObservableCollection<Color> Colors { get; set; }
        public Color SelectedColor { get; set; }

        public string NameTransaction { get; set; }

        private RelayCommand _editTransactionCommand;
        public RelayCommand EditTransactionCommand => _editTransactionCommand ?? (_editTransactionCommand = new RelayCommand(() =>
        {
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (Transactions[i].Id == Transaction.Id)
                {
                    Transaction.Name = String.IsNullOrEmpty(NameTransaction) ? "Transaction..." : NameTransaction;
                    Transaction.Color = SelectedColor.Name;
                    Transactions[i] = Transaction;
                    break;
                }
            }
        }));
    }
}
