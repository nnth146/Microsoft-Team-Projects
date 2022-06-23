using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.StoreService;
using UWP.Core.Service;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace NoteForYou.ViewModel
{
    public class AddImageNotePageViewModel : ViewModelBase
    {
        public AddImageNotePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        public override void InitializeComponent()
        {
            
        }

        public string Title { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public bool HasImage => Image != null;

        private RelayCommand _addImageCommand;
        public RelayCommand AddImageCommand => _addImageCommand ?? (_addImageCommand = new RelayCommand(async () =>
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Image = await CommonFunctionHelper.ConvertImageToByte(file);
                //Insert and save image in database
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(HasImage));
            }
        }));
        private RelayCommand<object> _addImageNoteCommand;
        public RelayCommand<object> AddImageNoteCommand => _addImageNoteCommand ?? (_addImageNoteCommand = new RelayCommand<object>(async (subFrame) =>
        {
            if(Image != null)
            {

                if (string.IsNullOrEmpty(Title) && string.IsNullOrWhiteSpace(Title))
                {
                    return;
                }

                bool isPremium = StoreHelper.Default.IsPremium;
                uint balance = StoreHelper.Default.Balance;

                if (isPremium)
                {
                    AddImageNote(subFrame); 
                    return;
                }
                if (balance > 0)
                {
                    StoreHelper.Default.FulfillConsumable();
                    AddImageNote(subFrame);
                    return;
                }

                await dialogService.showAsync(typeof(WaitingDialogViewModel));
                AddImageNote(subFrame); 
            }
        }));

        private void AddImageNote(object subFrame)
        {
            ImageNote addedNote = new ImageNote
            {
                Image = Image,
                Title = Title
            };
            using (var db = new DataContext())
            {
                db.ImageNotes.Add(addedNote);
                db.SaveChanges();
            }
            navigationService.GoBack(subFrame);
        }
    }
}
