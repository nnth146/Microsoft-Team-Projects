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
    public class AddNotePageViewModel : ViewModelBase
    {
        public AddNotePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        public override void InitializeComponent()
        {
            NoteTypes = NoteType.NoteTypes;
            SelectedNoteType = NoteTypes[0];
        }

        //Danh sách các kiểu Note mà có thể lựa chọn
        public List<NoteType> NoteTypes { get; set; }
        public NoteType SelectedNoteType { get; set; }

        private RelayCommand<object> _typeSelectionChangedCommand;
        public RelayCommand<object> TypeSelectionChangedCommand => _typeSelectionChangedCommand ?? (_typeSelectionChangedCommand = new RelayCommand<object>((navigatedFrame) =>
        {
            if(SelectedNoteType != null)
            {
                switch (SelectedNoteType.Name)
                {
                    case "BasicNote": 
                        navigationService.Navigate(navigatedFrame, typeof(AddNoteTypePageViewModel));
                        break;
                    case "Address":
                        navigationService.Navigate(navigatedFrame, typeof(AddAddressTypePageViewModel));
                        break;
                    case "Contact":
                        navigationService.Navigate(navigatedFrame, typeof(AddContactTypePageViewModel));
                        break;
                    case "List":
                        navigationService.Navigate(navigatedFrame, typeof(AddListTypePageViewModel));
                        break;
                }
            }
        }));
    }
}
