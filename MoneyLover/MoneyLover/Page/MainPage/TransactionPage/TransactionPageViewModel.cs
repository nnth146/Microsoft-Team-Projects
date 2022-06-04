using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace MoneyLover.ViewModel
{
    public class TransactionPageViewModel : ViewModelBase
    {
        public TransactionPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Vs = new ObservableGroupedCollection<string, string>(VsList.GroupBy(x => x));
        }

        public ObservableGroupedCollection<string, string> Vs { get; set; }
        public List<string> VsList { get; set; } = new List<string>
        {
            "Key",
            "Value",
        };
    }
}
