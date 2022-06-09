using ExpenseManagement.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace ExpenseManagement.ViewModel
{
    public class TransactionPageViewModel : ViewModelBase
    {
        public TransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            spendings = new ObservableCollection<Spending>();
            setUpBeforeAdd();
            listSort = new ObservableCollection<string>()
            {
                "Sort by Name",
                "Sort by Date"
            };
            listFilter = new ObservableCollection<string>()
            {
                "Icome",
                "Expense"
            };
        }

        public void getCategory()
        {
            spendings = Database.getSpendingByWhere("where id_transaction = " + transaction.Id);
            if (spendings.Count > 0)
            {
                hasItem = "Visible";
                notItem = "Collapsed";

                objectSpendings = new ObservableCollection<ObjectSpending>();
                foreach (Spending spending in spendings)
                {
                    Category category = Database.getCategoryByWhere("where id = " + spending.Id_Category)[0];
                    string iconCategory = category.Icon;
                    string nameCategory = category.Name;
                    string colorStatus = spending.Status ? "Expense" : "Income";
                    objectSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                }
                OnPropertyChanged(nameof(objectSpendings));
            } else
            {
                hasItem = "Collapsed";
                notItem = "Visible";
            }

            OnPropertyChanged(nameof(hasItem));
            OnPropertyChanged(nameof(notItem));
        }

        public void getSort()
        {
            if (selectedSort == "Sort by Name")
            {
                objectSpendings = new ObservableCollection<ObjectSpending>(objectSpendings.OrderBy(objectSpending => objectSpending.Spending.Name));
            }
            else
            {
                objectSpendings = new ObservableCollection<ObjectSpending>(objectSpendings.OrderBy(objectSpending => objectSpending.Spending.Create_On));
            }
            OnPropertyChanged(nameof(objectSpendings));
        }
        public void getFilter()
        {
            if (selectedFilter == "Expense")
            {
                objectSpendings = new ObservableCollection<ObjectSpending>(objectSpendings.Where(objectSpending => objectSpending.Spending.Status.Equals(true)));
            }
            else
            {
                objectSpendings = new ObservableCollection<ObjectSpending>(objectSpendings.Where(objectSpending => objectSpending.Spending.Status.Equals(false)));
            }
            OnPropertyChanged(nameof(objectSpendings));
        }

        private void setUpBeforeAdd()
        {
            NameSpending = "";
            Create_On = DateTimeOffset.Now;
            Money = 0;
            Income = true;
            Expense = false;
            categories = Database.getCategoryByWhere("");
            selectCategory = categories[0];
            Note = "";
        }

        public Transaction transaction { get; set; }
        public ObservableCollection<Spending> spendings { get; set; }
        public ObservableCollection<Category> categories { get; set; }
        public ObservableCollection<ObjectSpending> objectSpendings { get; set; }
        public ObjectSpending selectedSpending { get; set; }
        public ObservableCollection<string> listSort { get; set; }
        public string selectedSort { get; set; }
        public ObservableCollection<string> listFilter { get; set; }
        public string selectedFilter { get; set; }

        // Add spending
        public string NameSpending { get; set; }
        public DateTimeOffset Create_On { get; set; }
        public Double Money {  get; set; }
        public Boolean Income { get; set; }
        public Boolean Expense { get; set; }
        public Category selectCategory { get; set; }
        public string Note { get; set; }

        // Edit spending
        public string EditName { get; set; }
        public DateTimeOffset EditCreate { get; set; }
        public Double EditMoney { get; set; }
        public Boolean EditIncome { get; set; }
        public Boolean EditExpense { get; set; }
        public Category EditSelectCate { get; set; }
        public string EditNote { get; set; }

        // Item visibility
        public string hasItem { get; set; }
        public string notItem { get; set; }

        // RelayCommand
        private RelayCommand _changedDateCommand;
        public RelayCommand ChangedDateCommand
        {
            get
            {
                if(_changedDateCommand == null)
                {
                    _changedDateCommand = new RelayCommand(() =>
                    {
                        OnPropertyChanged(nameof(Create_On));
                    });
                }
                return _changedDateCommand;
            }
        }

        private RelayCommand _addSpendingCommand;
        public RelayCommand AddSpendingCommand
        {
            get
            {
                if(_addSpendingCommand == null)
                {
                    _addSpendingCommand = new RelayCommand(() =>
                    {
                        Spending spending = new Spending();
                        spending.Id_Transaction = transaction.Id;
                        spending.Name = String.IsNullOrEmpty(NameSpending) ? "NameSpending..." : NameSpending;
                        spending.Create_On = Create_On;
                        spending.Money = Money > 0 ? Money : 0;
                        if(Income) spending.Status = false;
                        else spending.Status = true;
                        spending.Id_Category = selectCategory.Id;
                        spending.Note = String.IsNullOrEmpty(Note) ? "NoteSpending..." : Note;
                        Database.addNewSpending(spending);
                        spendings.Add(spending);
                        getCategory();
                        getSort();
                    });
                }
                return _addSpendingCommand;
            }
        }

        private RelayCommand _spendingSelectedChangedCommand;
        public RelayCommand SpendingSelectedChangedCommand
        {
            get
            {
                if(_spendingSelectedChangedCommand == null)
                {
                    _spendingSelectedChangedCommand = new RelayCommand(() =>
                    {
                        if(selectedSpending != null)
                        {
                            EditName = selectedSpending.Spending.Name;
                            OnPropertyChanged(nameof(EditName));

                            EditCreate = selectedSpending.Spending.Create_On;
                            OnPropertyChanged(nameof(EditCreate));

                            EditMoney = selectedSpending.Spending.Money;
                            OnPropertyChanged(nameof(EditMoney));

                            if(selectedSpending.Spending.Status)
                            {
                                EditIncome = false;
                                EditExpense = true;
                            } else
                            {
                                EditExpense= false;
                                EditIncome = true;
                            }
                            OnPropertyChanged(nameof(EditIncome));
                            OnPropertyChanged(nameof(EditExpense));

                            EditSelectCate = Database.getCategoryByWhere("where id = " + selectedSpending.Spending.Id_Category)[0];
                            OnPropertyChanged(nameof(EditSelectCate));

                            EditNote = selectedSpending.Spending.Note;
                            OnPropertyChanged(nameof(EditNote));
                        }
                        OnPropertyChanged(nameof(selectedSpending));
                    });
                }
                return _spendingSelectedChangedCommand;
            }
        }

        private RelayCommand _editSpendingCommand;
        public RelayCommand EditSpendingCommand
        {
            get
            {
                if(_editSpendingCommand == null)
                {
                    _editSpendingCommand = new RelayCommand(() =>
                    {
                        Spending spending = new Spending();
                        spending.Id = selectedSpending.Spending.Id;
                        spending.Id_Transaction = transaction.Id;
                        spending.Name = String.IsNullOrEmpty(EditName) ? "NameSpending..." : EditName;
                        spending.Money = EditMoney > 0 ? EditMoney : 0;
                        if (EditIncome) spending.Status = false;
                        else spending.Status = true;
                        spending.Id_Category = EditSelectCate.Id;
                        spending.Note = String.IsNullOrEmpty(EditNote) ? "NoteSpending..." : EditNote;
                        Database.updateSpendingById(spending, spending.Id);
                        for (int i = 0; i < spendings.Count; i++)
                        {
                            if (spendings[i].Id == spending.Id)
                            {
                                spendings[i] = spending;
                                break;
                            }
                        }
                        OnPropertyChanged(nameof(spendings));
                        getCategory();
                        getSort();
                    });
                }
                return _editSpendingCommand;
            }
        }

        private RelayCommand<ObjectSpending> _deleteSpendingCommand;
        public RelayCommand<ObjectSpending> DeleteSpendingCommand
        {
            get
            {
                if (_deleteSpendingCommand == null)
                {
                    _deleteSpendingCommand = new RelayCommand<ObjectSpending>((selectedObjectSpending) =>
                    {
                        Spending selectedSpending = selectedObjectSpending.Spending;
                        Database.deleteSpendingById(selectedSpending.Id);
                        objectSpendings.Remove(selectedObjectSpending);
                        getCategory();
                        getSort();
                    });
                }
                return _deleteSpendingCommand;
            }
        }

        private RelayCommand _sortChangedCommand;
        public RelayCommand SortChangedCommand
        {
            get
            {
                if (_sortChangedCommand == null)
                {
                    _sortChangedCommand = new RelayCommand(() =>
                    {
                        if(selectedSort != null)
                        {
                            getCategory();
                            getSort();
                        }
                    });
                }
                return _sortChangedCommand;
            }
        }
        private RelayCommand _filterChangedCommand;
        public RelayCommand FilterChangedCommand
        {
            get
            {
                if (_filterChangedCommand == null)
                {
                    _filterChangedCommand = new RelayCommand(() =>
                    {
                        if (selectedFilter != null)
                        {
                            getCategory();
                            getFilter();
                        }
                    });
                }
                return _filterChangedCommand;
            }
        }
    }
}
