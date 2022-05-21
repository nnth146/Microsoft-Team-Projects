using FocusTask.Models;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;
using static FocusTask.Messenger.Messenger;

namespace FocusTask.ViewModel
{
    public class DeleteDialogViewModel : ServiceObservableObject
    {
        public DeleteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = WeakReferenceMessenger.Default.Send<ProjectsMessage>().Response;
            projectModel = WeakReferenceMessenger.Default.Send<ProjectMessage>().Response;
        }

        public ProjectModel projectModel { get; set; }
        public ObservableCollection<ProjectModel> projectModels { get; set; }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(() =>
                    {
                        projectModels.Remove(projectModel);
                    });
                }
                return _deleteCommand;
            }
        }
    }
}
