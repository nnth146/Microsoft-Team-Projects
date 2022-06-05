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

namespace MoneyLover.ViewModel
{
    public class MonthlyPageViewModel : ViewModelBase
    {
        public MonthlyPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            dateNow = DateTime.Now.ToLocalTime();
            updateData();
        }

        private void updateData()
        {
            transactions = DB.getTransactionByWhere("");
            
            string mon = dateNow.Month.ToString();
            string year = dateNow.Year.ToString();
            Double total = 0;

            textDate = mon + "/" + year;
            OnPropertyChanged(nameof(textDate));
            getTransactions = new ObservableCollection<Transaction>();
            foreach (Transaction transaction in transactions)
            {
                string m = transaction.Create_On.Month.ToString();
                string y = transaction.Create_On.Year.ToString();
                if (m == mon && y == year)
                {
                    getTransactions.Add(transaction);
                    total += transaction.Money;
                }
            }

            objectTransaction = new ObservableCollection<object>();
            foreach(Transaction tra in getTransactions)
            {
                object obtransaction = new
                {
                    transaction = tra,
                    icon = DB.getCategoryByWhere("where id = " + tra.Id_Category)[0].Icon,
                    percent = total == 0 ? 100 : ((tra.Money / total) * 100)
                };
                objectTransaction.Add(obtransaction);
            }
            OnPropertyChanged(nameof(objectTransaction));
        }

        public DateTimeOffset dateNow { get; set; }
        public string textDate { get; set; }
        public ObservableCollection<Transaction> transactions { get; set; }
        public ObservableCollection<Transaction> getTransactions { get; set; }
        public ObservableCollection<object> objectTransaction { get; set; }

        private RelayCommand _nextMonthlyCommand;
        public RelayCommand NextMonthlyCommand
        {
            get
            {
                if (_nextMonthlyCommand == null)
                {
                    _nextMonthlyCommand = new RelayCommand(() =>
                    {
                        dateNow = dateNow.AddMonths(+1);
                        updateData();
                    });
                }
                return _nextMonthlyCommand;
            }
        }

        private RelayCommand _prevMonthlyCommand;
        public RelayCommand PrevMonthlyCommand
        {
            get
            {
                if (_prevMonthlyCommand == null)
                {
                    _prevMonthlyCommand = new RelayCommand(() =>
                    {
                        dateNow = dateNow.AddMonths(-1);
                        updateData();
                    });
                }
                return _prevMonthlyCommand;
            }
        }
    }
}
