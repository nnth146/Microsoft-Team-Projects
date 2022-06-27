using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace FlashCard.ViewModel
{
    public class DeleteTopicDialogViewModel : ViewModelBase
    {
        public DeleteTopicDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            TopicModels = WeakReferenceMessenger.Default.Send<TopicsRequestMessage>().Response;
            TopicModel = WeakReferenceMessenger.Default.Send<TopicRequestMessage>().Response;
        }

        public ObservableCollection<TopicModel> TopicModels { get; set; }
        public TopicModel TopicModel { get; set; }

        private RelayCommand _deleteTopicCommand;
        public RelayCommand DeleteTopicCommand
        {
            get
            {
                if (_deleteTopicCommand == null)
                {
                    _deleteTopicCommand = new RelayCommand(() =>
                    {
                        TopicModels.Remove(TopicModel);
                        dataService.SaveChanges();
                        dialogService.HideCurrentDialog();
                    });
                }
                return _deleteTopicCommand;
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
