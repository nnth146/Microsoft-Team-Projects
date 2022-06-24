using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class DeleteAllCardDialogViewModel : ViewModelBase
    {
        public DeleteAllCardDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            TopicModels = WeakReferenceMessenger.Default.Send<TopicsRequestMessage>().Response;
        }

        public ObservableCollection<TopicModel> TopicModels { get; set; }

        private RelayCommand _deleteAllCardCommand;
        public RelayCommand DeleteAllCardCommand
        {
            get
            {
                if (_deleteAllCardCommand == null)
                {
                    _deleteAllCardCommand = new RelayCommand(() =>
                    {
                        int count = TopicModels.Count;
                        for (int i = 0; i < count; i++)
                        {
                            TopicModels.Remove(TopicModels[0]);
                        }
                        dataService.SaveChanges();
                        dialogService.HideCurrentDialog();
                    });
                }
                return _deleteAllCardCommand;
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
