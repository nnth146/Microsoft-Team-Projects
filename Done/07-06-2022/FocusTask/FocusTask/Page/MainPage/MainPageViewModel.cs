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
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Missions = dataService.GetMissions();

            SetupNavItems();

            SetupProjects();

            RegisterMessenger();

            SetupNotificationMissions();
        }

        private void Projects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddProject(e.NewItems[0] as Project);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.RemoveProject(e.OldItems[0] as Project);
            }
        }

        private void RegisterMessenger()
        {
            WeakReferenceMessenger.Default.Register<SelectedProjectRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedProject);
            });

            WeakReferenceMessenger.Default.Register<EditedProjectRequestMessage>(this, (r, m) =>
            {
                m.Reply(EditedProject);
            });

            WeakReferenceMessenger.Default.Register<ProjectsRequestMessage>(this, (r, m) =>
            {
                m.Reply(Projects);
            });
        }

        #region Xử lý NavigationView
        public ObservableCollection<NavItem> NavItems { get; set; }
        private NavItem _selectedNavItem;
        public NavItem SelectedNavItem
        {
            get { return _selectedNavItem; }
            set { SetProperty(ref _selectedNavItem, value); }
        }

        private void SetupNavItems()
        {
            NavItems = new ObservableCollection<NavItem>
        {
            new NavItem
            {
                Content = "My Day",
                Icon = CommonHelper.GetAppResources("MyDayIcon") as string,
                Page = typeof(MydayPageViewModel),
                Missions = dataService.GetMissions()
            },
            new NavItem
            {
                Content = "Tomorrow",
                Icon = CommonHelper.GetAppResources("TomorrowIcon") as string,
                Page = typeof(TomorrowPageViewModel)
            },
            new NavItem
            {
                Content = "Upcoming",
                Icon = CommonHelper.GetAppResources("UpcomingIcon") as string,
                Page = typeof(UpcomingPageViewModel)
            },
            new NavItem
            {
                Content = "Completed",
                Icon = CommonHelper.GetAppResources("CompletedIcon") as string,
                Page = typeof(CompletedPageViewModel)
            }
        };
        }

        private RelayCommand<NavItem> _navSelectionChangedCommand;
        public RelayCommand<NavItem> NavSelectionChangedCommand => _navSelectionChangedCommand ?? (_navSelectionChangedCommand = new RelayCommand<NavItem>((obj) =>
        {
            if (obj != null)
            {
                var frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;

                navigationService.Navigate(frame, obj.Page);

                SelectedProject = null;
            }
        }));

        private RelayCommand<Project> _projectsSelectionChangedCommand;
        public RelayCommand<Project> ProjectsSelectionChangedCommand => _projectsSelectionChangedCommand ?? (_projectsSelectionChangedCommand = new RelayCommand<Project>((obj) =>
        {
            if (obj != null)
            {
                var frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;

                SelectedProject = obj;

                navigationService.Navigate(frame, typeof(ProjectPageViewModel));

                SelectedNavItem = null;
            }
        }));
        #endregion

        #region Xử lý Project

        public ObservableCollection<Project> Projects { get; set; }
        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set { SetProperty(ref _selectedProject, value); }
        }
        public Project EditedProject { get; set; }

        private void SetupProjects()
        {
            Projects = dataService.GetProjects();
            Projects.CollectionChanged += Projects_CollectionChanged;

            if (Projects.Count < 1)
            {
                Projects.Add(new Project
                {
                    Name = "Task",
                    Color = "Color01"
                });
            }
        }

        private RelayCommand _addProjectCommand;
        public RelayCommand AddProjectCommand => _addProjectCommand ?? (_addProjectCommand = new RelayCommand(() =>
        {
            dialogService.showAsync(typeof(AddDialogViewModel));

            RemoveProjectCommand.NotifyCanExecuteChanged();
        }));

        private RelayCommand<Project> _removeProjectCommand;
        public RelayCommand<Project> RemoveProjectCommand => _removeProjectCommand ?? (_removeProjectCommand = new RelayCommand<Project>((obj) =>
        {
            Projects.Remove(obj);
        }, (obj) =>
        {
            return Projects.Count > 1;
        }));

        private RelayCommand<Project> _editProjectCommand;
        public RelayCommand<Project> EditProjectCommand => _editProjectCommand ?? (_editProjectCommand = new RelayCommand<Project>((obj) =>
        {
            EditedProject = obj;

            dialogService.showAsync(typeof(EditDialogViewModel));
        }));
        #endregion

        #region Notification
        private ObservableCollection<Mission> _notificationMissions;
        public ObservableCollection<Mission> NotificationMissions
        {
            get { return _notificationMissions; }
            set { SetProperty(ref _notificationMissions, value); }
        }

        public ObservableCollection<Mission> Missions { get; set; }

        private void SetupNotificationMissions()
        {
            var list = Missions
                .Where(x => (x.Reminder <= DateTime.Now))
                .Where(x => x.IsCompleted == false)
                .OrderBy(x => x.DateTime)
                .ToList();

            list.Reverse();
            NotificationMissions = new ObservableCollection<Mission>(list);
        }

        private RelayCommand<Mission> _comfirmNotificationCommand;
        public RelayCommand<Mission> ComfirmNotificationCommand => _comfirmNotificationCommand ?? (_comfirmNotificationCommand = new RelayCommand<Mission>((obj) =>
        {
            obj.Reminder = null;
            SetupNotificationMissions();
        }));

        private RelayCommand _donateCommand;
        public RelayCommand DonateCommand => _donateCommand ?? (_donateCommand = new RelayCommand(() =>
        {

        }));
        #endregion

        private RelayCommand _settingCommand;


        public RelayCommand SettingCommand => _settingCommand ?? (_settingCommand = new RelayCommand(() =>
        {
            var frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;

            navigationService.NavigateOneTime(frame, typeof(SettingPageViewModel));
        }));
    }
}
