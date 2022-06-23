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
    public class AddStudyDialogViewModel : ViewModelBase
    {
        public AddStudyDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = WeakReferenceMessenger.Default.Send<FoldersRequestMessage>().Response;
            FolderModel = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }
        public FolderModel FolderModel { get; set; }
        public string NameStudy { get; set; }
        public string DescriptionStudy { get; set; }

        private RelayCommand _addNewStudyCommand;
        public RelayCommand AddNewStudyCommand
        {
            get
            {
                if (_addNewStudyCommand == null)
                {
                    _addNewStudyCommand = new RelayCommand(() =>
                    {
                        StudyModel StudyModel = new StudyModel();
                        StudyModel.Name = string.IsNullOrEmpty(NameStudy) ? "NameStudy..." : NameStudy;
                        StudyModel.Description = string.IsNullOrEmpty(DescriptionStudy) ? "DescriptionStudy..." : DescriptionStudy;
                        StudyModel.Type = StudyModel.ExplorerItemType.File;
                        StudyModel.Create_On = DateTime.Now.ToLocalTime();
                        FolderModel.StudyModels.Add(StudyModel);
                        dataService.SaveChanges();
                        dialogService.HideCurrentDialog();
                    });
                }
                return _addNewStudyCommand;
            }
        }
    }
}
