using FocusTask.Model;
using FocusTask.Models;
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
using static FocusTask.Messenger.Messenger;

namespace FocusTask.ViewModel
{
    public class AddDialogViewModel : ServiceObservableObject
    {
        public AddDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = WeakReferenceMessenger.Default.Send<ProjectsMessage>().Response;
            Name = "";
            colorModels = new ObservableCollection<ColorModel>();
            for (int i = 1; i <= 20; i++)
            {
                if (i < 10)
                    colorModels.Add(new ColorModel("color0" + i));
                else
                    colorModels.Add(new ColorModel("color" + i));
            }
            SelectedColor = new ColorModel();
        }


        // Variable
        private string _name;
        public string Name { get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public ObservableCollection<ColorModel> colorModels { get; set; }
        private ColorModel _selectedColor;
        public ColorModel SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; }
        }
        public ObservableCollection<ProjectModel> projectModels { get; set; }


        // RelayCommand
        private RelayCommand _addProject;
        public RelayCommand AddProject
        {
            get
            {
                if( _addProject == null )
                {
                    _addProject = new RelayCommand(() =>
                    {
                        ProjectModel projectModel = new ProjectModel()
                        {
                            name = String.IsNullOrEmpty(Name) ? "Project " + Database.getAllProject().Count : Name,
                            color = SelectedColor.color
                        };
                        projectModels.Add(projectModel);
                    });
                }
                return _addProject;
            }
        }
    }
}
