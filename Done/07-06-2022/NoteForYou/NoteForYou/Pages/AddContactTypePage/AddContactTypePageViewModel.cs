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
    public class AddContactTypePageViewModel : ViewModelBase
    {
        public AddContactTypePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public override void InitializeComponent()
        {
            
        }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

        private RelayCommand _saveNoteCommand;
        public RelayCommand SaveNoteCommand => _saveNoteCommand ?? (_saveNoteCommand = new RelayCommand(async () =>
        {
            if (string.IsNullOrEmpty(Title) && string.IsNullOrWhiteSpace(Title))
            {
                return;
            }
            var addedNote = new ContactNote
            {
                Title = Title,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Company = Company,
                Email = Email,
                Phone = Phone,
                Note = Note
            };
            using (var db = new DataContext())
            {
                db.ContactNotes.Add(addedNote);
                await db.SaveChangesAsync();
            }

            messengerService.Send<NotesPageUpdateUIBehavior>();
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }));

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
        {
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }));
    }
}
