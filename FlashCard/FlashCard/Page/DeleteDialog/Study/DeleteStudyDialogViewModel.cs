using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class DeleteStudyDialogViewModel : ViewModelBase
    {
        public DeleteStudyDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            StudyModels = WeakReferenceMessenger.Default.Send<StudiesRequestMessage>().Response;
            StudyModel = WeakReferenceMessenger.Default.Send<StudyRequestMessage>().Response;
        }

        public ObservableCollection<StudyModel> StudyModels { get; set; }
        public StudyModel StudyModel { get; set; }

        private RelayCommand _deleteStudyCommand;
        public RelayCommand DeleteStudyCommand
        {
            get
            {
                if (_deleteStudyCommand == null)
                {
                    _deleteStudyCommand = new RelayCommand(() =>
                    {
                        StudyModels.Remove(StudyModel);
                        dataService.SaveChanges();
                        dialogService.HideCurrentDialog();
                    });
                }
                return _deleteStudyCommand;
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
