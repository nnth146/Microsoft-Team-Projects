using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Windows.UI.Xaml.Controls;

namespace _4sTodo.ViewModel
{
    public class WattingPageViewModel : ViewModelBase
    {
        public WattingPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            SFrame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
        }

        public Frame SFrame { get; set; }

        private RelayCommand _navigateToHomePageCommand;

        public RelayCommand NavigateHomePageCommand => _navigateToHomePageCommand ?? (_navigateToHomePageCommand = new RelayCommand(() =>
        {
            navigationService.Navigate(SFrame, typeof(HomePageViewModel), NavigationTransactionInfoHelper.DrillInTransition);
        }));
    }
}
