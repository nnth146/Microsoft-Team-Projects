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
    public class AddTransactionDialogViewModel : ViewModelBase
    {
        public AddTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = WeakReferenceMessenger.Default.Send<BudgetsMessenger>().Response;
            budget = WeakReferenceMessenger.Default.Send<BudgetMessenger>().Response;
            getCategory();
            resetValue();
        }

        private void resetValue()
        {
            NameTransaction = "";
            MoneyTransaction = 0;
            CurrencyTransaction = categories[0];
            Create_OnTransaction = DateTimeOffset.Now.LocalDateTime;
            NoteTransaction = "";
        }

        private void getCategory()
        {
            categories = DB.getCategoryByWhere("");
            OnPropertyChanged(nameof(categories));
        }

        public ObservableCollection<Budget> budgets { get; set; }
        public Budget budget { get; set; }

        // Category
        public ObservableCollection<Category> categories { get; set; }

        // Variable Add Transaction
        public string NameTransaction { get; set; }
        public Double MoneyTransaction { get; set; }
        public Category CurrencyTransaction { get; set; }
        public DateTimeOffset Create_OnTransaction { get; set; }
        public string NoteTransaction { get; set; }

        #region Command
        // Add New Category
        private RelayCommand _addCategoryCommand;
        public RelayCommand AddCategoryCommand
        {
            get
            {
                if(_addCategoryCommand == null)
                {
                    _addCategoryCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<CategoriesMessenger>(this, (r, m) =>
                        {
                            m.Reply(categories);
                        });
                        dialogService.showAsync(typeof(AddCategoryDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<CategoriesMessenger>(this);
                    });
                }
                return _addCategoryCommand;
            }
        }

        // Add New Transaction
        private RelayCommand _addTransactionCommnand;
        public RelayCommand AddTransactionCommnand
        {
            get
            {
                if(_addTransactionCommnand == null)
                {
                    _addTransactionCommnand = new RelayCommand(() =>
                    {
                        Transaction transaction = new Transaction();
                        transaction.Name = String.IsNullOrEmpty(NameTransaction) ? "Transaction..." : NameTransaction;
                        transaction.Id_Budget = budget.Id;
                        transaction.Money = MoneyTransaction;
                        transaction.Id_Category = CurrencyTransaction.Id;
                        transaction.Note = NoteTransaction;
                        transaction.Create_On = Create_OnTransaction;
                        DB.addNewTransaction(transaction);
                        if (budget.Transactions.Count == 0)
                        {
                            budget.Transactions = new ObservableCollection<Transaction>();
                        }
                        budget.Transactions.Add(transaction);
                        for (int i = 0; i < budgets.Count; i++)
                        {
                            if (budgets[i].Id == budget.Id)
                            {
                                budgets[i] = budget;
                                break;
                            }
                        }
                    })
                    {

                    };
                }
                return _addTransactionCommnand;
            }
        }
        #endregion
    }
}
