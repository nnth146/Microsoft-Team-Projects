using Fluent.Icons;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class MainPageViewModel : ServiceObservableObject
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            
        }

        private RelayCommand _giveMeAGiftCommand;
        public RelayCommand GiveMeAGiftCommand => _giveMeAGiftCommand ?? (_giveMeAGiftCommand = new RelayCommand(() =>
        {
            dialogService.showAsync(typeof(GiftDialogViewModel));
        }));
    }
}
