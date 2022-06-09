using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class ViewContactPageViewModel : ViewModelBase
    {
        public ViewContactPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Passwords = messengerService.Send<PasswordsRequestMessage>().Response;

            RegisterMessage();
        }

        private void RegisterMessage()
        {
            messengerService.Register<AddCommandRequestMessage>(this, (r, m) =>
            {
                m.Reply(AddPasswordCommand);
            });

            messengerService.Register<EditCommandRequestMessage>(this, (r, m) =>
            {
                m.Reply(EditPasswordCommand);
            });

            messengerService.Register<SelectedPasswordRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedPassword);
            });
        }

        #region Xử lý SplitView

        //Mở, đóng split
        private bool _isAddSplitViewOpen;
        public bool IsAddSplitViewOpen { get { return _isAddSplitViewOpen; } set { SetProperty(ref _isAddSplitViewOpen, value); } }
        private bool _isEditSplitViewOpen;
        public bool IsEditSplitViewOpen { get { return _isEditSplitViewOpen; } set { SetProperty(ref _isEditSplitViewOpen, value); } }

        private RelayCommand _openAddSplitViewCommand;
        public RelayCommand OpenAddSplitViewCommand => _openAddSplitViewCommand ?? (_openAddSplitViewCommand = new RelayCommand(() =>
        {
            var frame = messengerService.Send<AddPasswordFrameRequestMessage>().Response;
            //TODO
            navigationService.Navigate(frame, typeof(AddContactPageViewModel));

            IsAddSplitViewOpen = !IsAddSplitViewOpen;
        }));

        private RelayCommand _openEditSplitViewCommand;
        public RelayCommand OpenEditSplitViewCommand => _openEditSplitViewCommand ?? (_openEditSplitViewCommand = new RelayCommand(() =>
        {
            IsEditSplitViewOpen = !IsEditSplitViewOpen;
        }));

        #endregion

        #region Quản lý All Password

        public ObservableCollection<Password> Passwords { get; set; }

        //TODO
        public ObservableCollection<Contact> Contacts { get; set; } = Account.CurrentAccount.Contacts;

        private Password _selectedPassword;
        public Password SelectedPassword { get { return _selectedPassword; } set { SetProperty(ref _selectedPassword, value); } }

        private RelayCommand<Password> _addPasswordCommand;
        public RelayCommand<Password> AddPasswordCommand => _addPasswordCommand ?? (_addPasswordCommand = new RelayCommand<Password>((addedPassword) =>
        {
            Passwords.Insert(0, addedPassword);

            OpenAddSplitViewCommand.Execute(null);
        }));

        private RelayCommand _editPasswordCommand;
        public RelayCommand EditPasswordCommand => _editPasswordCommand ?? (_editPasswordCommand = new RelayCommand(async () =>
        {
            await dataService.SaveChangesAsync();

            OpenEditSplitViewCommand.Execute(null);
        }));

        private RelayCommand<Password> _removePasswordCommand;
        public RelayCommand<Password> RemovePasswordCommand => _removePasswordCommand ?? (_removePasswordCommand = new RelayCommand<Password>((deletedPassword) =>
        {
            Passwords.Remove(deletedPassword);
        }));

        private RelayCommand<Password> _passwordsItemClickCommand;
        public RelayCommand<Password> PasswordsItemClickCommand => _passwordsItemClickCommand ?? (_passwordsItemClickCommand = new RelayCommand<Password>((selectedPassword) =>
        {
            SelectedPassword = selectedPassword;

            var frame = messengerService.Send<EditPasswordFrameRequestMessage>().Response;

            var type = selectedPassword.GetType();
            //Need changed : EditPasswordPageViewModel
            switch (type.Name)
            {
                case nameof(CommonPassword):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditPasswordPageViewModel), null);
                    break;
                case nameof(Address):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditAddressPageViewModel), null);
                    break;
                case nameof(Contact):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditContactPageViewModel), null);
                    break;
                case nameof(Database):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditDatabasePageViewModel), null);
                    break;
                case nameof(SecureNote):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditSecurePageViewModel), null);
                    break;
                case nameof(Server):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditServerPageViewModel), null);
                    break;
                case nameof(Wifi):
                    navigationService.NavigateWithoutSaving(frame, typeof(EditWifiPageViewModel), null);
                    break;
            }

            OpenEditSplitViewCommand.Execute(null);
        }));
        #endregion

        #region Tìm kiếm Password

        private ObservableCollection<Password> _searchedPasswords;
        public ObservableCollection<Password> SearchedPasswords { get { return _searchedPasswords; } set { SetProperty(ref _searchedPasswords, value); } }

        private string _searchedText;
        public string SearchedText { get { return _searchedText; } set { SetProperty(ref _searchedText, value); } }

        private RelayCommand _searchedTextChangedCommand;
        public RelayCommand SearchedTextChangeddCommand => _searchedTextChangedCommand ?? (_searchedTextChangedCommand = new RelayCommand(() =>
        {
            var searchedPassword = new ObservableCollection<Password>();
            foreach (var password in Contacts)
            {
                if (password.Title.Contains(SearchedText))
                {
                    searchedPassword.Add(password);
                }
            }
            SearchedPasswords = searchedPassword;
        }));

        private RelayCommand<Password> _suggestionChosenCommand;
        public RelayCommand<Password> SuggestionChosenCommand => _suggestionChosenCommand ?? (_suggestionChosenCommand = new RelayCommand<Password>((selectedPassword) =>
        {
            SearchedText = selectedPassword.Title;
            PasswordsItemClickCommand.Execute(selectedPassword);
            messengerService.Send(new ScrollIntoViewRequestMessage<Password>(selectedPassword));
        }));
        #endregion
    }
}
