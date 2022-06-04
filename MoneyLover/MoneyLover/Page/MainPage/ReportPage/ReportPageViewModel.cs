using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
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

        }

        private RelayCommand _testCommand;
        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(Test));

        private void Test()
        {
            Debug.WriteLine("Called");
        }
    }
}
