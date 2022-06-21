using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace ExpenseManagement.ViewModel
{
    public class TransactionPageViewModel : ViewModelBase
    {
        public TransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Spendings = new ObservableCollection<Spending>();

            GetUpBeforeAdd();

            ListSort = new ObservableCollection<string>()
            {
                "Sort by Name",
                "Sort by Date"
            };
            ListFilter = new ObservableCollection<string>()
            {
                "Icome",
                "Expense"
            };

            IsPremium = StoreHelper.Default.IsPremium;
            Quantity = StoreHelper.Default.Balance;
        }

        public bool IsPremium { get; set; }
        public uint Quantity { get; set; }

        public void GetCategory()
        {
            Spendings = Transaction.Spendings;
            if (Spendings.Count > 0)
            {
                HasItem = "Visible";
                NotItem = "Collapsed";

                ObjectSpendings = new ObservableCollection<ObjectSpending>();
                foreach (Spending spending in Spendings)
                {
                    Category category = spending.Category;
                    string iconCategory = category.Icon;
                    string nameCategory = category.Name;
                    string colorStatus = spending.Status ? "Expense" : "Income";
                    ObjectSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                }
                OnPropertyChanged(nameof(ObjectSpendings));
            }
            else
            {
                HasItem = "Collapsed";
                NotItem = "Visible";
            }

            OnPropertyChanged(nameof(HasItem));
            OnPropertyChanged(nameof(NotItem));
        }

        public void GetSort()
        {
            if (SelectedSort == "Sort by Name")
            {
                ObjectSpendings = new ObservableCollection<ObjectSpending>(ObjectSpendings.OrderBy(objectSpending => objectSpending.Spending.Name));
            }
            else
            {
                ObjectSpendings = new ObservableCollection<ObjectSpending>(ObjectSpendings.OrderBy(objectSpending => objectSpending.Spending.CreatedOn));
            }
            OnPropertyChanged(nameof(ObjectSpendings));
        }
        public void GetFilter()
        {
            if (SelectedFilter == "Expense")
            {
                ObjectSpendings = new ObservableCollection<ObjectSpending>(ObjectSpendings.Where(objectSpending => objectSpending.Spending.Status.Equals(true)));
            }
            else
            {
                ObjectSpendings = new ObservableCollection<ObjectSpending>(ObjectSpendings.Where(objectSpending => objectSpending.Spending.Status.Equals(false)));
            }
            OnPropertyChanged(nameof(ObjectSpendings));
        }

        private void GetUpBeforeAdd()
        {
            NameSpending = "";
            CreatedOn = DateTimeOffset.Now;
            Money = 0;
            Income = true;
            Expense = false;
            Categories = dataService.GetCategories();
            SelectedCategory = Categories[0];
            Note = "";
        }

        public Transaction Transaction { get; set; }
        public ObservableCollection<Spending> Spendings { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<ObjectSpending> ObjectSpendings { get; set; }
        public ObjectSpending SelectedSpending { get; set; }
        public ObservableCollection<string> ListSort { get; set; }
        public string SelectedSort { get; set; }
        public ObservableCollection<string> ListFilter { get; set; }
        public string SelectedFilter { get; set; }

        public string NameSpending { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Double Money { get; set; }
        public Boolean Income { get; set; }
        public Boolean Expense { get; set; }
        public Category SelectedCategory { get; set; }
        public string Note { get; set; }

        public string EditName { get; set; }
        public DateTimeOffset EditCreate { get; set; }
        public Double EditMoney { get; set; }
        public Boolean EditIncome { get; set; }
        public Boolean EditExpense { get; set; }
        public Category EditSelectCate { get; set; }
        public string EditNote { get; set; }

        public string HasItem { get; set; }
        public string NotItem { get; set; }

        private RelayCommand _changedDateCommand;
        public RelayCommand ChangedDateCommand => _changedDateCommand ?? (_changedDateCommand = new RelayCommand(() =>
        {
            OnPropertyChanged(nameof(CreatedOn));
        }));

        private RelayCommand _addSpendingCommand;
        public RelayCommand AddSpendingCommand => _addSpendingCommand ?? (_addSpendingCommand = new RelayCommand(async () =>
        {
            if (IsPremium)
            {
                AddSpending();
                return;
            }

            if (Quantity > 0)
            {
                StoreHelper.Default.FulfillConsumable();

                AddSpending();
                return;
            }

            await dialogService.showAsync(typeof(WaitingDialogViewModel));
            AddSpending();
        }));

        private void AddSpending()
        {
            Spending spending = new Spending
            {
                Transaction = Transaction,
                Name = String.IsNullOrEmpty(NameSpending) ? "NameSpending..." : NameSpending,
                CreatedOn = CreatedOn,
                Money = Money > 0 ? Money : 0,
                Status = !Income,
                CategoryId = SelectedCategory.Id,
                Category = SelectedCategory,
                Note = String.IsNullOrEmpty(Note) ? "NoteSpending..." : Note
            };

            dataService.AddNewSpending(spending);
            GetCategory();
            GetSort();
        }

        private RelayCommand _spendingSelectedChangedCommand;
        public RelayCommand SpendingSelectedChangedCommand => _spendingSelectedChangedCommand ?? (_spendingSelectedChangedCommand = new RelayCommand(() =>
        {
            if (SelectedSpending != null)
            {
                EditName = SelectedSpending.Spending.Name;
                OnPropertyChanged(nameof(EditName));

                EditCreate = SelectedSpending.Spending.CreatedOn;
                OnPropertyChanged(nameof(EditCreate));

                EditMoney = SelectedSpending.Spending.Money;
                OnPropertyChanged(nameof(EditMoney));

                if (SelectedSpending.Spending.Status)
                {
                    EditIncome = false;
                    EditExpense = true;
                }
                else
                {
                    EditExpense = false;
                    EditIncome = true;
                }
                OnPropertyChanged(nameof(EditIncome));
                OnPropertyChanged(nameof(EditExpense));

                EditSelectCate = SelectedSpending.Spending.Category;
                OnPropertyChanged(nameof(EditSelectCate));

                EditNote = SelectedSpending.Spending.Note;
                OnPropertyChanged(nameof(EditNote));
            }
            OnPropertyChanged(nameof(SelectedSpending));
        }));

        private RelayCommand _editSpendingCommand;
        public RelayCommand EditSpendingCommand => _editSpendingCommand ?? (_editSpendingCommand = new RelayCommand(() =>
        {
            Spending spending = new Spending
            {
                Id = SelectedSpending.Spending.Id,
                Transaction = Transaction,
                Name = String.IsNullOrEmpty(EditName) ? "NameSpending..." : EditName,
                Money = EditMoney > 0 ? EditMoney : 0,
                Status = !EditIncome,
                CategoryId = EditSelectCate.Id,
                Category = EditSelectCate,
                Note = String.IsNullOrEmpty(EditNote) ? "NoteSpending..." : EditNote
            };

            dataService.UpdateSpendingById(spending, spending.Id);

            for (int i = 0; i < Spendings.Count; i++)
            {
                if (Spendings[i].Id == spending.Id)
                {
                    Spendings[i] = spending;
                    break;
                }
            }
            OnPropertyChanged(nameof(Spendings));
            GetCategory();
            GetSort();
        }));

        private RelayCommand<ObjectSpending> _deleteSpendingCommand;
        public RelayCommand<ObjectSpending> DeleteSpendingCommand => _deleteSpendingCommand ?? (_deleteSpendingCommand = new RelayCommand<ObjectSpending>((selectedObjectSpending) =>
        {
            Spending selectedSpending = selectedObjectSpending.Spending;
            dataService.DeleteSpending(selectedSpending);
            ObjectSpendings.Remove(selectedObjectSpending);
            GetCategory();
            GetSort();
        }));

        private RelayCommand _sortChangedCommand;
        public RelayCommand SortChangedCommand => _sortChangedCommand ?? (_sortChangedCommand = new RelayCommand(() =>
        {
            if (SelectedSort != null)
            {
                GetCategory();
                GetSort();
            }
        }));

        private RelayCommand _filterChangedCommand;
        public RelayCommand FilterChangedCommand => _filterChangedCommand ?? (_filterChangedCommand = new RelayCommand(() =>
        {
            if (SelectedFilter != null)
            {
                GetCategory();
                GetFilter();
            }
        }));
    }
}
