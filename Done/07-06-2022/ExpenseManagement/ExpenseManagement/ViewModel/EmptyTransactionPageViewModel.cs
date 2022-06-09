using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Service;
using Uwp.Core.Helper;

namespace ExpenseManagement.ViewModel
{
    public class EmptyTransactionPageViewModel : ViewModelBase
    {
        public EmptyTransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }
    }
}
