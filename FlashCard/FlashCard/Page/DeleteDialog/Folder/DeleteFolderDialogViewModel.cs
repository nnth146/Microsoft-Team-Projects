using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class DeleteFolderDialogViewModel : ViewModelBase
    {
        public DeleteFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = WeakReferenceMessenger.Default.Send<FoldersRequestMessage>().Response;
            FolderModel = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }
        public FolderModel FolderModel { get; set; }

        private RelayCommand _deleteFolderCommand;
        public RelayCommand DeleteFolderCommand
        {
            get
            {
                if (_deleteFolderCommand == null)
                {
                    _deleteFolderCommand = new RelayCommand(() =>
                    {
                        FolderModels.Remove(FolderModel);
                        dialogService.HideCurrentDialog();
                    });
                }
                return _deleteFolderCommand;
            }
        }

        private RelayCommand _hideDialog;
        public RelayCommand HideDialog
        {
            get
            {
                if (_hideDialog == null)
                {
                    _hideDialog = new RelayCommand(() =>
                    {
                        dialogService.HideCurrentDialog();
                    });
                }
                return _hideDialog;
            }
        }
    }
}
