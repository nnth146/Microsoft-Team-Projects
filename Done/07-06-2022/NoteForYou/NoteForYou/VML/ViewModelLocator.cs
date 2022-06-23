using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NoteForYou.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteForYou.VML
{
    public class ViewModelLocator
    {
        public ImageNotesPageViewModel ImageNotesPage => Ioc.Default.GetService<ImageNotesPageViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public NotesPageViewModel NotesPage => Ioc.Default.GetService<NotesPageViewModel>();
        public SecureNotesPageViewModel SecureNotesPage => Ioc.Default.GetService<SecureNotesPageViewModel>();
        public NotePageViewModel NotePage => Ioc.Default.GetService<NotePageViewModel>();
        public AddNotePageViewModel AddNotePage => Ioc.Default.GetService<AddNotePageViewModel>();
        public AddressPageViewModel AddressPage => Ioc.Default.GetService<AddressPageViewModel>();
        public ContactPageViewModel ContactPage => Ioc.Default.GetService<ContactPageViewModel>();
        public ListPageViewModel ListPage => Ioc.Default.GetService<ListPageViewModel>();
        public AddAddressTypePageViewModel AddAddressTypePage => Ioc.Default.GetService<AddAddressTypePageViewModel>();
        public AddContactTypePageViewModel AddContactTypePage => Ioc.Default.GetService<AddContactTypePageViewModel>();
        public AddListTypePageViewModel AddListTypePage => Ioc.Default.GetService<AddListTypePageViewModel>();
        public AddNoteTypePageViewModel AddNoteTypePage => Ioc.Default.GetService<AddNoteTypePageViewModel>();
        public AddImageNotePageViewModel AddImageNotePage => Ioc.Default.GetService<AddImageNotePageViewModel>();
        public AddSecureNoteDialogViewModel AddSecureNoteDialog => Ioc.Default.GetService<AddSecureNoteDialogViewModel>();
        public EditSecureNoteDialogViewModel EditSecureNoteDialog => Ioc.Default.GetService<EditSecureNoteDialogViewModel>();
        public ShowSecureNoteDialogViewModel ShowSecureNoteDialog => Ioc.Default.GetService<ShowSecureNoteDialogViewModel>();
        public EditImageNotePageViewModel EditImageNotePage => Ioc.Default.GetService<EditImageNotePageViewModel>();
        public GiftDialogViewModel GiftDialog => Ioc.Default.GetService<GiftDialogViewModel>();
        public AddOnPageViewModel AddOnPage => Ioc.Default.GetService<AddOnPageViewModel>();
    }
}
