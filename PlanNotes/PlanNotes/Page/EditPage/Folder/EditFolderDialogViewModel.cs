using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class EditFolderDialogViewModel : ViewModelBase
    {
        public EditFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plan = WeakReferenceMessenger.Default.Send<PlanRequestMessage>().Response;
            Folder = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
        }

        public Plan Plan { get; set; }
        public Folder Folder { get; set; }

        // RelayCommand
        private RelayCommand _editFolderCommand;
        public RelayCommand EditFolderCommand => _editFolderCommand ?? (_editFolderCommand = new RelayCommand(() =>
        {
            Folder.FolderName = string.IsNullOrEmpty(Folder.FolderName) ? "FolderName... " : Folder.FolderName;
            for (int i = 0; i < Plan.PlanFolders.Count; i++)
            {
                if (Plan.PlanFolders[i].FolderId == Folder.FolderId)
                {
                    Plan.PlanFolders[i] = Folder;
                    break;
                }
            }
            dataService.SaveChanges();
            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _hideDialogCommand;
        public RelayCommand HideDialogCommand => _hideDialogCommand ?? (_hideDialogCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
