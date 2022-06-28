using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class EditStudyDialogViewModel : ViewModelBase
    {
        public EditStudyDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            StudyModels = WeakReferenceMessenger.Default.Send<StudiesRequestMessage>().Response;
            StudyModel = WeakReferenceMessenger.Default.Send<ContextStudyRequestMessage>().Response;
        }

        public ObservableCollection<StudyModel> StudyModels { get; set; }
        public StudyModel StudyModel { get; set; }

        private RelayCommand _editStudyCommand;
        public RelayCommand EditStudyCommand
        {
            get
            {
                if (_editStudyCommand == null)
                {
                    _editStudyCommand = new RelayCommand(() =>
                    {
                        for (int i = 0; i < StudyModels.Count; i++)
                        {
                            if (StudyModels[i].StudyModelId == StudyModel.StudyModelId)
                            {
                                StudyModels[i] = StudyModel;
                                break;
                            }
                        }
                        dataService.SaveChanges();
                        dialogService.HideCurrentDialog();
                    });
                }
                return _editStudyCommand;
            }
        }
    }
}
