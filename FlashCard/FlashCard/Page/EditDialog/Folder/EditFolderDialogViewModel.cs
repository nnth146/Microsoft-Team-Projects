using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class EditFolderDialogViewModel : ViewModelBase
    {
        public EditFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = WeakReferenceMessenger.Default.Send<FoldersRequestMessage>().Response;
            FolderModel = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
            NameFolder = FolderModel.Name;
            DescriptionFolder = FolderModel.Description;
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }
        public FolderModel FolderModel { get; set; }

        public string NameFolder { get; set; }
        public string DescriptionFolder { get; set; }

        private RelayCommand _editFolderCommand;
        public RelayCommand EditFolderCommand
        {
            get
            {
                if (_editFolderCommand == null)
                {
                    _editFolderCommand = new RelayCommand(() =>
                    {
                        FolderModel.Name = string.IsNullOrEmpty(NameFolder) ? "NameFolder..." : NameFolder;
                        FolderModel.Description = string.IsNullOrEmpty(DescriptionFolder) ? "DescriptionFolder..." : DescriptionFolder;
                        for (int i = 0; i < FolderModels.Count; i++)
                        {
                            if (FolderModels[i].FolderModelId == FolderModel.FolderModelId)
                            {
                                FolderModels[i] = FolderModel;
                                break;
                            }
                        }
                        dialogService.HideCurrentDialog();
                    });
                }
                return _editFolderCommand;
            }
        }
    }
}
