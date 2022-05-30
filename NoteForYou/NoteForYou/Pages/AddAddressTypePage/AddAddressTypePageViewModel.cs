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
    public class AddAddressTypePageViewModel : ViewModelBase
    {
        public AddAddressTypePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public override void InitializeComponent()
        {
            
        }

        public string Title { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string Country { get; set; }

        private RelayCommand _saveNoteCommand;
        public RelayCommand SaveNoteCommand => _saveNoteCommand ?? (_saveNoteCommand = new RelayCommand(async () =>
        {
            if (string.IsNullOrEmpty(Title) && string.IsNullOrWhiteSpace(Title))
            {
                return;
            }
            var addedNote = new AddressNote
            {
                Title = Title,
                StreetAddressLine1 = StreetAddressLine1,
                StreetAddressLine2 = StreetAddressLine2,
                City = City,
                Phone = Phone,
                ZipPostalCode = ZipPostalCode,
                Country = Country,
            };
            using (var db = new DataContext())
            {
                db.AddressNotes.Add(addedNote);
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
