using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plans = dataService.GetPlans();
            getFolder();
        }

        public void getFolder()
        {
            Folders = dataService.GetFolders();
        }

        public ObservableCollection<Plan> Plans { get; set; }
        public ObservableCollection<Folder> Folders { get; set; }
    }
}
