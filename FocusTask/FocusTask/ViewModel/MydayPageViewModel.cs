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
    public class MydayPageViewModel : ServiceObservableObject
    {
        public MydayPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = Database.getAllProject();
            projectModels.CollectionChanged += ProjectModels_CollectionChanged;

            taskCompletedModels = Database.getTaskByWhere("is_completed = true");
            taskCompletedModels.CollectionChanged += TaskCompletedModels_CollectionChanged;

            taskUncompletedModels = Database.getTaskByWhere("is_completed = false");
            taskUncompletedModels.CollectionChanged += TaskUncompletedModels_CollectionChanged;

            NameTask = "";
            workingTimes = new ObservableCollection<string>();
            for(int i = 0; i <= 9999; i++)
            {
                workingTimes.Add(i.ToString());
            }
            selectedTime = "10";
            priorities = new ObservableCollection<PriorityModel>()
            {
                new PriorityModel("noColor", "No Priority"),
                new PriorityModel("lowColor", "Low Priority"),
                new PriorityModel("mediumColor", "Medium Priority"),
                new PriorityModel("highColor", "High Priority"),
            };

            if (projectCount > 0)
            {
                selectedProject = projectModels[0];
            }
        }

        private void ProjectModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(projectCount));
        }

        private void TaskUncompletedModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Database.addNewTask(e.NewItems[0] as TaskModel);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                TaskModel taskModel = (TaskModel)e.OldItems[0];
                Database.deleteTaskByID(taskModel.id);
            }
            OnPropertyChanged(nameof(taskUncompletedCount));
        }

        private void TaskCompletedModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                TaskModel taskModel = (TaskModel)e.OldItems[0];
                Database.deleteTaskByID(taskModel.id);
            }
            OnPropertyChanged(nameof(taskCompletedCount));
        }


        // Variables
        public ObservableCollection<ProjectModel> projectModels { get; set; }
        public ObservableCollection<TaskModel> taskUncompletedModels { get; set; }
        public ObservableCollection<TaskModel> taskCompletedModels { get; set; }
        public ObservableCollection<SubTaskModel> subTasks { get; set; }

        public int projectCount { get => projectModels.Count; }
        public int taskUncompletedCount { get => taskUncompletedModels.Count; }
        public int taskCompletedCount { get => taskCompletedModels.Count; }

        public string NameTask { get; set; }
        public ObservableCollection<string> workingTimes { get; set; }
        public string selectedTime { get; set; }
        public ObservableCollection<PriorityModel> priorities { get; set; }
        public PriorityModel selectedPriority { get; set; }
        public TaskModel selectedTask { get; set; }
        public ProjectModel selectedProject { get; set; }

        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }
        public string Due_Date { get; set; }
        public string NameProject { get; set; }
        public string Reminder { get; set; }
        public string Repeat { get; set; }
        public string Note { get; set; }
        public string CreateOn { get; set; }

        public string NewNameSubTask { get; set; }

        // RelayCommand
        private RelayCommand _addTaskCommand;
        public RelayCommand AddTaskCommand
        {
            get
            {
                if(_addTaskCommand == null)
                {
                    _addTaskCommand = new RelayCommand(() =>
                    {
                        TaskModel taskModel = new TaskModel();
                        taskModel.id_project = selectedProject.id;
                        taskModel.name = String.IsNullOrEmpty(NameTask) ? "Task..." : NameTask;
                        taskModel.workingtime = Int32.Parse(selectedTime);
                        NameTask = "";
                        OnPropertyChanged(nameof(NameTask));
                        selectedTime = "10";
                        OnPropertyChanged(selectedTime);
                        taskUncompletedModels.Add(taskModel);
                    });
                }
                return _addTaskCommand;
            }
        }

        private RelayCommand<TaskModel> _completedCommand;
        public RelayCommand<TaskModel> CompletedCommand
        {
            get
            {
                if (_completedCommand == null)
                {
                    _completedCommand = new RelayCommand<TaskModel>((selectedTask) =>
                    {
                        TaskModel taskModel = selectedTask;
                        taskModel.is_completed = true;
                        taskCompletedModels.Add(taskModel);
                        taskUncompletedModels.Remove(taskModel);
                        Database.updateTaskByID(taskModel, taskModel.id);
                    });
                }
                return (_completedCommand);
            }
        }

        private RelayCommand<TaskModel> _uncompletedCommand;
        public RelayCommand<TaskModel> UncompletedCommand
        {
            get
            {
                if (_uncompletedCommand == null)
                {
                    _uncompletedCommand = new RelayCommand<TaskModel>((selectedTask) =>
                    {
                        TaskModel taskModel = selectedTask;
                        taskModel.is_completed = false;
                        taskCompletedModels.Remove(taskModel);
                        taskUncompletedModels.Add(taskModel);
                        Database.updateTaskByID(taskModel, taskModel.id);
                    });
                }
                return (_uncompletedCommand);
            }
        }

        private RelayCommand _deleteTaskCommand;
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                if(_deleteTaskCommand == null)
                {
                    _deleteTaskCommand = new RelayCommand(() =>
                    {
                        if(selectedTask != null)
                        {
                            taskUncompletedModels.Remove(selectedTask);
                            taskCompletedModels.Remove(selectedTask);
                        }
                    });
                }
                return _deleteTaskCommand;
            }
        }

        private RelayCommand _getAllProjectsCommand;
        public RelayCommand GetAllProjectsCommand
        {
            get
            {
                if (_getAllProjectsCommand == null)
                {
                    _getAllProjectsCommand = new RelayCommand(() =>
                    {
                        ProjectModel projectModel = selectedProject;
                        projectModels = Database.getAllProject();
                        OnPropertyChanged(nameof(projectModels));
                        for(int i = 0; i < projectModels.Count; i++)
                        {
                            if(projectModels[i].id == projectModel.id)
                                selectedProject = projectModels[i];
                        }
                        OnPropertyChanged(nameof(selectedProject));
                    });
                }
                return _getAllProjectsCommand;
            }
        }

        private RelayCommand _selectedProjectChangeCommand;
        public RelayCommand SelectedProjectChangeCommand
        {
            get
            {
                if(_selectedProjectChangeCommand == null)
                {
                    _selectedProjectChangeCommand = new RelayCommand(() =>
                    {
                        OnPropertyChanged(nameof(selectedProject));
                    });
                }
                return _selectedProjectChangeCommand;
            }
        }

        private RelayCommand _selectedTaskChangeCommand;
        public RelayCommand SelectedTaskChangeCommand
        {
            get
            {
                if (_selectedTaskChangeCommand == null)
                {
                    _selectedTaskChangeCommand = new RelayCommand(() =>
                    {
                       if(selectedTask != null)
                        {
                            TaskName = selectedTask.name;
                            OnPropertyChanged(nameof(TaskName));

                            if (selectedTask.priority == 0)
                                selectedPriority = priorities[0];
                            else if (selectedTask.priority == 1)
                                selectedPriority = priorities[1];
                            else if (selectedTask.priority == 2)
                                selectedPriority = priorities[2];
                            else if (selectedTask.priority == 3)
                                selectedPriority = priorities[3];
                            OnPropertyChanged(nameof(selectedPriority));

                            NameProject = Database.getProjectByID(selectedTask.id_project).name;
                            OnPropertyChanged(nameof(NameProject));

                            Due_Date = selectedTask.due_date.Date.ToString();
                            OnPropertyChanged(nameof(Due_Date));

                            Reminder = selectedTask.remender.Date.ToString();
                            OnPropertyChanged(nameof(Reminder));

                            if (selectedTask.repeat == 0)
                            {
                                Repeat = "None";
                            }
                            else
                            {
                                if(selectedTask.repeat == 1)
                                {
                                    Repeat = "Once a " + selectedTask.type_repeat.Remove(selectedTask.type_repeat.Length - 1);
                                } else if(selectedTask.repeat == 2)
                                {
                                    Repeat = "2 times a " + selectedTask.type_repeat.Remove(selectedTask.type_repeat.Length - 1);
                                } else
                                {
                                    Repeat = "Once very " + selectedTask.repeat.ToString() + " " + selectedTask.type_repeat;
                                }
                            }
                            OnPropertyChanged(nameof(Repeat));

                            Note = selectedTask.note;
                            OnPropertyChanged(Note);

                            CreateOn = selectedTask.create_on.ToString();
                            OnPropertyChanged(CreateOn);

                            subTasks = Database.getSubTaskByWhere("id_task = " + selectedTask.id);
                            OnPropertyChanged(nameof(subTasks));

                            OnPropertyChanged(nameof(selectedTask));
                        }
                    });
                }
                return _selectedTaskChangeCommand;
            }
        }

        private RelayCommand _updateTaskNameCommand;
        public RelayCommand UpdateTaskNameCommand
        {
            get {
                if(_updateTaskNameCommand == null)
                {
                    _updateTaskNameCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                        }
                    });
                }
                return _updateTaskNameCommand; 
            }
        }

        private RelayCommand _updatePriorityCommand;
        public RelayCommand UpdatePriorityCommand
        {
            get
            {
                if (_updatePriorityCommand == null)
                {
                    _updatePriorityCommand = new RelayCommand(() =>
                   {
                       Debug.WriteLine("HAHA: " + selectedPriority.name);
                   });
                }
                return _updatePriorityCommand;
            }
        }

        public RelayCommand _addSubTaskCommand;
        public RelayCommand AddSubTaskCommand
        {
            get
            {
                if(_addSubTaskCommand == null)
                {
                    _addSubTaskCommand = new RelayCommand(() =>
                    {
                        SubTaskModel subTaskModel = new SubTaskModel();
                        subTaskModel.id_task = selectedTask.id;
                        subTaskModel.name = String.IsNullOrEmpty(NewNameSubTask) ? "SubTask..." : NewNameSubTask;
                        NewNameSubTask = "";
                        OnPropertyChanged(nameof(NewNameSubTask));
                        subTasks.Add(subTaskModel);
                        Database.addNewSubTask(subTaskModel);
                        OnPropertyChanged(nameof(subTaskModel));
                    });
                }
                return _addSubTaskCommand;
            }
        }
    }
}
