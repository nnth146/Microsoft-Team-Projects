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
    public class MainPageViewMode : ServiceObservableObject
    {
        public MainPageViewMode(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = Database.getAllProject();
            projectModels.CollectionChanged += ProjectModels_CollectionChanged;
            if (projectCount == 0)
            {
                projectModels.Add(new ProjectModel());
            }

            int hour = DateTimeOffset.Now.LocalDateTime.Hour;
            int minute = DateTimeOffset.Now.LocalDateTime.Minute;
            int second = DateTimeOffset.Now.LocalDateTime.Second;
            DateTimeOffset dateStart = DateTimeOffset.Now.AddHours(-hour + 1).AddMinutes(-minute).AddSeconds(-second);
            DateTimeOffset dateEnd = DateTimeOffset.Now.AddHours(12-hour).AddMinutes(-minute).AddSeconds(-second);
            Debug.WriteLine("Date : " + dateStart + " -> " + dateEnd);
            myDayTaskCount = Database.getTaskByWhere("due_date BETWEEN '" + dateStart + "' AND '" + dateEnd + "'").Count;
            
            basicItemModels = new ObservableCollection<BasicItemModel>()
            {
                new BasicItemModel("My Day", "ms-appx:///Assets/Icons/myday.png", myDayTaskCount),
                new BasicItemModel("Tomorrow", "ms-appx:///Assets/Icons/tomorrow.png", 0),
                new BasicItemModel("Upcoming", "ms-appx:///Assets/Icons/upcoming.png", 0),
                new BasicItemModel("Someday", "ms-appx:///Assets/Icons/someday.png", 0),
                new BasicItemModel("Completed", "ms-appx:///Assets/Icons/completed.png", 0)
            };
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
        public ObservableCollection<BasicItemModel> basicItemModels { get; set; }
        public int projectCount { get => projectModels.Count; }
        public BasicItemModel selectedBasicItemModel { get; set; }
        public int myDayTaskCount { get; set; }

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

        private RelayCommand<object> _basicItemChangedCommand;
        public RelayCommand<object> BasicItemChangedCommand
        {
            get
            {
                if(_basicItemChangedCommand == null)
                {
                    _basicItemChangedCommand = new RelayCommand<object>((frame) =>
                    {
                        if(selectedBasicItemModel != null)
                        {
                            if(selectedBasicItemModel.Name == "My Day")
                                navigationService.Navigate(frame, typeof(MydayPageViewModel), myDayTaskCount);
                        }
                    });
                }
                return _basicItemChangedCommand;
            }
        }
    }
}
