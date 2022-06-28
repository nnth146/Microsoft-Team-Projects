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
    public class SubTaskPageViewModel : ViewModelBase
    {
        public SubTaskPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
        }



        private RelayCommand _openAddSubTaskDialogCommand;
        public RelayCommand OpenAddSubTaskDialogCommand => _openAddSubTaskDialogCommand ?? (_openAddSubTaskDialogCommand = new RelayCommand(async () =>
        {
            ContentDialog dialog = new AddSubTaskDialog();
            await dialog.ShowAsync();
        }));

        private RelayCommand _goBack;
        public RelayCommand GoBack => _goBack ?? (_goBack = new RelayCommand(() =>
        {
            var frame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
            navigationService.Navigate(frame, typeof(TaskPageViewModel), NavigationTransactionInfoHelper.DrillInTransition);
        }));
    }
}
