using FocusTask.Model;
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

namespace FocusTask.ViewModel
{
    public class UpcomingPageViewModel : ServiceObservableObject
    {
        public UpcomingPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            projectModels = Database.getAllProject();
            projectModels.CollectionChanged += ProjectModels_CollectionChanged; ;

            taskModels = new ObservableCollection<TaskModel>();

            NameTask = "";
            workingTimes = new ObservableCollection<string>();
            for (int i = 0; i <= 9999; i++)
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

        // Variables Observable Collection
        public ObservableCollection<ProjectModel> projectModels { get; set; }
        public ObservableCollection<TaskModel> taskModels { get; set; }
        public ObservableCollection<SubTaskModel> subTasks { get; set; }
        public ObservableCollection<string> workingTimes { get; set; }
        public ObservableCollection<PriorityModel> priorities { get; set; }
        public ObservableCollection<string> typeRepeats { get; set; }

        // Variables
        public int projectCount { get => projectModels.Count; }
        public ProjectModel selectedProject { get; set; }

        public TaskModel selectedTask { get; set; }
        public string NameTask { get; set; }

        public string selectedTime { get; set; }
        public PriorityModel selectedPriority { get; set; }

        public string selectedTypeRepeat { get; set; }
        public int RepeatValue { get; set; }

        // --->
        public string IconCheckPriority { get; set; }
        public DateTimeOffset Due_Date { get; set; }
        public string NameProject { get; set; }
        public ProjectModel taskProject { get; set; }
        public string Reminder { get; set; }
        public string Repeat { get; set; }
        public string Note { get; set; }
        public string CreateOn { get; set; }

        // ------
        public string NewNameSubTask { get; set; }

        // RelayCommand
        private RelayCommand _addTaskCommand;
        public RelayCommand AddTaskCommand
        {
            get
            {
                if (_addTaskCommand == null)
                {
                    _addTaskCommand = new RelayCommand(() =>
                    {
                        TaskModel taskModel = new TaskModel();
                        taskModel.id_project = selectedProject.id;
                        taskModel.name = String.IsNullOrEmpty(NameTask) ? "Task..." : NameTask;
                        taskModel.workingtime = Int32.Parse(selectedTime);

                        DateTimeOffset dueDate = DateTimeOffset.Now.LocalDateTime.AddDays(-1);
                        taskModel.due_date = dueDate;

                        taskModels.Add(taskModel);
                        Database.addNewTask(taskModel);
                        OnPropertyChanged(nameof(taskModels));

                        NameTask = "";
                        OnPropertyChanged(nameof(NameTask));
                        selectedTime = "10";
                        OnPropertyChanged(selectedTime);
                    });
                }
                return _addTaskCommand;
            }
        }   // Completed Add new task upcoming

        private RelayCommand<TaskModel> _completedCommand;
        public RelayCommand<TaskModel> CompletedCommand
        {
            get
            {
                if (_completedCommand == null)
                {
                    _completedCommand = new RelayCommand<TaskModel>((selectedTask) =>
                    {
                        if (selectedTask != null)
                        {
                            TaskModel taskModel = selectedTask;
                            taskModel.is_completed = true;
                            Database.updateTaskByID(taskModel, taskModel.id);
                            taskModels.Remove(taskModel);
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }
                return (_completedCommand);
            }
        } // Completed update taskcompleted upcoming

        private RelayCommand _selectedTaskChangeCommand;
        public RelayCommand SelectedTaskChangeCommand
        {
            get
            {
                if (_selectedTaskChangeCommand == null)
                {
                    _selectedTaskChangeCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
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

                            Due_Date = selectedTask.due_date;
                            OnPropertyChanged(nameof(Due_Date));

                            CreateOn = selectedTask.create_on.ToString("dd/MM/yyyy hh:mm.ss");
                            OnPropertyChanged(CreateOn);

                            Reminder = selectedTask.remender.Date.ToString("dd/MM/yyyy hh:mm.ss");
                            OnPropertyChanged(nameof(Reminder));

                            if (selectedTask.repeat == 0)
                            {
                                selectedTypeRepeat = "Days";
                                RepeatValue = 1;
                            }
                            else
                            {
                                selectedTypeRepeat = selectedTask.type_repeat;
                                RepeatValue = selectedTask.repeat;
                            }

                            renderTaskRepeat();

                            // Get SubTask
                            subTasks = new ObservableCollection<SubTaskModel>();
                            OnPropertyChanged(nameof(subTasks));

                            NewNameSubTask = "";

                            Note = selectedTask.note;
                            OnPropertyChanged(Note);

                            OnPropertyChanged(nameof(selectedTask));
                        }
                    });
                }
                return _selectedTaskChangeCommand;
            }
        }

        private RelayCommand _isCompletedTaskCommand;
        public RelayCommand IsCompletedTaskCommand
        {
            get
            {
                if (_isCompletedTaskCommand == null)
                {
                    _isCompletedTaskCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                            TaskModel taskModel = selectedTask;
                            taskModel.is_completed = true;
                            Database.updateTaskByID(taskModel, taskModel.id);
                            taskModels.Remove(taskModel);
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }

                return _isCompletedTaskCommand;
            }
        } // Completed update task iscompleted upcoming

