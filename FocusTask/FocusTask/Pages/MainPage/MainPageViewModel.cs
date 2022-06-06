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
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            SetupProjects();

            RegisterMessenger();
        }

        private void Projects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddProject(e.NewItems[0] as Project);
            }
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.RemoveProject(e.OldItems[0] as Project);  
            }
        }

        private void RegisterMessenger()
        {
            messengerService.Register<SelectedProjectRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedProject);
            });

            messengerService.Register<EditedProjectRequestMessage>(this, (r, m) =>
            {
                m.Reply(EditedProject);
            });

            messengerService.Register<ProjectsRequestMessage>(this, (r, m) =>
            {
                m.Reply(Projects);
            });
        }

        #region Xử lý NavigationView
        public ObservableCollection<NavItem> NavItems { get; set; } = new ObservableCollection<NavItem>
        {
            new NavItem
            {
                Content = "My Day",
                Icon = CommonHelper.GetAppResources("MyDayIcon") as string,
                Page = typeof(MydayPageViewModel)
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
                Content = "Someday",
                Icon = CommonHelper.GetAppResources("SomedayIcon") as string,
                Page = typeof(SomedayPageViewModel)
            },
            new NavItem
            {
                Content = "Completed",
                Icon = CommonHelper.GetAppResources("CompletedIcon") as string,
                Page = typeof(CompletedPageViewModel)
            }
        };
        public NavItem SelectedNavItem { get; set; }

        private RelayCommand<NavItem> _navSelectionChangedCommand;
        public RelayCommand<NavItem> NavSelectionChangedCommand => _navSelectionChangedCommand ?? (_navSelectionChangedCommand = new RelayCommand<NavItem>((obj) =>
        {
            var frame = messengerService.Send<MPFrameRequestMessage>().Response;

            navigationService.Navigate(frame, obj.Page);
        }));

        private RelayCommand<Project> _projectsSelectionChangedCommand;
        public RelayCommand<Project> ProjectsSelectionChangedCommand => _projectsSelectionChangedCommand ?? (_projectsSelectionChangedCommand = new RelayCommand<Project>((obj) =>
        {
            var frame = messengerService.Send<MPFrameRequestMessage>().Response;

            SelectedProject = obj;

            navigationService.Navigate(frame, typeof(ProjectPageViewModel));
        }));
        #endregion

        #region Xử lý Project

        public ObservableCollection<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public Project EditedProject { get; set; }
        
        private void SetupProjects()
        {
            Projects = dataService.GetProjects();
            Projects.CollectionChanged += Projects_CollectionChanged;

            if(Projects.Count < 1)
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
    }
}
