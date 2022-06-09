using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Messenger;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class NotesPageViewModel : ViewModelBase
    {
        public NotesPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            
        }

        public override void InitializeComponent()
        {
            SetupFilterChecked();

            InitatilizeNotes();

            RegisterMessenger();
        }

        private void RegisterMessenger()
        {
            messengerService.Register<NotesPageUpdateUIBehavior>(this, (r, m) =>
            {
                InitatilizeNotes();
            });
            messengerService.Register<SelectedNoteRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedNote);
            });

            messengerService.Register<SaveChangeDb>(this, (r, m) =>
            {
                db.SaveChanges();
            });
        }

        private DataContext db = new DataContext();

        #region Manage Notes
        private ObservableCollection<Note> _notes;
        public ObservableCollection<Note> Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }
        private Note _selectedNote;
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set { SetProperty(ref _selectedNote, value ); }
        }

        //Dữ liệu được kiểm tra và lọc
        private bool _isSelectAllChecked;
        public bool IsSelectAllChecked
        {
            get { return _isSelectAllChecked; }
            set { SetProperty(ref _isSelectAllChecked, value); }
        }
        private bool _isNoteChecked;
        public bool IsNoteChecked
        {
            get { return _isNoteChecked; }
            set { SetProperty(ref _isNoteChecked, value); }
        }
        private bool _isAddressChecked;
        public bool IsAddressChecked
        {
            get { return _isAddressChecked; }
            set { SetProperty(ref _isAddressChecked, value); }
        }
        private bool _isContactChecked;
        public bool IsContactChecked
        {
            get { return _isContactChecked; }
            set { SetProperty(ref _isContactChecked, value); }
        }
        private bool _isListChecked;
        public bool IsListChecked
        {
            get { return _isListChecked; }
            set { SetProperty(ref _isListChecked, value); }
        }

        private void SetupFilterChecked()
        {
            IsSelectAllChecked = true;
            IsNoteChecked = true;
            IsAddressChecked = true;
            IsListChecked = true;
            IsContactChecked = true;
        }

        private void InitatilizeNotes()
        {
            var basicNotes = db.BasicNotes.ToList();
            var addressNotes = db.AddressNotes.ToList();
            var contactNotes = db.ContactNotes.ToList();
            var listNotes = db.ListNotes.Include(n => n.SubNotes).ToList();
            var notes = new ObservableCollection<Note>();

            if (IsNoteChecked)
            {
                foreach (var note in basicNotes)
                {
                    notes.Add(note);
                }
            }
            if (IsAddressChecked)
            {
                foreach (var note in addressNotes)
                {
                    notes.Add(note);
                }
            }
            if (IsContactChecked)
            {
                foreach (var note in contactNotes)
                {
                    notes.Add(note);
                }
            }
            if (IsListChecked)
            {
                foreach (var note in listNotes)
                {
                    notes.Add(note);
                }
            }

            //Sắp xếp theo created on
            notes = new ObservableCollection<Note>(notes.OrderBy(x => x.CreatedOn).Reverse());
            Notes = notes;
        }

        //Xử lý tương tác Filter
        private RelayCommand _isSelectAllCheckedCommand;
        public RelayCommand IsSelectAllCheckedCommand => _isSelectAllCheckedCommand ?? (_isSelectAllCheckedCommand = new RelayCommand(() =>
        {
            if(IsNoteChecked && IsAddressChecked && IsListChecked && IsContactChecked)
            {
                IsNoteChecked = false;
                IsAddressChecked = false;
                IsListChecked = false;
                IsContactChecked = false;
            }
            else
            {
                IsNoteChecked = true;
                IsAddressChecked = true;
                IsListChecked = true;
                IsContactChecked = true;
            }
            InitatilizeNotes();
        }));
        private RelayCommand _isOtherCheckedCommand;
        public RelayCommand IsOtherCheckedCommand => _isOtherCheckedCommand ?? (_isOtherCheckedCommand = new RelayCommand(() =>
        {
            IsSelectAllChecked = IsNoteChecked && IsAddressChecked && IsListChecked && IsContactChecked;
            InitatilizeNotes();
        }));

        //Tìm kiếm Note
        private ObservableCollection<Note> _searchedNotes;
        public ObservableCollection<Note> SearchedNotes
        {
            get { return _searchedNotes; }
            set { SetProperty(ref _searchedNotes, value); }
        }
        private string _searchedText;
        public string SearchedText
        {
            get { return _searchedText; }
            set { SetProperty(ref _searchedText, value); }
        }
        private RelayCommand _searchedTextChangedCommand;
        public RelayCommand SearchedTextChangedCommand => _searchedTextChangedCommand ?? (_searchedTextChangedCommand = new RelayCommand(() =>
        {
            var searchedNote = new ObservableCollection<Note>();
            foreach(var note in Notes)
            {
                if (note.Title.Contains(SearchedText))
                {
                    searchedNote.Add(note);
                }
            }
            SearchedNotes = searchedNote;
        }));
        private RelayCommand<Note> _chosenSuggestionCommand;
        public RelayCommand<Note> ChosenSuggestionCommand => _chosenSuggestionCommand ?? (_chosenSuggestionCommand = new RelayCommand<Note>((selectedNote) =>
        {
            SearchedText = selectedNote.Title;
            SelectedNote = selectedNote;
        }));

        //Thêm, xoá Note
        //Thêm Note
        private RelayCommand _addNoteCommand;
        public RelayCommand AddNoteCommand => _addNoteCommand ?? (_addNoteCommand = new RelayCommand(() =>
        {
            var subFrame = messengerService.Send<FrameNavigatedRequestMessage>().Response;
            navigationService.NavigateOneTime(subFrame, typeof(AddNotePageViewModel));
        }));
        private RelayCommand<Note> _deleteNoteCommand;
        public RelayCommand<Note> DeleteNoteCommand => _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand<Note>(async (deletedNote) =>
        {
            switch (deletedNote.GetType().Name)
            {
                case "BasicNote":
                    db.BasicNotes.Remove(deletedNote as BasicNote);
                    Notes.Remove(deletedNote);
                    await db.SaveChangesAsync();
                    break;
                case "AddressNote":
                    db.AddressNotes.Remove(deletedNote as AddressNote);
                    Notes.Remove(deletedNote);
                    await db.SaveChangesAsync();
                    break;
                case "ContactNote":
                    db.ContactNotes.Remove(deletedNote as ContactNote);
                    Notes.Remove(deletedNote);
                    await db.SaveChangesAsync();
                    break;
                case "ListNote":
                    db.ListNotes.Remove(deletedNote as ListNote);
                    Notes.Remove(deletedNote);
                    await db.SaveChangesAsync();
                    break;
            }
        }));

        //Lựa chọn Note và xem Note
        private RelayCommand _selectionNoteChangedCommand;
        public RelayCommand SelectionNoteChangedCommand => _selectionNoteChangedCommand ?? (_selectionNoteChangedCommand = new RelayCommand(() =>
        {
            var subFrame = messengerService.Send<FrameNavigatedRequestMessage>().Response;
            if(SelectedNote != null)
            {
                switch (SelectedNote.GetType().Name)
                {
                    case "BasicNote":
                        navigationService.Navigate(subFrame, typeof(NotePageViewModel));
                        break;
                    case "AddressNote":
                        navigationService.Navigate(subFrame, typeof(AddressPageViewModel));
                        break;
                    case "ContactNote":
                        navigationService.Navigate(subFrame, typeof(ContactPageViewModel));
                        break;
                    case "ListNote":
                        navigationService.Navigate(subFrame, typeof(ListPageViewModel));
                        break;
                }
            }
            else
            {
                navigationService.GoBackToEnd(subFrame);
            }
        }));
        #endregion
    }
}
