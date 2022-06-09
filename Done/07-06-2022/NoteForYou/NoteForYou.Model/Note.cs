using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class NoteType
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }

        public static List<NoteType> NoteTypes = new List<NoteType>
        {
            new NoteType
            {
                Name =  "BasicNote",
                Icon = "icon_note",
                IconColor = "icon_note_color"
            },
            new NoteType
            {
                Name =  "Address",
                Icon = "icon_address",
                IconColor = "icon_address_color"
            },new NoteType
            {
                Name =  "Contact",
                Icon = "icon_contact",
                IconColor = "icon_contact_color"
            },new NoteType
            {
                Name =  "List",
                Icon = "icon_listnote",
                IconColor = "icon_list_color"
            },
        };
    }

    public abstract class Note : ObservableObject
    {
        public int Id { get; set; }
        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { SetProperty(ref _createdOn, value); }
        }
        private DateTime _updatedOn;
        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { SetProperty(ref _updatedOn, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        
        public Note()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
    }
}
