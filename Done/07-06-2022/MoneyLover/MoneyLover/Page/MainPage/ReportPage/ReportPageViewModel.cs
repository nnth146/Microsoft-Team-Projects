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
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = DB.getBudgetByWhere("");
            isButton = false;
        }

        public ObservableCollection<Budget> budgets { get; set; }
        public Budget selectedBudget { get; set; }
        public Boolean isButton { get; set; }

        private RelayCommand<object> _naviMonthlyCommand;
        public RelayCommand<object> NaviMonthlyCommand
        {
            get
            {
                if(_naviMonthlyCommand == null)
                {
                    _naviMonthlyCommand = new RelayCommand<object>((frame) =>
                    {
                        if(selectedBudget != null)
                        {
                            isButton = false;
                            navigationReport(isButton, frame, selectedBudget);
                        }
                    });
                }
                return _naviMonthlyCommand;
            }
        }

        private RelayCommand<object> _naviYearCommand;
        public RelayCommand<object> NaviYearCommand
        {
            get
            {
                if (_naviYearCommand == null)
                {
                    _naviYearCommand = new RelayCommand<object>((frame) =>
                    {
                        if(selectedBudget != null)
                        {
                            isButton = true;
                            navigationReport(isButton, frame, selectedBudget);
                        }
                    });
                }
                return _naviYearCommand;
            }
        }

        public void navigationReport(Boolean isCheck, object frame, Budget budget)
        {
            if (isCheck)
            {
                navigationService.Navigate(frame, typeof(AnnualPageViewModel), budget);
            } else
            {
                navigationService.Navigate(frame, typeof(MonthlyPageViewModel), budget);
            }
        }

        private RelayCommand<object> _budgetChangedCommand;
        public RelayCommand<object> BudgetChangedCommand
        {
            get
            {
                if (_budgetChangedCommand == null)
                {
                    _budgetChangedCommand = new RelayCommand<object>((frame) =>
                    {
                        if (selectedBudget != null)
                        {
                            navigationReport(isButton, frame, selectedBudget);
                        }
                    });
                }
                return _budgetChangedCommand;
            }
        }
    }
}
