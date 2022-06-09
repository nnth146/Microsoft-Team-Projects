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
using static MoneyLover.Messenger.Messenger;

namespace MoneyLover.ViewModel
{
    public class AddWalletDialogViewModel : ViewModelBase
    {
        public AddWalletDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = WeakReferenceMessenger.Default.Send<BudgetsMessenger>().Response;
            resetValue();
        }

        private void resetValue()
        {
            NameBudget = "";
            MoneyBudget = 0;
            CurrencyBudget = "$";
            Create_OnBudget = DateTimeOffset.Now;
            NoteBudget = "";
        }

        public ObservableCollection<Budget> budgets { get; set; }

        // Variable Add
        public string NameBudget { get; set; }
        public Double MoneyBudget { get; set; }
        public string CurrencyBudget { get; set; }
        public DateTimeOffset Create_OnBudget { get; set; }
        public string NoteBudget { get; set; }

        // Command
        private RelayCommand _addNewBudgetCommand;
        public RelayCommand AddNewBudgetCommand
        {
            get
            {
                if(_addNewBudgetCommand == null)
                {
                    _addNewBudgetCommand = new RelayCommand(() =>
                    {
                        Budget budget = new Budget();
                        budget.Name = String.IsNullOrEmpty(NameBudget) ? "Budget..." : NameBudget;
                        budget.Money = MoneyBudget;
                        budget.Curency = String.IsNullOrEmpty(CurrencyBudget) ? "$" : CurrencyBudget;
                        budget.Create_On = Create_OnBudget;
                        budget.Note = NoteBudget;
                        budgets.Add(budget);
                    });
                }
                return _addNewBudgetCommand;
            }
        }
    }
}
