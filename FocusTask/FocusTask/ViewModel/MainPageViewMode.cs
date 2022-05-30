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

            getData();
        }

        private void getData()
        {
            taskModels = Database.getAllTask();

            int hour = DateTimeOffset.Now.LocalDateTime.Hour;
            int minute = DateTimeOffset.Now.LocalDateTime.Minute;
            int second = DateTimeOffset.Now.LocalDateTime.Second;
            DateTimeOffset mydayStart = DateTimeOffset.Now.AddHours(-hour + 1).AddMinutes(-minute).AddSeconds(-second);
            DateTimeOffset mydayEnd = DateTimeOffset.Now.AddHours(12 - hour).AddMinutes(-minute).AddSeconds(-second);

            DateTimeOffset tomorrowStart = mydayStart.AddDays(+1);
            DateTimeOffset tomorrowEnd = mydayEnd.AddDays(+1);

            DateTimeOffset upcomingStart = mydayStart.AddDays(+7);
            DateTimeOffset upcomingEnd = mydayEnd.AddDays(+7);

            DateTimeOffset somedayStart = DateTimeOffset.Now.AddHours(-hour + 1).AddMinutes(-minute).AddSeconds(-second);
            DateTimeOffset somedayEnd = DateTimeOffset.Now.AddHours(12 - hour).AddMinutes(-minute).AddSeconds(-second);

            myDayTasks = new ObservableCollection<TaskModel>();
            tomorrowTasks = new ObservableCollection<TaskModel>();
            upcomingTasks = new ObservableCollection<TaskModel>();
            somedayTasks = new ObservableCollection<TaskModel>();
            completedTasks = new ObservableCollection<TaskModel>();

            for (int i = 0; i < taskModels.Count; i++)
            {
                if (taskModels[i].due_date >= mydayStart && taskModels[i].due_date <= mydayEnd)
                {
                    myDayTasks.Add(taskModels[i]);
                }
                else if (taskModels[i].due_date >= tomorrowStart && taskModels[i].due_date <= tomorrowEnd && taskModels[i].is_completed == false)
                {
                    tomorrowTasks.Add(taskModels[i]);
                }
                else if (taskModels[i].due_date >= upcomingStart && taskModels[i].due_date <= upcomingEnd && taskModels[i].is_completed == false)
                {
                    upcomingTasks.Add(taskModels[i]);
                }
                else
                {
                    if(taskModels[i].is_completed == false)
                        upcomingTasks.Add(taskModels[i]);
                }

                if (taskModels[i].is_completed)
                    completedTasks.Add(taskModels[i]);
                

            }
            int myDayTaskCount = myDayTasks.Count;
            int tomorrowTaskCount = tomorrowTasks.Count;
            int upcomingTaskCount = upcomingTasks.Count;
            int somedayTaskCount = somedayTasks.Count;
            int completedTaskCount = completedTasks.Count;

            basicItemModels = new ObservableCollection<BasicItemModel>()
            {
                new BasicItemModel("My Day", "ms-appx:///Assets/Icons/myday.png", myDayTaskCount),
                new BasicItemModel("Tomorrow", "ms-appx:///Assets/Icons/tomorrow.png", tomorrowTaskCount),
                new BasicItemModel("Upcoming", "ms-appx:///Assets/Icons/upcoming.png", upcomingTaskCount),
                new BasicItemModel("Someday", "ms-appx:///Assets/Icons/someday.png", somedayTaskCount),
                new BasicItemModel("Completed", "ms-appx:///Assets/Icons/completed.png", completedTaskCount)
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
        public ObservableCollection<TaskModel> taskModels { get; set; }
        public ObservableCollection<TaskModel> myDayTasks { get; set; }
        public ObservableCollection<TaskModel> tomorrowTasks { get; set; }
        public ObservableCollection<TaskModel> upcomingTasks { get; set; }
        public ObservableCollection<TaskModel> somedayTasks { get; set; }
        public ObservableCollection<TaskModel> completedTasks { get; set; }
        public ObservableCollection<TaskModel> projectTask { get; set; }
        public ObservableCollection<BasicItemModel> basicItemModels { get; set; }
        public int projectCount { get => projectModels.Count; }
        public BasicItemModel selectedBasicItemModel { get; set; }
        public ProjectModel selectedProject { get; set; }

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
                            getData();
                            if (selectedBasicItemModel.Name == "My Day")
                                navigationService.Navigate(frame, typeof(MydayPageViewModel), myDayTasks);
                            if(selectedBasicItemModel.Name == "Tomorrow")
                                navigationService.Navigate(frame, typeof(TomorrowPageViewModel), tomorrowTasks);
                            if (selectedBasicItemModel.Name == "Upcoming")
                                navigationService.Navigate(frame, typeof(UpcomingPageViewModel), upcomingTasks);
                            if (selectedBasicItemModel.Name == "Someday")
                                navigationService.Navigate(frame, typeof(SomedayPageViewModel), somedayTasks);
                            if (selectedBasicItemModel.Name == "Completed")
                                navigationService.Navigate(frame, typeof(CompletedPageViewModel), completedTasks);
                        }
                    });
                }
                return _basicItemChangedCommand;
            }
        }

        private RelayCommand<object> _itemProjectChangedCommand;
        public RelayCommand<object> ItemProjectChangedCommand
        {
            get
            {
                if (_itemProjectChangedCommand == null)
                {
                    _itemProjectChangedCommand = new RelayCommand<object>((frame) =>
                    {
                        if (selectedProject != null)
                        {
                            taskModels = Database.getAllTask();
                            projectTask = new ObservableCollection<TaskModel>();
                            for (int i = 0; i < taskModels.Count; i++)
                            {
                                if (taskModels[i].id_project == selectedProject.id)
                                    projectTask.Add(taskModels[i]);
                            }
                            ProjectTaskModel projectTaskModel = new ProjectTaskModel()
                            {
                                taskModels = projectTask,
                                nameProject = selectedProject.name,
                                colorProject = selectedProject.color,
                            };
                            navigationService.Navigate(frame, typeof(ProjectPageViewModel), projectTaskModel);
                        }
                    });
                }
                return _itemProjectChangedCommand;
            }
        }

        // Notify
        public ObservableCollection<TaskModel> ReportedTasks
        {
            get
            {
                ObservableCollection<TaskModel> tasks = new ObservableCollection<TaskModel>();
                foreach (ProjectModel project in projectModels)
                {
                    ObservableCollection<TaskModel> mainTasks = Database.getTaskByWhere("id_project = " + project.id);
                    foreach (TaskModel task in mainTasks)
                    {
                        if (task.remender != null)
                        {
                            TimeSpan time = task.remender - DateTimeOffset.Now;
                            if (((int)time.TotalDays) > 0)
                            {
                                tasks.Add(task);
                            }
                        }
                    }
                }
                return tasks;
            }
        }
    }
}
