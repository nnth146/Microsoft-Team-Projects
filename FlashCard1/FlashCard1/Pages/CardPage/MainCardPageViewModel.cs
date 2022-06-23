using FlashCard1.Pages.CardPage.Dialog;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.HCore.Service.Navigation;
using Windows.UI.Xaml.Controls;

namespace FlashCard1.Pages.CardPage
{
    public class MainCardPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        public MainCardPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private RelayCommand _openAddCardPageDialogCommand;
        public RelayCommand OpenAddCardPageDialogCommand => _openAddCardPageDialogCommand ?? (_openAddCardPageDialogCommand = new RelayCommand(async() =>
        {
            ContentDialog dialog = new AddCardDialog();
            await dialog.ShowAsync();
        }));

        private RelayCommand _goBackMainPageCommand;
        public RelayCommand GoBackMainPageCommand => _goBackMainPageCommand ?? (_goBackMainPageCommand = new RelayCommand(() =>
        {
            _navigationService.GoBack();
        }));

        private RelayCommand _openAskLearnDialogCommand;
        public RelayCommand OpenAskLearnDialogCommand => _openAskLearnDialogCommand ?? (_openAskLearnDialogCommand = new RelayCommand(async () =>
        {
            ContentDialog dialog = new AskLearnDialog();
            await dialog.ShowAsync();
        }));

        private RelayCommand _openResetAllDialogCommand;
        public RelayCommand OpenResetAllDialgCommand => _openResetAllDialogCommand ?? (_openResetAllDialogCommand = new RelayCommand(async() =>
        {
            ContentDialog dialog = new ResetAllDialog();
            await dialog.ShowAsync();
        }));
    }
}
