using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace FlashCard.ViewModel
{
    public class FolderPageViewModel : ViewModelBase
    {
        public FolderPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModel = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
            Frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
        }

        public FolderModel FolderModel { get; set; }
        public Frame Frame { get; set; }
        public StudyModel SelectedStudy { get; set; }


        private RelayCommand _selectedStudyCommand;
        public RelayCommand SelectedStudyCommand
        {
            get
            {
                if (_selectedStudyCommand == null)
                {
                    _selectedStudyCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Send(new ChangeMessage(SelectedStudy));
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(SelectedStudy);
                        });
                        navigationService.Navigate(Frame, typeof(ViewStudyViewModel));
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                    });
                }
                return _selectedStudyCommand;
            }
        }
    }
}