        private RelayCommand _updateTaskNameCommand;
        public RelayCommand UpdateTaskNameCommand
        {
            get
            {
                if (_updateTaskNameCommand == null)
                {
                    _updateTaskNameCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                            TaskModel taskModel = selectedTask;
                            for (int i = 0; i < taskModels.Count; i++)
                            {
                                if (taskModels[i].id == selectedTask.id)
                                {
                                    taskModels[i] = selectedTask;
                                    Database.updateTaskByID(taskModels[i], taskModels[i].id);
                                    break;
                                }
                            }
                            selectedTask = taskModel;
                            OnPropertyChanged(nameof(selectedTask));
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }
                return _updateTaskNameCommand;
            }
        }  // Completed update task name upcoming

        private RelayCommand _updatePriorityCommand;
        public RelayCommand UpdatePriorityCommand
        {
            get
            {
                if (_updatePriorityCommand == null)
                {
                    _updatePriorityCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null && selectedPriority != null)
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
        }  // Completed update task priority upcoming

        private RelayCommand _updateProjectNameCommand;
        public RelayCommand UpdateProjectNameCommand
        {
            get
            {
                if (_updateProjectNameCommand == null)
                {
                    _updateProjectNameCommand = new RelayCommand(() =>
                    {
                        if (taskProject != null && selectedTask != null)
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
        } // Completed update task project upcoming

        private RelayCommand _updateRepeatCommand;
        public RelayCommand UpdateRepeatCommand
        {
            get
            {
                if (_updateRepeatCommand == null)
                {
                    _updateRepeatCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                            selectedTask.repeat = RepeatValue;
                            selectedTask.type_repeat = selectedTypeRepeat;
                            OnPropertyChanged(nameof(selectedTask));
                            Database.updateTaskByID(selectedTask, selectedTask.id);
                            renderTaskRepeat();
                        }
                    });
                }
                return _updateRepeatCommand;
            }
        }  // Completed update task repeate upcoming

        private void renderTaskRepeat()
        {
            if (selectedTask != null)
            {
                if (selectedTask.repeat == 0)
                {
                    Repeat = "None";
                }
                else
                {
                    if (selectedTask.repeat == 1)
                    {
                        Repeat = "Once a " + selectedTask.type_repeat.Remove(selectedTask.type_repeat.Length - 1);
                    }
                    else if (selectedTask.repeat == 2)
                    {
                        Repeat = "2 times a " + selectedTask.type_repeat.Remove(selectedTask.type_repeat.Length - 1);
                    }
                    else
                    {
                        Repeat = "Once very " + selectedTask.repeat.ToString() + " " + selectedTask.type_repeat;
                    }
                }
                OnPropertyChanged(nameof(Repeat));
            }
        }

        private RelayCommand _removeRepeatCommand;
        public RelayCommand RemoveRepeatCommand
        {
            get
            {
                if (_removeRepeatCommand == null)
                {
                    _removeRepeatCommand = new RelayCommand(() =>
                    {
                        selectedTask.repeat = 0;
                        OnPropertyChanged(nameof(selectedTask));
                        Database.updateTaskByID(selectedTask, selectedTask.id);
                        renderTaskRepeat();
                    });
                }
                return _removeRepeatCommand;
            }
        } // Completed remove task repeat upcoming

        private RelayCommand _deleteTaskCommand;
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                if (_deleteTaskCommand == null)
                {
                    _deleteTaskCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                            Database.deleteTaskByID(selectedTask.id);
                            taskModels.Remove(selectedTask);
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }
                return _deleteTaskCommand;
            }
        }  // Completed delete task upcoming
        // End Task


        // Project
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
                        ProjectModel taskProjectModel = taskProject;
                        projectModels = Database.getAllProject();
                        OnPropertyChanged(nameof(projectModels));
                        for (int i = 0; i < projectModels.Count; i++)
                        {
                            if (projectModels[i].id == projectModel.id)
                                selectedProject = projectModels[i];
                            if (projectModels[i].id == taskProjectModel.id)
                                taskProject = projectModels[i];
                        }
                        OnPropertyChanged(nameof(selectedProject));
                        OnPropertyChanged(nameof(taskProject));
                    });
                }
                return _getAllProjectsCommand;
            }
        } // Completed get all project before add new task upcoming

        private RelayCommand _selectedProjectChangeCommand;
        public RelayCommand SelectedProjectChangeCommand
        {
            get
            {
                if (_selectedProjectChangeCommand == null)
                {
                    _selectedProjectChangeCommand = new RelayCommand(() =>
                    {
                        OnPropertyChanged(nameof(selectedProject));
                    });
                }
                return _selectedProjectChangeCommand;
            }
        } // Completed selected change project before add new task upcoming
        // End Project

        // Subtask
        public RelayCommand _addSubTaskCommand;
        public RelayCommand AddSubTaskCommand
        {
            get
            {
                if (_addSubTaskCommand == null)
                {
                    _addSubTaskCommand = new RelayCommand(() =>
                    {
                        if (selectedTask != null)
                        {
                            SubTaskModel subTaskModel = new SubTaskModel();
                            subTaskModel.id_task = selectedTask.id;
                            subTaskModel.name = String.IsNullOrEmpty(NewNameSubTask) ? "SubTask..." : NewNameSubTask;
                            subTasks.Add(subTaskModel);
                            NewNameSubTask = "";
                            Database.addNewSubTask(subTaskModel);
                            subTasks.Add(subTaskModel);
                            OnPropertyChanged(nameof(subTasks));
                        }
                    });
                }
                return _addSubTaskCommand;
            }
        }
        // End Subtask
    }
}
