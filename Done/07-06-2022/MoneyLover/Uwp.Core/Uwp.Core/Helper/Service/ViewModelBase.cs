using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Service;

namespace Uwp.Core.Helper
{
    public abstract class ViewModelBase : ObservableObject
    {
        public IDataService dataService;
        public INavigationService navigationService;
        public IDialogService dialogService;
        public IMessenger messengerService;

        public ViewModelBase(
            IDataService dataService, 
            INavigationService navigationService, 
            IDialogService dialogService, 
            IMessenger messengerService
            ) => (this.dataService, this.navigationService, this.dialogService, this.messengerService)
            = (dataService, navigationService, dialogService, messengerService);
    }
}
