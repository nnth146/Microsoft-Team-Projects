using _4sTodo.Model;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Windows.UI.Xaml.Controls;

namespace _4sTodo.ViewModel
{
    public class AddTaskDialogViewModel : ViewModelBase
    {
        public AddTaskDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {

        }

        public TagOfWork TagOfWork { get; set; } = new TagOfWork();
        public ListPlaceToSave ListPlaceToSave { get; set; } = new ListPlaceToSave();

        private RelayCommand<ContentDialog> _cancelCommand;
        public RelayCommand<ContentDialog> CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<ContentDialog>((dialog) =>
        {
            dialog.Hide();
        }));
    }
}
