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
    public class EditDialogViewModel : ServiceObservableObject
    {
        public EditDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            colorModels = new ObservableCollection<ColorModel>();
            for (int i = 1; i <= 20; i++)
            {
                if (i < 10)
                    colorModels.Add(new ColorModel("color0" + i));
                else
                    colorModels.Add(new ColorModel("color" + i));
            }
            projectModels = WeakReferenceMessenger.Default.Send<ProjectsMessage>().Response;
            projectModel = WeakReferenceMessenger.Default.Send<ProjectMessage>().Response;
            Id = projectModel.id;
            Name = projectModel.name;
            SelectedColor = new ColorModel(projectModel.color);
        }

        // Variable
        public ProjectModel projectModel { get; set; }
        public ObservableCollection<ProjectModel> projectModels { get; set; }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public ObservableCollection<ColorModel> colorModels { get; set; }
        private ColorModel _selectedColor;
        public ColorModel SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; }
        }

        // RelayCommand
        private RelayCommand _editProject;
        public RelayCommand EditProject
        {
            get
            {
                if (_editProject == null)
                {
                    _editProject = new RelayCommand(() =>
                    {
                        projectModel.name = String.IsNullOrEmpty(Name) ? ("Project " + Id) : Name;
                        projectModel.color = SelectedColor.color;
                        for (int i = 0; i < projectModels.Count; i++)
                        {
                            if (projectModels[i].id == Id)
                                projectModels[i] = projectModel;
                        }
                    });
                }
                return _editProject;
            }
        }
    }
}
