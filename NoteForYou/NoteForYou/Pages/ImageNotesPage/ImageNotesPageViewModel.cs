using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Messenger;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class ImageNotesPageViewModel : ViewModelBase
    {
        public ImageNotesPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        public override void InitializeComponent()
        {
            ImageNotes = new ObservableCollection<ImageNote>(Db.ImageNotes.ToList());
        }

        private void RegisterMessenger()
        {
            messengerService.Register<SelectedNoteRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedNote);
            });

            messengerService.Register<SaveChangeDb>(this, (r, m) =>
            {
                Db.SaveChanges();
            });
        }

        private DataContext Db = new DataContext();

        public ObservableCollection<ImageNote> ImageNotes { get; set; }
        public ImageNote SelectedNote { get; set; }
        private RelayCommand<object> _addImageNoteCommand;
        public RelayCommand<object> AddImageNoteCommand => _addImageNoteCommand ?? (_addImageNoteCommand = new RelayCommand<object>((subFrame) =>
        {
            navigationService.Navigate(subFrame, typeof(AddImageNotePageViewModel));
        }));

        private RelayCommand<ImageNote> _removeImageNoteCommand;
        public RelayCommand<ImageNote> RemoveImageNoteCommand => _removeImageNoteCommand ?? (_removeImageNoteCommand = new RelayCommand<ImageNote>((selectedNote) =>
        {
            ImageNotes.Remove(selectedNote);
            Db.ImageNotes.Remove(selectedNote);
            Db.SaveChanges();
        }));

        private RelayCommand<ImageNote> _editImageNoteCommand;
        public RelayCommand<ImageNote> EditImageNoteCommand => _editImageNoteCommand ?? (_editImageNoteCommand = new RelayCommand<ImageNote>((selectedNote) =>
        {
            
        }));
    }
}
