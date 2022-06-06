using FocusTask.Messenger;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace FocusTask.ViewModel
{
    public class AddDialogViewModel : ViewModelBase
    {
        public AddDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            SetupColors();
            SelectedColor = Colors[0];

            Projects = messengerService.Send<ProjectsRequestMessage>().Response;
        }

        public ObservableCollection<Project> Projects { get; set; }

        public List<string> Colors { get; set; } = new List<string>();
        public string SelectedColor { get; set; }

        private void SetupColors()
        {
            for(int i=1; i < 21; i++)
            {
                if (i < 10)
                {
                    Colors.Add("Color0" + i);
                }
                else
                {
                    Colors.Add("Color" + i);
                }
                
            }
        }

        public string ProjectName { get; set; }

        private RelayCommand _primaryButtonCommand;
        public RelayCommand PrimaryButtonCommand => _primaryButtonCommand ?? (_primaryButtonCommand = new RelayCommand(() =>
        {
            Project addedProject = new Project
            {
                Name = string.IsNullOrEmpty(ProjectName) ? "New Project" : ProjectName,
                Color = SelectedColor,
            };
            Projects.Add(addedProject);

            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _secondaryButtonCommand;
        public RelayCommand SecondaryButtonCommand => _secondaryButtonCommand ?? (_secondaryButtonCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
