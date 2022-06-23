using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Diagnostics;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace FlashCard.ViewModel
{
    public class AddAndEditCardViewModel : ViewModelBase
    {
        public AddAndEditCardViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            StudyModel = WeakReferenceMessenger.Default.Send<StudyRequestMessage>().Response;
            Frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
            study = StudyModel;
        }

        public StudyModel StudyModel { get; set; }
        public Frame Frame { get; set; }
        public int TopicCount { get => StudyModel.TopicModels.Count; }
        public StudyModel study;

        private RelayCommand _addTopicCommand;
        public RelayCommand AddTopicCommand
        {
            get
            {
                if (_addTopicCommand == null)
                {
                    _addTopicCommand = new RelayCommand(() =>
                    {
                        TopicModel TopicModel = new TopicModel();
                        TopicModel.Name = "";
                        TopicModel.Defination = "";
                        TopicModel.Image = null;
                        TopicModel.hasItem = false;
                        TopicModel.isFavorite = false;
                        TopicModel.StudyModelId = StudyModel.StudyModelId;
                        Debug.WriteLine("Study Model Id: " + TopicModel.StudyModelId);
                        StudyModel.TopicModels.Add(TopicModel);
                        study.TopicModels = StudyModel.TopicModels;
                    });
                }
                return _addTopicCommand;
            }
        }

        private RelayCommand<TopicModel> _deleteTopicCommand;
        public RelayCommand<TopicModel> DeleteTopicCommand
        {
            get
            {
                if (_deleteTopicCommand == null)
                {
                    _deleteTopicCommand = new RelayCommand<TopicModel>((selectedTopic) =>
                    {
                        StudyModel.TopicModels.Remove(selectedTopic);
                    });
                }
                return _deleteTopicCommand;
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(() =>
                    {
                        dataService.SaveChanges();
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModel);
                        });
                        navigationService.Navigate(Frame, typeof(ViewStudyViewModel));
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                    });
                }
                return _saveCommand;
            }
        }

        private RelayCommand<TopicModel> _addImageCommand;
        public RelayCommand<TopicModel> AddImageCommand => _addImageCommand ?? (_addImageCommand = new RelayCommand<TopicModel>(async (selectedTopic) =>
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                for (int i = 0; i < study.TopicModels.Count; i++)
                {
                    if (study.TopicModels[i] == selectedTopic)
                    {
                        selectedTopic.Image = await CommonHelper.ConvertImageToByte(file);
                        selectedTopic.hasItem = true;
                        study.TopicModels[i] = selectedTopic;
                        StudyModel = study;
                        OnPropertyChanged(nameof(StudyModel));
                        break;
                    }
                }
            }
        }));
    }
}
