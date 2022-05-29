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
    public class CompletedPageViewModel : ServiceObservableObject
    {
        public CompletedPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            taskModels = new ObservableCollection<TaskModel>();

            priorities = new ObservableCollection<PriorityModel>()
            {
                new PriorityModel("noColor", "No Priority"),
                new PriorityModel("lowColor", "Low Priority"),
                new PriorityModel("mediumColor", "Medium Priority"),
                new PriorityModel("highColor", "High Priority"),
            };

            typeRepeats = new ObservableCollection<string>()
            {
                "Days",
                "Weeks",
                "Months",
                "Years"
            };
        }

        // Variables
        public ObservableCollection<TaskModel> taskModels { get; set; }
        public ObservableCollection<SubTaskModel> subTasks { get; set; }

        public TaskModel selectedTask { get; set; }
        public ObservableCollection<PriorityModel> priorities { get; set; }
        public PriorityModel selectedPriority { get; set; }

        public ObservableCollection<string> typeRepeats { get; set; }

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
                            taskModel.is_completed = false;
                            Database.updateTaskByID(taskModel, taskModel.id);
                            taskModels.Remove(taskModel);
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }
                return (_completedCommand);
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

                            Note = selectedTask.note;
                            OnPropertyChanged(Note);

                            // Get SubTask
                            subTasks = new ObservableCollection<SubTaskModel>();

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
                            taskModel.is_completed = false;
                            Database.updateTaskByID(taskModel, taskModel.id);
                            taskModels.Remove(taskModel);
                            OnPropertyChanged(nameof(taskModels));
                        }
                    });
                }

                return _isCompletedTaskCommand;
            }
        }

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
        }
        // End Task
    }
}
