using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Messenger;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class ContactPageViewModel : ViewModelBase
    {
        public ContactPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public override void InitializeComponent()
        {
            SelectedNote = messengerService.Send<SelectedNoteRequestMessage>().Response as ContactNote;
        }

        public ContactNote SelectedNote { get; set; }

        private RelayCommand _saveEditCommand;
        public RelayCommand SaveEditCommand => _saveEditCommand ?? (_saveEditCommand = new RelayCommand(() =>
        {
            SelectedNote.UpdatedOn = DateTime.Now;
            messengerService.Send<SaveChangeDb>();
        }));
    }
}
