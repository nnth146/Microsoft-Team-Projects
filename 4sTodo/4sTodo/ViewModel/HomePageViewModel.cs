using _4sTodo.Model;
using _4sTodo.View.Dialog;
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
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {

        }


        private RelayCommand _openAddTaskDialogCommand;
        public RelayCommand OpenAddTaskDialogCommand => _openAddTaskDialogCommand ?? (_openAddTaskDialogCommand = new RelayCommand(async () =>
        {
            ContentDialog dialog = new AddTaskDialog();
            await dialog.ShowAsync();
        }));

        private RelayCommand _navigateToTaskPage;

        public RelayCommand NavigationToTaskPage => _navigateToTaskPage ?? (_navigateToTaskPage = new RelayCommand(() =>
        {
            var frame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
            navigationService.Navigate(frame,typeof(TaskPageViewModel), NavigationTransactionInfoHelper.DrillInTransition);
        }));
    }
}
