using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Mvvm.Core.Service;

namespace UWP.Mvvm.Core.Helper
{
    public abstract class ServiceObservableObject : ObservableObject
    {
        public IDataService dataService;
        public INavigationService navigationService;
        public IDialogService dialogService;
        public IMessenger messengerService;

        public ServiceObservableObject(
            IDataService dataService, 
            INavigationService navigationService, 
            IDialogService dialogService, 
            IMessenger messengerService
            ) => (this.dataService, this.navigationService, this.dialogService, this.messengerService)
            = (dataService, navigationService, dialogService, messengerService);
    }
}
