using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MoneyLover.Database;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using static MoneyLover.Messenger.Messenger;

namespace MoneyLover.ViewModel
{
    public class DeleteTransactionDialogViewModel : ViewModelBase
    {
        public DeleteTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = WeakReferenceMessenger.Default.Send<BudgetsMessenger>().Response;
            transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
        }

        public Transaction transaction { get; set; }
        public ObservableCollection<Budget> budgets { get; set; }

        // Delete Transaction
        private RelayCommand _deleteTransactionCommand;
        public RelayCommand DeleteTransactionCommand
        {
            get
            {
                if (_deleteTransactionCommand == null)
                {
                    _deleteTransactionCommand = new RelayCommand(() =>
                    {
                        DB.deleteTransactionById(transaction.Id);
                        for (int j = 0; j < budgets.Count; j++)
                        {
                            Budget budget = budgets[j];
                            for (int i = 0; i < budget.Transactions.Count; i++)
                            {
                                if (budget.Transactions[i].Id == transaction.Id)
                                {
                                    budget.Transactions.Remove(transaction);
                                    budgets[j] = budget;
                                    break;
                                }
                            }
                        }
                    });
                }
                return _deleteTransactionCommand;
            }
        }
    }
}
