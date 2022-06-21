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
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Monthly = DateTimeOffset.Now;
            Year = DateTimeOffset.Now;
            GetSpendingMonth();
        }

        private void Setup()
        {
            Spendings = dataService.GetSpendings();

            GetSpendings = new ObservableCollection<Spending>();
            GetIncomeSpendings = new ObservableCollection<Spending>();
            MergeIncomeSpendings = new ObservableCollection<Spending>();
            GetExpenseSpendings = new ObservableCollection<Spending>();

            ObjectExpenseSpendings = new ObservableCollection<ObjectSpending>();
            ObjectIcomeSpendings = new ObservableCollection<ObjectSpending>();
        }

        private void GetData()
        {
            MoneyIncome = 0;
            MoneyExpense = 0;

            foreach (Spending spending in GetIncomeSpendings)
            {
                Category category = spending.Category;
                string iconCategory = category.Icon;
                string nameCategory = category.Name;
                string colorStatus = spending.Status ? "Expense" : "Income";
                ObjectIcomeSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                MoneyIncome += spending.Money;
            }
            OnPropertyChanged(nameof(ObjectIcomeSpendings));

            foreach (Spending spending in GetExpenseSpendings)
            {
                Category category = spending.Category;
                string iconCategory = category.Icon;
                string nameCategory = category.Name;
                string colorStatus = spending.Status ? "Expense" : "Income";
                ObjectExpenseSpendings.Add(new ObjectSpending(spending, iconCategory, nameCategory, colorStatus));
                MoneyExpense += spending.Money;
            }
            OnPropertyChanged(nameof(ObjectExpenseSpendings));

            Minus = "";
            MoneyReturn = MoneyIncome - MoneyExpense;
            if (MoneyReturn < 0)
            {
                Minus = "-";
                MoneyReturn = -MoneyReturn;
            }

            OnPropertyChanged(nameof(MoneyIncome));
            OnPropertyChanged(nameof(MoneyExpense));
            OnPropertyChanged(nameof(MoneyReturn));
            OnPropertyChanged(nameof(Minus));
        }

        public void GetSpendingMonth()
        {
            Setup();

            TextMonthly = Monthly.Month.ToString() + "/" + Monthly.Year.ToString();
            OnPropertyChanged(nameof(TextMonthly));

            int mon = Monthly.Month;
            int year = Monthly.Year;
            foreach (Spending spending in Spendings)
            {
                if (spending.CreatedOn.Month == mon && spending.CreatedOn.Year == year)
                {
                    GetSpendings.Add(spending);
                    if (spending.Status)
                    {
                        GetExpenseSpendings.Add(spending);
                    }
                    else
                    {
                        GetIncomeSpendings.Add(spending);
                    }
                }
            }

            GetData();

            OnPropertyChanged(nameof(GetIncomeSpendings));
            OnPropertyChanged(nameof(GetExpenseSpendings));
        }

        public void GetSpendingYear()
        {
            Setup();

            TextYear = Year.Year.ToString();
            OnPropertyChanged(nameof(TextYear));

            int yr = Year.Year;
            foreach (Spending spending in Spendings)
            {
                if (spending.CreatedOn.Year == yr)
                {
                    GetSpendings.Add(spending);
                    if (spending.Status)
                    {
                        GetExpenseSpendings.Add(spending);
                    }
                    else
                    {
                        GetIncomeSpendings.Add(spending);
                    }
                }
            }
            GetData();

            OnPropertyChanged(nameof(GetIncomeSpendings));
            OnPropertyChanged(nameof(GetExpenseSpendings));
        }

        // Observable 
        public ObservableCollection<Spending> Spendings { get; set; }
        public ObservableCollection<Spending> GetSpendings { get; set; }
        public ObservableCollection<Spending> GetIncomeSpendings { get; set; }
        public ObservableCollection<Spending> MergeIncomeSpendings { get; set; }
        public ObservableCollection<Spending> GetExpenseSpendings { get; set; }

        public ObservableCollection<ObjectSpending> ObjectIcomeSpendings { get; set; }
        public ObservableCollection<ObjectSpending> ObjectExpenseSpendings { get; set; }

        // Variable
        public DateTimeOffset Monthly { get; set; }
        public string TextMonthly { get; set; }
        public DateTimeOffset Year { get; set; }
        public string TextYear { get; set; }
        public Double MoneyIncome { get; set; }
        public Double MoneyExpense { get; set; }
        public Double MoneyReturn { get; set; }
        public string Minus { get; set; }

        private RelayCommand _monthlyChangedCommand;
        public RelayCommand MonthlyChangedCommand => _monthlyChangedCommand ?? (_monthlyChangedCommand = new RelayCommand(() =>
        {
            GetSpendingMonth();
        }));


        private RelayCommand _nextMonthCommand;
        public RelayCommand NextMonthCommand => _nextMonthCommand ?? (_nextMonthCommand = new RelayCommand(() =>
        {
            Monthly = Monthly.AddMonths(+1);
            GetSpendingMonth();
        }));

        private RelayCommand _prevMonthCommand;
        public RelayCommand PrevMonthCommand => _prevMonthCommand ?? (_prevMonthCommand = new RelayCommand(() =>
        {
            Monthly = Monthly.AddMonths(-1);
            GetSpendingMonth();
        }));

        private RelayCommand _yearChangedCommand;
        public RelayCommand YearChangedCommand => _yearChangedCommand ?? (_yearChangedCommand = new RelayCommand(() =>
        {
            GetSpendingYear();
        }));

        private RelayCommand _nextYearCommand;
        public RelayCommand NextYearCommand => _nextYearCommand ?? (_nextYearCommand = new RelayCommand(() =>
        {
            Year = Year.AddYears(+1);
            GetSpendingYear();
        }));

        private RelayCommand _prevYearCommand;
        public RelayCommand PrevYearCommand => _prevYearCommand ?? (_prevYearCommand = new RelayCommand(() =>
        {
            Year = Year.AddYears(-1);
            GetSpendingYear();
        }));
    }
}
