using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace FlashCard.ViewModel
{
    public class CardPageViewModel : ViewModelBase
    {
        public CardPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            StudyModel = WeakReferenceMessenger.Default.Send<StudyRequestMessage>().Response;
            Frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
            IndexTopic = 1;
            if (StudyModel.TopicModels.Count > 0)
            {
                TopicModel = StudyModel.TopicModels[0];
                CheckFace = false;
                HasItem = true;
            }
            else
            {
                TopicModel = new TopicModel();
                HasItem = false;
            }
            ChangedEnable();
            isTeachingTipEnable = false;
        }

        public StudyModel StudyModel { get; set; }
        public TopicModel TopicModel { get; set; }
        public bool HasItem { get; set; }
        public int IndexTopic { get; set; }
        public int CountTopic { get => StudyModel.TopicModels.Count; }
        public bool CheckFace { get; set; }
        public bool isPrevEnable { get; set; }
        public bool isNextEnable { get; set; }
        public bool isTeachingTipEnable { get; set; }
        public Frame Frame { get; set; }

        public void ChangedEnable()
        {
            if (IndexTopic == CountTopic)
            {
                isPrevEnable = true;
                isNextEnable = false;
            }
            else if (IndexTopic == 1)
            {
                isPrevEnable = false;
                isNextEnable = true;
            }
            else
            {
                isPrevEnable = true;
                isNextEnable = true;
            }
            OnPropertyChanged(nameof(isNextEnable));
            OnPropertyChanged(nameof(isPrevEnable));
        }

        private RelayCommand _changedFaceCommand;
        public RelayCommand ChangedFaceCommand
        {
            get
            {
                if (_changedFaceCommand == null)
                {
                    _changedFaceCommand = new RelayCommand(() =>
                    {
                        CheckFace = !CheckFace;
                        OnPropertyChanged(nameof(CheckFace));
                    });
                }
                return _changedFaceCommand;
            }
        }

        private RelayCommand _nextItemCommand;
        public RelayCommand NextItemCommand
        {
            get
            {
                if (_nextItemCommand == null)
                {
                    _nextItemCommand = new RelayCommand(() =>
                    {
                        CheckFace = false;
                        OnPropertyChanged(nameof(CheckFace));
                        if (IndexTopic < CountTopic)
                        {
                            IndexTopic += 1;
                            TopicModel = StudyModel.TopicModels[IndexTopic - 1];
                            OnPropertyChanged(nameof(TopicModel));
                            OnPropertyChanged(nameof(IndexTopic));
                            ChangedEnable();
                            HideTeachingTip();
                        }
                    });
                }
                return _nextItemCommand;
            }
        }

        private RelayCommand _prevItemCommand;
        public RelayCommand PrevItemCommand
        {
            get
            {
                if (_prevItemCommand == null)
                {
                    _prevItemCommand = new RelayCommand(() =>
                    {
                        CheckFace = false;
                        OnPropertyChanged(nameof(CheckFace));
                        if (IndexTopic > 1)
                        {
                            IndexTopic -= 1;
                            TopicModel = StudyModel.TopicModels[IndexTopic - 1];
                            OnPropertyChanged(nameof(TopicModel));
                            OnPropertyChanged(nameof(IndexTopic));
                            ChangedEnable();
                            HideTeachingTip();
                        }
                    });
                }
                return _prevItemCommand;
            }
        }

        private RelayCommand _memoriItemCommand;
        public RelayCommand MemoriItemCommand
        {
            get
            {
                if (_memoriItemCommand == null)
                {
                    _memoriItemCommand = new RelayCommand(() =>
                    {
                        if (TopicModel.isFavorite == false)
                        {
                            StudyModel Study = StudyModel;
                            TopicModel.isFavorite = true;
                            OnPropertyChanged(nameof(TopicModel));
                            for (int i = 0; i < Study.TopicModels.Count; i++)
                            {
                                if (Study.TopicModels[i].TopicModelId == TopicModel.TopicModelId)
                                {
                                    Study.TopicModels[i] = TopicModel;
                                    break;
                                }
                            }
                            StudyModel = Study;
                            dataService.SaveChanges();
                            showTeachingTip();
                        }
                        else
                        {
                            StudyModel Study = StudyModel;
                            TopicModel.isFavorite = false;
                            OnPropertyChanged(nameof(TopicModel));
                            for (int i = 0; i < Study.TopicModels.Count; i++)
                            {
                                if (Study.TopicModels[i].TopicModelId == TopicModel.TopicModelId)
                                {
                                    Study.TopicModels[i] = TopicModel;
                                    break;
                                }
                            }
                            StudyModel = Study;
                            dataService.SaveChanges();
                            HideTeachingTip();
                        }
                    });
                }
                return _memoriItemCommand;
            }
        }

        private void HideTeachingTip()
        {
            isTeachingTipEnable = false;
            OnPropertyChanged(nameof(isTeachingTipEnable));
        }

        private async void showTeachingTip()
        {

            isTeachingTipEnable = true;
            OnPropertyChanged(nameof(isTeachingTipEnable));
            await Task.Delay(2000);
            HideTeachingTip();
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
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModel);
                        });
                        navigationService.GoBack(Frame);
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                    });
                }
                return _backFrameCommand;
            }
        }*/
    }
}
