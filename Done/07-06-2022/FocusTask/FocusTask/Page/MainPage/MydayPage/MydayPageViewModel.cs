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
    public class MydayPageViewModel : ViewModelBase
    {
        public MydayPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            GetRawMissions();
            SetupMissions();
            SetupProjects();
            SetupRepeatItems();

            IsPremium = StoreHelper.Default.IsPremium;
            Quantity = StoreHelper.Default.Balance;
        }

        public bool IsPremium { get; set; }
        public uint Quantity { get; set; }

        #region Xử lý SplitView

        private bool _isOpen;
        public bool IsOpen { get { return _isOpen; } set { SetProperty(ref _isOpen, value); } }

        private RelayCommand<Mission> _taskItemClickCommand;
        public RelayCommand<Mission> TaskItemClickCommand => _taskItemClickCommand ?? (_taskItemClickCommand = new RelayCommand<Mission>((obj) =>
        {
            SelectedMission = obj;
            IsOpen = true;
            WeakReferenceMessenger.Default.Send(new NoteValueChanged(SelectedMission.Description));
        }));

        private RelayCommand _closePaneCommand;
        public RelayCommand ClosePaneCommand => _closePaneCommand ?? (_closePaneCommand = new RelayCommand(() =>
        {
            IsOpen = false;
        }));
        #endregion

        #region Xử lý Projects

        public ObservableCollection<Project> Projects { get; set; }
        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set { SetProperty(ref _selectedProject, value); }
        }

        private void SetupProjects()
        {
            Projects = WeakReferenceMessenger.Default.Send<ProjectsRequestMessage>().Response;

            SelectedProject = Projects[0];
        }

        private RelayCommand<Project> _projectChosenCommand;
        public RelayCommand<Project> ProjectChosenCommand => _projectChosenCommand ?? (_projectChosenCommand = new RelayCommand<Project>((obj) =>
        {
            SelectedProject = obj;
        }));

        #endregion

        #region Xử lý Mission

        public ObservableCollection<Mission> RawMissions { get; set; }

        private void GetRawMissions()
        {
            RawMissions = dataService.GetMissions();
            RawMissions.CollectionChanged += RawMissions_CollectionChanged;
        }

        private void RawMissions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var mission = e.NewItems[0] as Mission;
                Missions.Insert(0, mission);
                dataService.AddMission(mission);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                var mission = e.OldItems[0] as Mission;
                if (mission.IsCompleted)
                {
                    CompletedMissions.Remove(mission);
                }
                else
                {
                    Missions.Remove(mission);
                }
                dataService.RemoveMission(mission);
            }
        }

        private ObservableCollection<Mission> _missions;
        public ObservableCollection<Mission> Missions
        {
            get { return _missions; }
            set { SetProperty(ref _missions, value); }
        }

        private Mission _selectedMission;
        public Mission SelectedMission
        {
            get { return _selectedMission; }
            set { SetProperty(ref _selectedMission, value); }
        }

        private ObservableCollection<Mission> _completedMissions;
        public ObservableCollection<Mission> CompletedMissions
        {
            get { return _completedMissions; }
            set { SetProperty(ref _completedMissions, value); }
        }

        public void SetupMissions()
        {
            var missions = RawMissions
                .Where(x => x.IsCompleted == false)
                .OrderBy(x => x.Created)
                .ToList();

            missions.Reverse();

            Missions = new ObservableCollection<Mission>(missions);

            var completedMissions = RawMissions
                .Where(x => x.IsCompleted == true)
                .OrderBy(x => x.Created)
                .ToList();

            CompletedMissions = new ObservableCollection<Mission>(completedMissions);
        }

        public int UncompletedMissionCount => RawMissions.Where(x => x.IsCompleted == false).Count();
        public int CompletedMissionCount => RawMissions.Where(x => x.IsCompleted == true).Count();

        private string _missionName;
        public string MissionName
        {
            get { return _missionName; }
            set { SetProperty(ref _missionName, value); }
        }

        private AsyncRelayCommand _addMissionCommand;
        public AsyncRelayCommand AddMissionCommand => _addMissionCommand ?? (_addMissionCommand = new AsyncRelayCommand(async () =>
        {
            if (!string.IsNullOrEmpty(MissionName) && !string.IsNullOrEmpty(MissionName))
            {
                if (IsPremium)
                {
                    AddMission();
                    return;
                }
                if (Quantity > 0)
                {
                    StoreHelper.Default.FulfillConsumable();
                    AddMission();
                    return;
                }
                await dialogService.showAsync(typeof(WaitingDialogViewModel));
                AddMission();
            }
        }));

        private void AddMission()
        {
            var addedMission = new Mission
            {
                Name = MissionName,
                DateTime = DateTime.Now,
                ProjectId = SelectedProject.Id,
                Project = SelectedProject
            };

            RawMissions.Add(addedMission);
            MissionName = "";
        }

        private RelayCommand<Mission> _removeMissionCommand;
        public RelayCommand<Mission> RemoveMissonCommand => _removeMissionCommand ?? (_removeMissionCommand = new RelayCommand<Mission>((obj) =>
        {
            RawMissions.Remove(obj);
            IsOpen = false;
        }));

        private RelayCommand<Mission> _completedMissionCommand;
        public RelayCommand<Mission> CompletedMissionCommand => _completedMissionCommand ?? (_completedMissionCommand = new RelayCommand<Mission>((obj) =>
        {
            if (obj.IsCompleted)
            {
                obj.IsCompleted = false;
                SetupMissions();
            }
            else
            {
                if (obj.Repeat == 0)
                {
                    obj.IsCompleted = true;
                    SetupMissions();
                }
                else
                {
                    if (obj.DateTime.HasValue)
                    {
                        obj.DateTime = obj.DateTime.Value.AddDays(obj.Repeat);
                        SetupMissions();
                    }
                    else
                    {
                        obj.IsCompleted = true;
                        SetupMissions();
                    }
                }
            }
            dataService.SaveChanges();
        }));
        #endregion

        #region Xử lý Edit Mission

        public List<Priority> Priorities { get; set; } = new List<Priority> { Priority.No, Priority.Low, Priority.Medium, Priority.High };
        public Priority SelectedPriority { get; set; }

        private RelayCommand<Priority> _prioritySelectionChangedCommand;
        public RelayCommand<Priority> PrioritySelectionChangedCommand => _prioritySelectionChangedCommand ?? (_prioritySelectionChangedCommand = new RelayCommand<Priority>((obj) =>
        {
            SelectedMission.Priority = obj;
            dataService.SaveChanges();
        }));

        private RelayCommand _textChangedCommand;
        public RelayCommand TextChangedCommand => _textChangedCommand ?? (_textChangedCommand = new RelayCommand(() =>
        {
            dataService.SaveChanges();
        }));

        #region DueDate
        public DateTime? DueDate { get; set; }
        private RelayCommand<DateTimeOffset?> _dueDateChangedCommand;
        public RelayCommand<DateTimeOffset?> DueDateChangedCommand => _dueDateChangedCommand ?? (_dueDateChangedCommand = new RelayCommand<DateTimeOffset?>((obj) =>
        {
            if (obj.HasValue)
            {
                DueDate = obj.Value.DateTime;
            }
            else
            {
                DueDate = null;
            }
        }));

        private RelayCommand _removeDueDateCommand;
        public RelayCommand RemoveDueDateCommand => _removeDueDateCommand ?? (_removeDueDateCommand = new RelayCommand(() =>
        {
            SelectedMission.DateTime = null;
        }));

        private RelayCommand _saveDueDateCommand;
        public RelayCommand SaveDueDateCommand => _saveDueDateCommand ?? (_saveDueDateCommand = new RelayCommand(() =>
        {
            SelectedMission.DateTime = DueDate;
            dataService.SaveChanges();
        }));

        private RelayCommand _setDisplayDueDateCommand;
        public RelayCommand SetDisplayDueDateCommand => _setDisplayDueDateCommand ?? (_setDisplayDueDateCommand = new RelayCommand(() =>
        {
            Debug.WriteLine("Called");
            WeakReferenceMessenger.Default.Send<SetDisplayDueDateMessage>(new SetDisplayDueDateMessage(SelectedMission.DateTime ?? DateTime.Now));
        }));
        #endregion

        #region Change Project

        private RelayCommand<Project> _changeProjectCommand;
        public RelayCommand<Project> ChangeProjectCommand => _changeProjectCommand ?? (_changeProjectCommand = new RelayCommand<Project>((obj) =>
        {
            SelectedMission.Project.Missions.Remove(SelectedMission);

            SelectedMission.ProjectId = obj.Id;
            SelectedMission.Project = obj;

            obj.Missions.Add(SelectedMission);

            dataService.SaveChanges();
        }));
        #endregion

        #region Reminder

        public DateTime? Reminder { get; set; }
        private RelayCommand<DateTimeOffset?> _reminderChangedCommand;
        public RelayCommand<DateTimeOffset?> ReminderChangedCommand => _reminderChangedCommand ?? (_reminderChangedCommand = new RelayCommand<DateTimeOffset?>((obj) =>
        {
            if (obj.HasValue)
            {
                Reminder = obj.Value.DateTime;
            }
            else
            {
                Reminder = null;
            }
        }));

        private RelayCommand _removeReminderCommand;
        public RelayCommand RemoveReminderCommand => _removeReminderCommand ?? (_removeReminderCommand = new RelayCommand(() =>
        {
            SelectedMission.Reminder = null;
        }));

        private RelayCommand _saveReminderCommand;
        public RelayCommand SaveReminderCommand => _saveReminderCommand ?? (_saveReminderCommand = new RelayCommand(() =>
        {
            SelectedMission.Reminder = Reminder;
            dataService.SaveChanges();
        }));

        private RelayCommand _setDisplayReminderCommand;
        public RelayCommand SetDisplayReminderCommand => _setDisplayReminderCommand ?? (_setDisplayReminderCommand = new RelayCommand(() =>
        {
            WeakReferenceMessenger.Default.Send<SetDisplayReminderMessage>(new SetDisplayReminderMessage(SelectedMission.Reminder ?? DateTime.Now));
        }));
        #endregion

        #region Repeat
        public List<RepeatItem> RepeatItems { get; set; }
        public RepeatItem SelectedRepeatItem { get; set; }
        public double RepeatValue { get; set; }

        private void SetupRepeatItems()
        {
            RepeatItems = new List<RepeatItem>
            {
                new RepeatItem
                {
                    Title = "Days",
                    Value = 1
                },
                new RepeatItem
                {
                    Title = "Weeks",
                    Value = 7
                },
                new RepeatItem
                {
                    Title = "Months",
                    Value = 30
                },
                new RepeatItem
                {
                    Title = "Years",
                    Value = 365
                },
            };

            SelectedRepeatItem = RepeatItems[0];

            RepeatValue = 1;
        }

        private RelayCommand _saveRepeatCommand;
        public RelayCommand SaveRepeatCommand => _saveRepeatCommand ?? (_saveRepeatCommand = new RelayCommand(() =>
        {
            if (RepeatValue > 0)
            {
                SelectedMission.Repeat = ((int)RepeatValue) * SelectedRepeatItem.Value;
            }
            else
            {
                SelectedMission.Repeat = 0;
            }
        }));

        private RelayCommand _removeRepeatCommand;
        public RelayCommand RemoveRepeatCommand => _removeRepeatCommand ?? (_removeRepeatCommand = new RelayCommand(() =>
        {
            SelectedMission.Repeat = 0;
        }));
        #endregion

        #region SubMission

        private string _subMissionName;
        public string SubMissionName
        {
            get { return _subMissionName; }
            set { SetProperty(ref _subMissionName, value); }
        }

        private RelayCommand _addSubMission;
        public RelayCommand AddSubMission => _addSubMission ?? (_addSubMission = new RelayCommand(() =>
        {
            var submission = new SubMission
            {
                Name = string.IsNullOrEmpty(SubMissionName) ? "Sub Task" : SubMissionName,
                IsCompleted = false,
                MissionId = SelectedMission.Id,
                Mission = SelectedMission
            };
            SelectedMission.SubMissions.Add(submission);
            dataService.AddSubMission(submission);

            SubMissionName = "";
        }));

        private RelayCommand<SubMission> _removeSubMission;
        public RelayCommand<SubMission> RemoveSubMission => _removeSubMission ?? (_removeSubMission = new RelayCommand<SubMission>((obj) =>
        {
            dataService.RemoveSubMission(obj);
        }));

        private RelayCommand<SubMission> _completedSubMission;
        public RelayCommand<SubMission> CompletedSubMission => _completedSubMission ?? (_completedSubMission = new RelayCommand<SubMission>((obj) =>
        {
            obj.IsCompleted = !obj.IsCompleted;
        }));

        private RelayCommand _lostFocusCommand;
        public RelayCommand LostFocusCommand => _lostFocusCommand ?? (_lostFocusCommand = new RelayCommand(() =>
        {
            dataService.SaveChanges();
        }));
        #endregion

        private RelayCommand<string> _saveNoteCommand;
        public RelayCommand<string> SaveNoteCommand => _saveNoteCommand ?? (_saveNoteCommand = new RelayCommand<string>((obj) =>
        {
            SelectedMission.Description = obj;
            dataService.SaveChanges();
        }));

        #endregion
    }
}
