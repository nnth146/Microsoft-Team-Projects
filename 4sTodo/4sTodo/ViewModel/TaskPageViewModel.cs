using _4sTodo.Model;
using _4sTodo.View.Dialog;
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
using Uwp.Messenger;
using Windows.UI.Xaml.Controls;

namespace _4sTodo.ViewModel
{
    public class TaskPageViewModel : ViewModelBase
    {
        public TaskPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            
        }


        private RelayCommand _openDeleteDialogCommand;
        public RelayCommand OpenDeleteDialogCommand => _openDeleteDialogCommand ?? (_openDeleteDialogCommand = new RelayCommand(async () =>
        {
            ContentDialog dialog = new DeleteDialog();
            await dialog.ShowAsync();
        }));

        private RelayCommand _navigateToSubTask;
        public RelayCommand NavigateToSubTask => _navigateToSubTask ?? (_navigateToSubTask = new RelayCommand(() =>
        {
            var frame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
            navigationService.Navigate(frame, typeof(SubTaskPageViewModel), NavigationTransactionInfoHelper.DrillInTransition);
        }));

        

        private RelayCommand _goBack;
        public RelayCommand GoBack => _goBack ?? (_goBack = new RelayCommand(() =>
        {
            var frame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
            navigationService.Navigate(frame, typeof(HomePageViewModel), NavigationTransactionInfoHelper.DrillInTransition);
        }));
    }
}
