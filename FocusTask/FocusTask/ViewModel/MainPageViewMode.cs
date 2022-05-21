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
    public class MainPageViewMode : ServiceObservableObject
    {
        public MainPageViewMode(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = Database.getAllProject();
            projectModels.CollectionChanged += ProjectModels_CollectionChanged;
        }

        // CollectionChanged
        private void ProjectModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Database.addNewProject(e.NewItems[0] as ProjectModel);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                ProjectModel projectModel = (ProjectModel)e.NewItems[0];
                Database.updateProjectByID(projectModel, projectModel.id);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                ProjectModel projectModel = (ProjectModel)e.OldItems[0];
                Database.deleteProjectByID(projectModel.id);
            }
            OnPropertyChanged(nameof(projectCount));
        }
        
        // Variable
        public ObservableCollection<ProjectModel> projectModels { get; set; }
        public int projectCount { get => projectModels.Count; }


        // RelayCommand
        private RelayCommand _addProjectCommand;
        public RelayCommand AddProjectCommand
        {
            get
            {
                if(_addProjectCommand == null )
                {
                    _addProjectCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<ProjectsMessage>(this, (r, m) =>
                        {
                            m.Reply(projectModels);
                        });
                        dialogService.showAsync(typeof(AddDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<ProjectsMessage>(this);
                    });
                }
                return _addProjectCommand;
            }
        }

        private RelayCommand<ProjectModel> _editProjectCommand;
        public RelayCommand<ProjectModel> EditProjectCommand
        {
            get
            {
                if (_editProjectCommand == null)
                {
                    _editProjectCommand = new RelayCommand<ProjectModel>((selectedProject) =>
                    {
                        WeakReferenceMessenger.Default.Register<ProjectsMessage>(this, (r, m) =>
                        {
                            m.Reply(projectModels);
                        });
                        WeakReferenceMessenger.Default.Register<ProjectMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedProject);
                        });
                        dialogService.showAsync(typeof(EditDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<ProjectsMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<ProjectMessage>(this);
                    });
                }
                return _editProjectCommand;
            }
        }

        private RelayCommand<ProjectModel> _deleteProjectCommand;
        public RelayCommand<ProjectModel> DeleteProjectCommand
        {
            get
            {
                if(_deleteProjectCommand == null) {
                    _deleteProjectCommand = new RelayCommand<ProjectModel>((selectedProject) =>
                    {
                        WeakReferenceMessenger.Default.Register<ProjectsMessage>(this, (r, m) =>
                        {
                            m.Reply(projectModels);
                        });
                        WeakReferenceMessenger.Default.Register<ProjectMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedProject);
                        });
                        dialogService.showAsync(typeof(DeleteDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<ProjectsMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<ProjectMessage>(this);
                    });
                }
                return _deleteProjectCommand;
            }
        }
    }
}
