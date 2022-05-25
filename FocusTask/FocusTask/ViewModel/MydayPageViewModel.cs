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

            int hour = DateTimeOffset.Now.LocalDateTime.Hour;
            int minute = DateTimeOffset.Now.LocalDateTime.Minute;
            int second = DateTimeOffset.Now.LocalDateTime.Second;
            DateTimeOffset dateStart = DateTimeOffset.Now.AddHours(-hour + 1).AddMinutes(-minute).AddSeconds(-second);
            DateTimeOffset dateEnd = DateTimeOffset.Now.AddHours(12 - hour).AddMinutes(-minute).AddSeconds(-second);

            ObservableCollection<TaskModel> taskModels = Database.getAllTask();
            Debug.WriteLine("Count all task: " + taskModels.Count + " -> " + taskModels[0].due_date);

            taskCompletedModels = Database.getTaskByWhere("is_completed = true AND due_date = '" + dateStart + "' AND due_date <= '" + dateEnd + "'");
            taskCompletedModels.CollectionChanged += TaskCompletedModels_CollectionChanged;
            Debug.WriteLine("Count task completed: " + taskCompletedCount);

            taskUncompletedModels = Database.getTaskByWhere("is_completed = false AND due_date >= '" + dateStart + "' AND due_date <= '" + dateEnd + "'");
            taskUncompletedModels.CollectionChanged += TaskUncompletedModels_CollectionChanged;
            Debug.WriteLine("Count task uncompleted: " + taskUncompletedCount);

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
            typeRepeats = new ObservableCollection<string>()
            {
                "Days",
                "Weeks",
                "Months",
                "Years"
            };
            selectedTypeRepeat = "Days";
            RepeatValue = 1;
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
            Debug.WriteLine("Count task uncompleted: " + taskUncompletedCount);
            OnPropertyChanged(nameof(taskUncompletedCount));
        }

        private void TaskCompletedModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Count task completed: " + taskCompletedCount);
            OnPropertyChanged(nameof(taskCompletedCount));
        }


        // Variables
        public ObservableCollection<ProjectModel> projectModels { get; set; }
        public ObservableCollection<TaskModel> taskUncompletedModels { get; set; }
        public ObservableCollection<TaskModel> taskCompletedModels { get; set; }
        public ObservableCollection<SubTaskModel> subTasks { get; set; }
        public ObservableCollection<string> typeRepeats { get; set; }

        public int projectCount { get => projectModels.Count; }
        public int taskUncompletedCount { get => taskUncompletedModels.Count; }
        public int taskCompletedCount { get => taskCompletedModels.Count; }
        public string selectedTypeRepeat { get; set; }
        public int RepeatValue { get; set; }

        public string NameTask { get; set; }
        public ObservableCollection<string> workingTimes { get; set; }
        public string selectedTime { get; set; }
        public ObservableCollection<PriorityModel> priorities { get; set; }
        public PriorityModel selectedPriority { get; set; }
        public TaskModel selectedTask { get; set; }
        public ProjectModel selectedProject { get; set; }
        public ProjectModel taskProject { get; set; }

        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }
        public string IconCheckPriority { get; set; }
        public DateTimeOffset Due_Date { get; set; }
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
                        taskUncompletedModels.Add(taskModel);
                        NameTask = "";
                        OnPropertyChanged(nameof(NameTask));
                        selectedTime = "10";
                        OnPropertyChanged(selectedTime);
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
                        Database.updateTaskByID(taskModel, taskModel.id);
                        taskCompletedModels.Add(taskModel);
                        taskUncompletedModels.Remove(taskModel);
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
                            Database.deleteTaskByID(selectedTask.id);
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
                            {
                                selectedPriority = priorities[0];
                                IconCheckPriority = "ms-appx:///Assets/Icons/no_priority.png";
                            }
                            else if (selectedTask.priority == 1)
                            {
                                selectedPriority = priorities[1];
                                IconCheckPriority = "ms-appx:///Assets/Icons/low_priority.png";
                            }
                            else if (selectedTask.priority == 2)
                            {
                                selectedPriority = priorities[2];
                                IconCheckPriority = "ms-appx:///Assets/Icons/medium_priority.png";
                            }
                            else if (selectedTask.priority == 3)
                            {
                                selectedPriority = priorities[3];
                                IconCheckPriority = "ms-appx:///Assets/Icons/high_priority.png";
                            }
                            OnPropertyChanged(nameof(IconCheckPriority));
                            OnPropertyChanged(nameof(selectedPriority));

                            ProjectModel projectModel = Database.getProjectByID(selectedTask.id_project);

                            NameProject = projectModel.name;
                            OnPropertyChanged(nameof(NameProject));

                            taskProject = projectModel;
                            OnPropertyChanged(nameof(taskProject));

                            Due_Date = selectedTask.due_date;
                            OnPropertyChanged(nameof(Due_Date));

                            CreateOn = selectedTask.create_on.ToString("dd/MM/yyyy hh:mm.ss");
                            OnPropertyChanged(CreateOn);

                            Reminder = selectedTask.remender.Date.ToString("dd/MM/yyyy hh:mm.ss");
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

                            subTasks = Database.getSubTaskByWhere("id_task = " + selectedTask.id);
                            Debug.WriteLine("HAH: " + subTasks.Count);
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
                       if(selectedPriority != null)
                       {
                           if (selectedPriority.name == "No Priority")
                           {
                               selectedTask.priority = 0;
                               IconCheckPriority = "ms-appx:///Assets/Icons/no_priority.png";
                           }
                           else if (selectedPriority.name == "Low Priority")
                           {
                               selectedTask.priority = 1;
                               IconCheckPriority = "ms-appx:///Assets/Icons/low_priority.png";
                           }
                           else if (selectedPriority.name == "Medium Priority")
                           {
                               selectedTask.priority = 2;
                               IconCheckPriority = "ms-appx:///Assets/Icons/medium_priority.png";
                           }
                           else
                           {
                               selectedTask.priority = 3;
                               IconCheckPriority = "ms-appx:///Assets/Icons/high_priority.png";
                           }
                           OnPropertyChanged(nameof(IconCheckPriority));
                           OnPropertyChanged(nameof(selectedPriority));
                           OnPropertyChanged(nameof(selectedTask));
                           Database.updateTaskByID(selectedTask, selectedTask.id);
                       }
                   });
                }
                return _updatePriorityCommand;
            }
        }

        private RelayCommand _updateDueDateCommand;
        public RelayCommand UpdateDueDateCommand
        {
            get
            {
                if(_updateDueDateCommand == null)
                {
                    _updateDueDateCommand = new RelayCommand(() =>
                    {

                    });
                }
                return _updateDueDateCommand;
            }
        }

        private RelayCommand _updateProjectNameCommand;
        public RelayCommand UpdateProjectNameCommand
        {
            get
            {
                if(_updateProjectNameCommand == null)
                {
                    _updateProjectNameCommand = new RelayCommand(() =>
                    {
                        if(taskProject != null && selectedTask != null)
                        {
                            NameProject = taskProject.name;
                            OnPropertyChanged(nameof(NameProject));

                            selectedTask.id_project = taskProject.id;
                            Database.updateTaskByID(selectedTask, selectedTask.id);
                        }
                    });
                }
                return _updateProjectNameCommand;
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
                        Debug.WriteLine("HAHA: " + subTaskModel.id_task);
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

        private RelayCommand<SubTaskModel> _completedSubTaskCommand;
        public RelayCommand<SubTaskModel> CompletedSubTaskCommand
        {
            get
            {
                if (_completedSubTaskCommand == null)
                {
                    _completedSubTaskCommand = new RelayCommand<SubTaskModel>((selectSubTask) =>
                    {
                        if (selectSubTask.completed == "None")
                            selectSubTask.completed = "Strikethrough";
                        else selectSubTask.completed = "None";
                        for (int i = 0; i < subTasks.Count; i++)
                        {
                            if (subTasks[i].id == selectSubTask.id)
                            {
                                subTasks[i] = selectSubTask;
                            }
                        }
                        Database.updateSubTaskByID(selectSubTask, selectSubTask.id);
                        OnPropertyChanged(nameof(selectSubTask));
                    });
                }
                return (_completedSubTaskCommand);
            }
        }

        private RelayCommand<TaskModel> _uncompletedSubTaskCommand;
        public RelayCommand<TaskModel> UncompletedSubTaskCommand
        {
            get
            {
                if (_uncompletedSubTaskCommand == null)
                {
                    _uncompletedSubTaskCommand = new RelayCommand<TaskModel>((selectedTask) =>
                    {
                        TaskModel taskModel = selectedTask;
                        taskModel.is_completed = false;
                        taskCompletedModels.Remove(taskModel);
                        taskUncompletedModels.Add(taskModel);
                        Database.updateTaskByID(taskModel, taskModel.id);
                    });
                }
                return (_uncompletedSubTaskCommand);
            }
        }

        private RelayCommand _updateRepeatCommand;
        public RelayCommand UpdateRepeatCommand
        {
            get
            {
                if(_updateRepeatCommand == null)
                {
                    _updateRepeatCommand = new RelayCommand(() =>
                    {

                    });
                }
                return _updateRepeatCommand;
            }
        }
    }
}
