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

namespace MoneyLover.ViewModel
{
    public class AnnualPageViewModel : ViewModelBase
    {
        public AnnualPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            dateNow = DateTimeOffset.Now.LocalDateTime;
            updateData();
        }

        private void updateData()
        {
            transactions = DB.getTransactionByWhere("");

            string year = dateNow.Year.ToString();
            Double total = 0;

            textDate = year;
            OnPropertyChanged(nameof(textDate));
            getTransactions = new ObservableCollection<Transaction>();
            foreach (Transaction transaction in transactions)
            {
                string y = transaction.Create_On.Year.ToString();
                if (y == year)
                {
                    getTransactions.Add(transaction);
                    total += transaction.Money;
                }
            }

            objectTransaction = new ObservableCollection<object>();
            foreach (Transaction tra in getTransactions)
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

        private RelayCommand _nextYearCommand;
        public RelayCommand NextYearCommand
        {
            get
            {
                if (_nextYearCommand == null)
                {
                    _nextYearCommand = new RelayCommand(() =>
                    {
                        dateNow = dateNow.AddYears(+1);
                        updateData();
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
                        dateNow = dateNow.AddYears(-1);
                        updateData();
                    });
                }
                return _prevYearCommand;
            }
        }
    }
}
