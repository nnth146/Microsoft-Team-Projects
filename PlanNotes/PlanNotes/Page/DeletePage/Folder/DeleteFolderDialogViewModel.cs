using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class DeleteFolderDialogViewModel : ViewModelBase
    {
        public DeleteFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plan = WeakReferenceMessenger.Default.Send<PlanRequestMessage>().Response;
            Folder = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
        }

        public Plan Plan { get; set; }
        public Folder Folder { get; set; }

        // RelayCommand
        private RelayCommand _deleteFolderCommand;
        public RelayCommand DeleteFolderCommand => _deleteFolderCommand ?? (_deleteFolderCommand = new RelayCommand(() =>
        {
            Plan.PlanFolders.Remove(Folder);
            dataService.RemoveFolder(Folder);
            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _hideDialogCommand;
        public RelayCommand HideDialogCommand => _hideDialogCommand ?? (_hideDialogCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
