using ExpenseManagement.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Mvvm.Core.Helper;
using UWP.Mvvm.Core.Service;

namespace ExpenseManagement.ViewModel
{
    public class ListTransactionPageViewModel : ServiceObservableObject
    {
        public ListTransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public ObservableCollection<Transaction> transactions { get; set; }
    }
}
