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
        public MydayPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            GetRawMissions();
            SetupMissions();
            SetupProjects();
        }

        #region Xử lý SplitView

        private bool _isOpen;
        public bool IsOpen { get { return _isOpen; } set { SetProperty(ref _isOpen, value); } }

        private RelayCommand<Mission> _taskItemClickCommand;
        public RelayCommand<Mission> TaskItemClickCommand => _taskItemClickCommand ?? (_taskItemClickCommand = new RelayCommand<Mission>((obj) =>
        {
            SelectedMission = obj;
            IsOpen = true;
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
            Projects = messengerService.Send<ProjectsRequestMessage>().Response;
            SelectedProject = Projects[0];
        }

        private RelayCommand<Project> _projectChosenCommand;
        public RelayCommand<Project> ProjectChosenCommand => _projectChosenCommand ?? (_projectChosenCommand = new RelayCommand<Project>((obj) =>
        {
            SelectedProject = obj;
        }));

        #endregion

        #region Xử lý Transaction

        private ObservableCollection<Mission> RawMissions { get; set; }

        private void GetRawMissions()
        {
            RawMissions = dataService.GetMissions();
        }

        public ObservableCollection<Mission> Missions { get; set; }
        private Mission _selectedMission;
        public Mission SelectedMission
        {
            get { return _selectedMission; }
            set { SetProperty(ref _selectedMission, value); }
        }

        private void SetupMissions()
        {
            Missions = new ObservableCollection<Mission>(RawMissions.OrderBy(x => x.Created).ToList());
            Missions.CollectionChanged += Missions_CollectionChanged;
        }

        private void Missions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddMission(e.NewItems[0] as Mission);
            }
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.RemoveMission(e.OldItems[0] as Mission);
            }
        }

        public int UncompletedMissionCount => Missions.Where(x => x.IsCompleted == false).Count();
        public int CompletedMissionCount => Missions.Where(x => x.IsCompleted == true).Count();

        private RelayCommand _addMissionCommand;
        public RelayCommand AddMissionCommand => _addMissionCommand ?? (_addMissionCommand = new RelayCommand(() =>
        {

        }));

        private RelayCommand<Mission> _removeMissionCommand;
        public RelayCommand<Mission> RemoveMissonCommand => _removeMissionCommand ?? (_removeMissionCommand = new RelayCommand<Mission>((obj) =>
        {

        }));
        #endregion
    }
}
