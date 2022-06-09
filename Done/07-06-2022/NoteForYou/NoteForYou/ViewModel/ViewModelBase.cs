using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public abstract class ViewModelBase : ServiceObservableObject
    {
        public ViewModelBase(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            this.InitializeComponent();
        }

        public abstract void InitializeComponent();
    }
}
