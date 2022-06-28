using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace FlashCard.ViewModel
{
    public class DeleteAllFolderDialogViewModel : ViewModelBase
    {
        public DeleteAllFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = WeakReferenceMessenger.Default.Send<FoldersRequestMessage>().Response;
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }

        private RelayCommand _deleteFolderCommand;
        public RelayCommand DeleteFolderCommand
        {
            get
            {
                if (_deleteFolderCommand == null)
                {
                    _deleteFolderCommand = new RelayCommand(() =>
                    {
                        int count = FolderModels.Count;
                        for (int i = 0; i < count; i++)
                        {
                            FolderModels.Remove(FolderModels[0]);
                        }
                        dataService.SaveChanges();
                        Frame Frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
                        navigationService.Navigate(Frame, typeof(EmptyFlashCardViewModel));
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
