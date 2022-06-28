﻿using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class AddNoteDialogViewModel : ViewModelBase
    {
        public AddNoteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Notes = WeakReferenceMessenger.Default.Send<NotesRequestMessage>().Response;
            dateTime = WeakReferenceMessenger.Default.Send<DateTimeRequestMessage>().Response;
            Folders = dataService.GetFolders();
            SelectedFolder = Folders[0];
        }

        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<Folder> Folders { get; set; }
        public Folder SelectedFolder { get; set; }

        public string NoteName { get; set; }
        public string NoteDesctiption { get; set; }
        public DateTime dateTime { get; set; }


        // RelayCommand
        private RelayCommand _addNoteCommand;
        public RelayCommand AddNoteCommand => _addNoteCommand ?? (_addNoteCommand = new RelayCommand(() =>
        {
            Note note = new Note();
            note.NoteName = string.IsNullOrEmpty(NoteName) ? "NoteName..." : NoteName;
            note.NoteDescription = string.IsNullOrEmpty(NoteDesctiption) ? "NoteDesCription..." : NoteDesctiption;
            note.NoteDueDate = dateTime;
            note.NoteCreate_On = DateTime.Now.ToLocalTime();
            note.AmountStep = 0;
            note.StepCompleted = 0;
            note.IsCompleted = false;
            note.FolderId = SelectedFolder.FolderId;
            Notes.Add(note);
            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _hideDialogCommand;
        public RelayCommand HideDialogCommand => _hideDialogCommand ?? (_hideDialogCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
