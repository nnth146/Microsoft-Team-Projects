using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class AddFolderDialogViewModel : ViewModelBase
    {
        public AddFolderDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = WeakReferenceMessenger.Default.Send<FoldersRequestMessage>().Response;
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }

        public string NameFolder { get; set; }
        public string DescriptionFolder { get; set; }

        private RelayCommand _addNewFolderCommand;
        public RelayCommand AddNewFolderCommand
        {
            get
            {
                if (_addNewFolderCommand == null)
                {
                    _addNewFolderCommand = new RelayCommand(() =>
                    {
                        FolderModel FolderModel = new FolderModel();
                        FolderModel.Name = string.IsNullOrEmpty(NameFolder) ? "NameFolder..." : NameFolder;
                        FolderModel.Description = string.IsNullOrEmpty(DescriptionFolder) ? "DescriptionFolder..." : DescriptionFolder;
                        FolderModel.Type = FolderModel.ExplorerItemType.Folder;
                        FolderModel.Create_On = DateTime.Now.ToLocalTime();
                        FolderModels.Add(FolderModel);
                        dialogService.HideCurrentDialog();
                    });
                }
                return _addNewFolderCommand;
            }
        }
    }
}
