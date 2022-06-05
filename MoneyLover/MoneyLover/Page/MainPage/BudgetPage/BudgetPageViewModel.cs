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
    public class BudgetPageViewModel : ViewModelBase
    {
        public BudgetPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = DB.getBudgetByWhere("");
            budgets.CollectionChanged += Budgets_CollectionChanged;
            getTransactionBudget();
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
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                DB.addNewBudget(e.NewItems[0] as Budget);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Budget budget = e.NewItems[0] as Budget;
                DB.updateBudgetById(budget, budget.Id);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Budget budget = e.OldItems[0] as Budget;
                DB.deleteBudgetById(budget.Id);
            }
            getTransactionBudget();
        }
        #endregion

        public ObservableCollection<Budget> budgets { get; set; }

        #region Command
        // Add Budget
        private RelayCommand _addNewBudgetCommand;
        public RelayCommand AddNewBudgetCommand
        {
            get
            {
                if(_addNewBudgetCommand == null)
                {
                    _addNewBudgetCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        dialogService.showAsync(typeof(AddWalletDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                    });
                }
                return _addNewBudgetCommand;
            }
        }

        // Edit Budget
        private RelayCommand<Budget> _editBudgetCommand;
        public RelayCommand<Budget> EditBudgetCommand
        {
            get
            {
                if(_editBudgetCommand == null)
                {
                    _editBudgetCommand = new RelayCommand<Budget>((selectedBudget) =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        WeakReferenceMessenger.Default.Register<BudgetMessenger>(this, (r, m) =>
                        {
                            m.Reply(selectedBudget);
                        });
                        dialogService.showAsync(typeof(EditWalletDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                        WeakReferenceMessenger.Default.Unregister<BudgetMessenger>(this);
                    });
                }
                return _editBudgetCommand;
            }
        }

        // Delete Budget
        private RelayCommand<Budget> _deleteBudgetCommand;
        public RelayCommand<Budget> DeleteBudgetCommand
        {
            get
            {
                if (_deleteBudgetCommand == null)
                {
                    _deleteBudgetCommand = new RelayCommand<Budget>((selectedBudget) =>
                    {
                        WeakReferenceMessenger.Default.Register<BudgetsMessenger>(this, (r, m) =>
                        {
                            m.Reply(budgets);
                        });
                        WeakReferenceMessenger.Default.Register<BudgetMessenger>(this, (r, m) =>
                        {
                            m.Reply(selectedBudget);
                        });
                        dialogService.showAsync(typeof(DeleteWalletDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<BudgetsMessenger>(this);
                        WeakReferenceMessenger.Default.Unregister<BudgetMessenger>(this);
                    });
                }
                return _deleteBudgetCommand;
            }
        }
        #endregion
    }
}
