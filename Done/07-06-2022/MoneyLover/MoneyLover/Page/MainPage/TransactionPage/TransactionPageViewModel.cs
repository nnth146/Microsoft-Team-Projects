using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MoneyLover.Database;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using static MoneyLover.Messenger.Messenger;

namespace MoneyLover.ViewModel
{
    public class TransactionPageViewModel : ViewModelBase
    {
        public TransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            setValue();
        }

        private void setValue()
        {
            budgets = DB.getBudgetByWhere("");
            budgets.CollectionChanged += Budgets_CollectionChanged;
            getTransactionBudget(); 
            Vs = new ObservableGroupedCollection<Budget, ObservableCollection<Transaction>>(budgets.GroupBy(x => x, x => x.Transactions));
            OnPropertyChanged(nameof(Vs));
        }

        private void getTransactionBudget()
        {
            foreach (Budget budget in budgets)
            {
                budget.Transactions = DB.getTransactionByWhere("where id_budget = " + budget.Id);
            }
            OnPropertyChanged(nameof(budgets));
        }

        #region CollectionChanged
        private void Budgets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Budget budget = e.NewItems[0] as Budget;
                DB.updateBudgetById(budget, budget.Id);
            }
            setValue();
        }
        #endregion

        public ObservableGroupedCollection<Budget, ObservableCollection<Transaction>> Vs { get; set; }


        public ObservableCollection<Budget> budgets { get; set; }
        public ObservableCollection<Transaction> transactions { get; set; }

        #region Command
        // Add Transaction
        private RelayCommand<Budget> _addNewTransactionCommand;
        public RelayCommand<Budget> AddNewTransactionCommand
        {
            get
            {
                if (_addNewTransactionCommand == null)
                {
                    _addNewTransactionCommand = new RelayCommand<Budget>((selectedBudget) =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        WeakReferenceMessenger.Default.Register<BudgetMessenger>(this, (r, m) =>
                        {
                            m.Reply(selectedBudget);
                        });
                        dialogService.showAsync(typeof(AddTransactionDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                        WeakReferenceMessenger.Default.Unregister<BudgetMessenger>(this);
                    });
                }
                return _addNewTransactionCommand;
            }
        }
        
        // Edit
        private RelayCommand<Transaction> _editTransactionCommand;
        public RelayCommand<Transaction> EditTransactionCommand
        {
            get
            {
                if (_editTransactionCommand == null)
                {
                    _editTransactionCommand = new RelayCommand<Transaction>((selectedTransaction) =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        WeakReferenceMessenger.Default.Register<TransactionMessenger>(this, (r, m) =>
                        {
                            m.Reply(selectedTransaction);
                        });
                        dialogService.showAsync(typeof(EditTransactionDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                        WeakReferenceMessenger.Default.Unregister<TransactionMessenger>(this);
                    });
                }
                return _editTransactionCommand;
            }
        }

        // Delete
        private RelayCommand<Transaction> _deleteTransactionCommand;
        public RelayCommand<Transaction> DeleteTransactionCommand
        {
            get
            {
                if (_deleteTransactionCommand == null)
                {
                    _deleteTransactionCommand = new RelayCommand<Transaction>((selectedTransaction) =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        WeakReferenceMessenger.Default.Register<TransactionMessenger>(this, (r, m) =>
                        {
                            m.Reply(selectedTransaction);
                        });
                        dialogService.showAsync(typeof(DeleteTransactionDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                        WeakReferenceMessenger.Default.Unregister<TransactionMessenger>(this);
                    });
                }
                return _deleteTransactionCommand;
            }
        }
        #endregion
    }
}
