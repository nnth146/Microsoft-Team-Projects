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
    public class AddTransactionDialogViewModel : ViewModelBase
    {
        public AddTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            Colors = new ObservableCollection<Color>();
            for (int i = 1; i <= 20; i++)
            {
                Colors.Add(new Color("transaction" + i));
            }
            SelectedColor = Colors[0];
            NameTransaction = "";
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<Color> Colors { get; set; }
        public Color SelectedColor { get; set; }
        public string NameTransaction { get; set; }

        private RelayCommand _addTransactionCommand;
        public RelayCommand AddTransactionCommand
        {
            get
            {
                if (_addTransactionCommand == null)
                {
                    _addTransactionCommand = new RelayCommand(() =>
                    {
                        Transaction transaction = new Transaction();
                        transaction.Name = String.IsNullOrEmpty(NameTransaction) ? "Transaction" : NameTransaction;
                        transaction.Color = SelectedColor.Name;
                        Transactions.Add(transaction);
                    });
                }
                return _addTransactionCommand;
            }
        }
    }
}
