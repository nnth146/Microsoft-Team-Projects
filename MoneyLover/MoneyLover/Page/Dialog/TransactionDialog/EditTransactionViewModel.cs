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
    public class EditTransactionDialogViewModel : ViewModelBase
    {
        public EditTransactionDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = WeakReferenceMessenger.Default.Send<BudgetsMessenger>().Response;
            transaction = WeakReferenceMessenger.Default.Send<TransactionMessenger>().Response;
            getCategory();
            string nameCategory = DB.getCategoryByWhere("where id = " + transaction.Id_Category)[0].Name;
            foreach(Category category in categories)
            {
                if (category.Name == nameCategory)
                {
                    selectedCategory = category;
                    break;
                }
            }
            OnPropertyChanged(nameof(selectedCategory));
        }

        private void getCategory()
        {
            categories = DB.getCategoryByWhere("");
            OnPropertyChanged(nameof(categories));
        }

        public Transaction transaction { get; set; }

        public ObservableCollection<Budget> budgets { get; set; }
        public ObservableCollection<Category> categories { get; set; }
        public Category selectedCategory { get; set; }

        // Add New Category
        private RelayCommand _addCategoryCommand;
        public RelayCommand AddCategoryCommand
        {
            get
            {
                if (_addCategoryCommand == null)
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

        // Edit Transaction
        private RelayCommand _editTransactionCommand;
        public RelayCommand EditTransactionCommand
        {
            get
            {
                if (_editTransactionCommand == null)
                {
                    _editTransactionCommand = new RelayCommand(() =>
                    {
                        transaction.Name = String.IsNullOrEmpty(transaction.Name) ? "Transaction..." : transaction.Name;
                        transaction.Id_Category = selectedCategory.Id;
                        DB.updateTransactionById(transaction, transaction.Id);
                        for(int j = 0; j < budgets.Count; j++)
                        {
                            Budget budget = budgets[j];
                            for (int i = 0; i < budget.Transactions.Count; i++)
                            {
                                if (budget.Transactions[i].Id == transaction.Id)
                                {
                                    budget.Transactions[i] = transaction;
                                    budgets[j] = budget;
                                    break;
                                }
                            }
                        }
                    });
                }
                return _editTransactionCommand;
            }
        }
    }
}
