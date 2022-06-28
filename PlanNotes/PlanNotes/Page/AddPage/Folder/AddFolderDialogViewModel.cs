using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class AddFolderDialogViewModel : ViewModelBase
    {
        public AddFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plans = WeakReferenceMessenger.Default.Send<PlansRequestMessage>().Response;
            Plan = WeakReferenceMessenger.Default.Send<PlanRequestMessage>().Response;
            NameFolder = "";
        }

        public ObservableCollection<Plan> Plans { get; set; }
        public Plan Plan { get; set; }
        public string NameFolder { get; set; }

        private RelayCommand _addFolderCommand;
        public RelayCommand AddFolderCommand => _addFolderCommand ?? (_addFolderCommand = new RelayCommand(() =>
        {
            Folder Folder = new Folder();
            Folder.FolderName = string.IsNullOrEmpty(NameFolder) ? "NameFolder..." : NameFolder;
            Folder.PlanId = Plan.PlanId;
            Folder.Plan = Plan;
            Folder.FolderNotes = new ObservableCollection<Note>();
            Folder.FolderCreate_On = System.DateTime.Now.ToLocalTime();
            Plan.PlanFolders.Add(Folder);
            dataService.AddNewFolder(Folder);
        }));
    }
}
