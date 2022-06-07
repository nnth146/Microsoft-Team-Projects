using ExpenseManagement.Model;
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
using static ExpenseManagement.Messenger.Messenger;

namespace ExpenseManagement.ViewModel
{
    public class AddTransactionDialogViewModel : ViewModelBase
    {
        public AddTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            transactions = WeakReferenceMessenger.Default.Send<TransactionsMessenger>().Response;
            colors = new ObservableCollection<Color>();
            for(int i = 1; i <= 20; i++)
            {
                colors.Add(new Color("transaction" + i));
            }
            selectedColor = colors[0];
            NameTransaction = "";
        }

        public ObservableCollection<Transaction> transactions { get; set; }
        public ObservableCollection<Color> colors { get; set; }
        public Color selectedColor { get; set; }
        public string NameTransaction { get; set; }

        private RelayCommand _addTransactionCommand;
        public RelayCommand AddTransactionCommand
        {
            get
            {
                if(_addTransactionCommand == null)
                {
                    _addTransactionCommand = new RelayCommand(() =>
                    {
                        Transaction transaction = new Transaction();
                        transaction.Name = String.IsNullOrEmpty(NameTransaction) ? "Transaction" : NameTransaction;
                        transaction.Color = selectedColor.name;
                        transactions.Add(transaction);
                    });
                }
                return _addTransactionCommand;
            }
        }
    }
}
