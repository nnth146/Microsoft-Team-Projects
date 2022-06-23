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
    public class ViewStudyViewModel : ViewModelBase
    {
        public ViewStudyViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            StudyModel = WeakReferenceMessenger.Default.Send<StudyRequestMessage>().Response;
            Frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
        }

        public StudyModel StudyModel { get; set; }
        public ObservableCollection<TopicModel> TopicModels { get; set; }
        public Frame Frame { get; set; }

        private RelayCommand _editTopicCommand;
        public RelayCommand EditTopicCommand
        {
            get
            {
                if (_editTopicCommand == null)
                {
                    _editTopicCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModel);
                        });
                        navigationService.Navigate(Frame, typeof(AddAndEditCardViewModel));
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                    });
                }
                return _editTopicCommand;
            }
        }

        /*private RelayCommand _backFrameCommand;
        public RelayCommand BackFrameCommand
        {
            get
            {
                if (_backFrameCommand == null)
                {
                    _backFrameCommand = new RelayCommand(() =>
                    {
                        ObservableCollection<FolderModel> FolderModels = dataService.GetFolders();
                        FolderModel FolderModel = new FolderModel();
                        for (int i = 0; i < FolderModels.Count; i++)
                        {
                            for (int j = 0; j < FolderModels[i].StudyModels.Count; j++)
                            {
                                if (FolderModels[i].StudyModels[j].StudyModelId == StudyModel.StudyModelId)
                                {
                                    FolderModel = FolderModels[i];
                                }
                            }
                        }
                        WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModel);
                        });
                        navigationService.GoBack(Frame);
                        WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                    });
                }
                return _backFrameCommand;
            }
        }*/
    }
}
