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
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            monthly = DateTimeOffset.Now;
            year = DateTimeOffset.Now;
            getSpendingMonth();
        }

        private void setup()
        {
            spendings = Database.getSpendingByWhere("");

            getSpendings = new ObservableCollection<Spending>();
            getIncomeSpendings = new ObservableCollection<Spending>();
            mergeIncomeSpendings = new ObservableCollection<Spending>();
            getExpenseSpendings = new ObservableCollection<Spending>();

            objectExpenseSpendings = new ObservableCollection<ObjectSpending>();
            objectIcomeSpendings = new ObservableCollection<ObjectSpending>();
        }

        private void getData()
        {
            moneyIncome = 0;
            moneyExpense = 0;

            foreach (Spending spending in getIncomeSpendings)
            {
                Category category = Database.getCategoryByWhere("where id = " + spending.Id_Category)[0];
                string iconCategory = category.Icon;
                string nameCategory = category.Name;
                string colorStatus = spending.Status ? "Expense" : "Income";
                objectIcomeSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                moneyIncome += spending.Money;
            }
            OnPropertyChanged(nameof(objectIcomeSpendings));

            foreach (Spending spending in getExpenseSpendings)
            {
                Category category = Database.getCategoryByWhere("where id = " + spending.Id_Category)[0];
                string iconCategory = category.Icon;
                string nameCategory = category.Name;
                string colorStatus = spending.Status ? "Expense" : "Income";
                objectExpenseSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                moneyExpense += spending.Money;
            }
            OnPropertyChanged(nameof(objectExpenseSpendings));

            minus = "";
            moneyReturn = moneyIncome - moneyExpense;
            if (moneyReturn < 0)
            {
                minus = "-";
                moneyReturn = -moneyReturn;
            }

            OnPropertyChanged(nameof(moneyIncome));
            OnPropertyChanged(nameof(moneyExpense));
            OnPropertyChanged(nameof(moneyReturn));
            OnPropertyChanged(nameof(minus));
        }

        public void getSpendingMonth()
        {
            setup();

            textMonthly = monthly.Month.ToString() + "/" + monthly.Year.ToString();
            OnPropertyChanged(nameof(textMonthly));

            int mon = monthly.Month;
            int year = monthly.Year;
            foreach (Spending spending in spendings)
            {
                if (spending.Create_On.Month == mon && spending.Create_On.Year == year)
                {
                    getSpendings.Add(spending);
                    if (spending.Status)
                    {
                        getExpenseSpendings.Add(spending);
                    }
                    else
                    {
                        getIncomeSpendings.Add(spending);
                    }
                }
            }

            getData();

            OnPropertyChanged(nameof(getIncomeSpendings));
            OnPropertyChanged(nameof(getExpenseSpendings));
        }

        public void getSpendingYear()
        {
            setup();

            textYear = year.Year.ToString();
            OnPropertyChanged(nameof(textYear));

            int yr = year.Year;
            foreach (Spending spending in spendings)
            {
                if (spending.Create_On.Year == yr)
                {
                    getSpendings.Add(spending);
                    if (spending.Status)
                    {
                        getExpenseSpendings.Add(spending);
                    }
                    else
                    {
                        getIncomeSpendings.Add(spending);
                    }
                }
            }
            getData();

            OnPropertyChanged(nameof(getIncomeSpendings));
            OnPropertyChanged(nameof(getExpenseSpendings));
        }

        // Observable 
        public ObservableCollection<Spending> spendings { get; set; }
        public ObservableCollection<Spending> getSpendings { get; set; }
        public ObservableCollection<Spending> getIncomeSpendings { get; set; }
        public ObservableCollection<Spending> mergeIncomeSpendings { get; set; }
        public ObservableCollection<Spending> getExpenseSpendings { get; set; }

        public ObservableCollection<ObjectSpending> objectIcomeSpendings { get; set; }
        public ObservableCollection<ObjectSpending> objectExpenseSpendings { get; set; }

        // Variable
        public DateTimeOffset monthly { get; set; }
        public string textMonthly { get; set; }
        public DateTimeOffset year { get; set; }
        public string textYear { get; set; }
        public Double moneyIncome { get; set; }
        public Double moneyExpense { get; set; }
        public Double moneyReturn { get; set; }
        public string minus { get; set; }


        // Month Command
        private RelayCommand _monthlyChangedCommand;
        public RelayCommand MonthlyChangedCommand
        {
            get
            {
                if (_monthlyChangedCommand == null)
                {
                    _monthlyChangedCommand = new RelayCommand(() =>
                    {
                        getSpendingMonth();
                    });
                }
                return _monthlyChangedCommand;
            }
        }

        private RelayCommand _nextMonthCommand;
        public RelayCommand NextMonthCommand
        {
            get
            {
                if(_nextMonthCommand == null)
                {
                    _nextMonthCommand = new RelayCommand(() =>
                    {
                        monthly = monthly.AddMonths(+1);
                        getSpendingMonth();
                    });
                }
                return _nextMonthCommand;
            }
        }
        
        private RelayCommand _prevMonthCommand;
        public RelayCommand PrevMonthCommand
        {
            get
            {
                if(_prevMonthCommand == null)
                {
                    _prevMonthCommand = new RelayCommand(() =>
                    {
                        monthly = monthly.AddMonths(-1);
                        getSpendingMonth();
                    });
                }
                return _prevMonthCommand;
            }
        }

        // Year Command
        private RelayCommand _yearChangedCommand;
        public RelayCommand YearChangedCommand
        {
            get
            {
                if (_yearChangedCommand == null)
                {
                    _yearChangedCommand = new RelayCommand(() =>
                    {
                        getSpendingYear();
                    });
                }
                return _yearChangedCommand;
            }
        }

        private RelayCommand _nextYearCommand;
        public RelayCommand NextYearCommand
        {
            get
            {
                if (_nextYearCommand == null)
                {
                    _nextYearCommand = new RelayCommand(() =>
                    {
                        year = year.AddYears(+1);
                        getSpendingYear();
                    });
                }
                return _nextYearCommand;
            }
        }

        private RelayCommand _prevYearCommand;
        public RelayCommand PrevYearCommand
        {
            get
            {
                if (_prevYearCommand == null)
                {
                    _prevYearCommand = new RelayCommand(() =>
                    {
                        year = year.AddYears(-1);
                        getSpendingYear();
                    });
                }
                return _prevYearCommand;
            }
        }
    }
}
