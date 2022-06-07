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
    public class DeleteWalletDialogViewModel : ViewModelBase
    {
        public DeleteWalletDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            budgets = WeakReferenceMessenger.Default.Send<BudgetsMessenger>().Response;
            budget = WeakReferenceMessenger.Default.Send<BudgetMessenger>().Response;
        }

        public ObservableCollection<Budget> budgets { get; set; }
        public Budget budget { get; set; }

        private RelayCommand _deleteBudgetCommand;
        public RelayCommand DeleteBudgetCommand
        {
            get
            {
                if (_deleteBudgetCommand == null)
                {
                    _deleteBudgetCommand = new RelayCommand(() =>
                    {
                        budgets.Remove(budget);
                    });
                }
                return _deleteBudgetCommand;
            }
        }
    }
}
