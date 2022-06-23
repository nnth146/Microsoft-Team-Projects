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
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            FolderModels = dataService.GetFolders();
            TopicModels = dataService.GetTopics();
            FolderModels.CollectionChanged += FolderModels_CollectionChanged;
            WeakReferenceMessenger.Default.Register<ChangeMessage>(this, (r, m) =>
            {
                ChangeItem = m.Study;
                SelectedItemModel = m.Study;
            });
        }

        private void FolderModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddNewFolder(e.NewItems[0] as FolderModel);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                dataService.SaveChanges();
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.RemoveFolder(e.OldItems[0] as FolderModel);
            }
        }

        public ObservableCollection<FolderModel> FolderModels { get; set; }
        public ObservableCollection<StudyModel> StudyModels { get; set; }
        public ObservableCollection<TopicModel> TopicModels { get; set; }
        public int FolderModelCount { get => FolderModels.Count; }
        private object _selectedItemModel;
        public object SelectedItemModel
        {
            get { return _selectedItemModel; }
            set { SetProperty(ref _selectedItemModel, value); }
        }
        public object ChangeItem { get; set; }

        // Add new Folder Command Completed
        private RelayCommand _addNewFolderCommand;
        public RelayCommand AddNewFolderCommand
        {
            get
            {
                if (_addNewFolderCommand == null)
                {
                    _addNewFolderCommand = new RelayCommand(async () =>
                    {
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                        WeakReferenceMessenger.Default.Register<FoldersRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModels);
                        });
                        await dialogService.showAsync(typeof(AddFolderDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                    });
                }
                return _addNewFolderCommand;
            }
        }

        // Edit Folder Command Completed
        private RelayCommand<FolderModel> _editFolderCommand;
        public RelayCommand<FolderModel> EditFolderCommand
        {
            get
            {
                if (_editFolderCommand == null)
                {
                    _editFolderCommand = new RelayCommand<FolderModel>(async (selectedFolder) =>
                    {
                        WeakReferenceMessenger.Default.Register<FoldersRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModels);
                        });
                        WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedFolder);
                        });
                        await dialogService.showAsync(typeof(EditFolderDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                    });
                }
                return _editFolderCommand;
            }
        }

        // Delete Folder Command Completed
        private RelayCommand<FolderModel> _deleteFolderCommand;
        public RelayCommand<FolderModel> DeleteFolderCommand
        {
            get
            {
                if (_deleteFolderCommand == null)
                {
                    _deleteFolderCommand = new RelayCommand<FolderModel>(async (selectedFolder) =>
                    {
                        WeakReferenceMessenger.Default.Register<FoldersRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModels);
                        });
                        WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedFolder);
                        });
                        await dialogService.showAsync(typeof(DeleteFolderDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                    });
                }
                return _deleteFolderCommand;
            }
        }

        // Delete All Folder Command Completed
        private RelayCommand _deleteFolderAllCommand;
        public RelayCommand DeleteFolderAllCommand
        {
            get
            {
                if (_deleteFolderAllCommand == null)
                {
                    _deleteFolderAllCommand = new RelayCommand(async () =>
                    {
                        WeakReferenceMessenger.Default.Register<FoldersRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModels);
                        });
                        await dialogService.showAsync(typeof(DeleteAllFolderDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                    });
                }
                return _deleteFolderAllCommand;
            }
        }

        // Changed Folder Command
        private RelayCommand<object> _changeItemCommand;
        public RelayCommand<object> ChangeItemCommand
        {
            get
            {
                if (_changeItemCommand == null)
                {
                    _changeItemCommand = new RelayCommand<object>((selectedItem) =>
                    {
                        if (selectedItem != null)
                        {
                            Frame frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
                            if (selectedItem.ToString() == "Uwp.SQLite.Model.FolderModel")
                            {
                                WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                                {
                                    m.Reply(selectedItem as FolderModel);
                                });
                                navigationService.Navigate(frame, typeof(FolderPageViewModel));
                                WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                            }
                            if (selectedItem.ToString() == "Uwp.SQLite.Model.StudyModel")
                            {
                                WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                                WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                                {
                                    m.Reply(selectedItem as StudyModel);
                                });
                                navigationService.Navigate(frame, typeof(ViewStudyViewModel));
                                WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                            }
                        }
                    });
                }
                return _changeItemCommand;
            }
        }

        // Add New Study Command
        private RelayCommand<FolderModel> _addNewStudyCommand;
        public RelayCommand<FolderModel> AddNewStudyCommand
        {
            get
            {
                if (_addNewStudyCommand == null)
                {
                    _addNewStudyCommand = new RelayCommand<FolderModel>(async (selectedFolder) =>
                    {
                        WeakReferenceMessenger.Default.Register<FoldersRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(FolderModels);
                        });
                        WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedFolder);
                        });
                        await dialogService.showAsync(typeof(AddStudyDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                    });
                }
                return _addNewStudyCommand;
            }
        }

        // Learn now Command
        private RelayCommand<StudyModel> _learnNowCommand;
        public RelayCommand<StudyModel> LearnNowCommand
        {
            get
            {
                if (_learnNowCommand == null)
                {
                    _learnNowCommand = new RelayCommand<StudyModel>((selectedStudy) =>
                    {
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedStudy);
                        });
                        SelectedItemModel = selectedStudy;
                        OnPropertyChanged(nameof(SelectedItemModel));
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                        Frame frame = WeakReferenceMessenger.Default.Send<MPFrameRequestMessage>().Response;
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedStudy);
                        });
                        navigationService.Navigate(frame, typeof(CardPageViewModel));
                        WeakReferenceMessenger.Default.Unregister<StudyRequestMessage>(this);
                    });
                }
                return _learnNowCommand;
            }
        }

        // Edit Study Command Completed
        private RelayCommand<StudyModel> _editStudyCommand;
        public RelayCommand<StudyModel> EditStudyCommand
        {
            get
            {
                if (_editStudyCommand == null)
                {
                    _editStudyCommand = new RelayCommand<StudyModel>(async (selectedStudy) =>
                    {
                        for (int i = 0; i < FolderModelCount; i++)
                        {
                            for (int j = 0; j < FolderModels[i].StudyModels.Count; j++)
                            {
                                if (FolderModels[i].StudyModels[j] == selectedStudy)
                                {
                                    StudyModels = FolderModels[i].StudyModels;
                                }
                            }
                        }
                        WeakReferenceMessenger.Default.UnregisterAll(this);
                        WeakReferenceMessenger.Default.Register<StudiesRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModels);
                        });
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedStudy);
                        });
                        await dialogService.showAsync(typeof(EditStudyDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<StudiesRequestMessage>(this);
                    });
                }
                return _editStudyCommand;
            }
        }

        // Delete Study Command
        private RelayCommand<StudyModel> _deleteStudyCommand;
        public RelayCommand<StudyModel> DeleteStudyCommand
        {
            get
            {
                if (_deleteStudyCommand == null)
                {
                    _deleteStudyCommand = new RelayCommand<StudyModel>(async (selectedStudy) =>
                    {
                        for (int i = 0; i < FolderModelCount; i++)
                        {
                            for (int j = 0; j < FolderModels[i].StudyModels.Count; j++)
                            {
                                if (FolderModels[i].StudyModels[j] == selectedStudy)
                                {
                                    StudyModels = FolderModels[i].StudyModels;
                                }
                            }
                        }
                        WeakReferenceMessenger.Default.UnregisterAll(this);
                        WeakReferenceMessenger.Default.Register<StudiesRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModels);
                        });
                        WeakReferenceMessenger.Default.Register<StudyRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(selectedStudy);
                        });
                        await dialogService.showAsync(typeof(DeleteStudyDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<FoldersRequestMessage>(this);
                        WeakReferenceMessenger.Default.Unregister<StudiesRequestMessage>(this);
                    });
                }
                return _deleteStudyCommand;
            }
        }

        // Delete All Study Command Completed
        private RelayCommand<StudyModel> _deleteAllStudyCommand;
        public RelayCommand<StudyModel> DeleteAllStudyCommand
        {
            get
            {
                if (_deleteAllStudyCommand == null)
                {
                    _deleteAllStudyCommand = new RelayCommand<StudyModel>(async (selectedStudy) =>
                    {
                        for (int i = 0; i < FolderModelCount; i++)
                        {
                            for (int j = 0; j < FolderModels[i].StudyModels.Count; j++)
                            {
                                if (FolderModels[i].StudyModels[j] == selectedStudy)
                                {
                                    StudyModels = FolderModels[i].StudyModels;
                                }
                            }
                        }
                        WeakReferenceMessenger.Default.Register<StudiesRequestMessage>(this, (r, m) =>
                        {
                            m.Reply(StudyModels);
                        });
                        await dialogService.showAsync(typeof(DeleteAllStudyDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<StudiesRequestMessage>(this);
                    });
                }
                return _deleteAllStudyCommand;
            }
        }

        // Search Folder Command
        private ObservableCollection<FolderModel> _searchedFolder;
        public ObservableCollection<FolderModel> SearchedFolder { get { return _searchedFolder; } set { SetProperty(ref _searchedFolder, value); } }

        private string _searchedText;
        public string SearchedText { get { return _searchedText; } set { SetProperty(ref _searchedText, value); } }

        private RelayCommand _searchedTextChangedCommand;
        public RelayCommand SearchedTextChangeddCommand => _searchedTextChangedCommand ?? (_searchedTextChangedCommand = new RelayCommand(() =>
        {
            ObservableCollection<FolderModel> searchedFolder = new ObservableCollection<FolderModel>();
            foreach (var folder in FolderModels)
            {
                if (folder.Name.Contains(SearchedText))
                {
                    searchedFolder.Add(folder);
                }
            }
            SearchedFolder = searchedFolder;
        }));

        private RelayCommand<FolderModel> _suggestionChosenCommand;
        public RelayCommand<FolderModel> SuggestionChosenCommand => _suggestionChosenCommand ?? (_suggestionChosenCommand = new RelayCommand<FolderModel>((selectedFolder) =>
        {
            SearchedText = selectedFolder.Name;
        }));
    }
}
