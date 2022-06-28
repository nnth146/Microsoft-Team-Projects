using _4sTodo.Model;
using _4sTodo.View.Dialog;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Windows.UI.Xaml.Controls;

namespace _4sTodo.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {

        }


        private RelayCommand<Microsoft.UI.Xaml.Controls.NavigationViewItem> _selectionChangedCommand;
        public RelayCommand<Microsoft.UI.Xaml.Controls.NavigationViewItem> SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<Microsoft.UI.Xaml.Controls.NavigationViewItem>(async (obj) =>
        {

            var frame = WeakReferenceMessenger.Default.Send<SendObjectMessage>().Response as Frame;
            switch (obj.Content.ToString())
            {
                case "Home": navigationService.Navigate(frame, typeof(HomePageViewModel));
                    break;
                case "Report": navigationService.Navigate(frame, typeof(ReportPageViewModel));
                    break;
                case "Premium":
                    ContentDialog dialog = new PremiumDialog();
                    await dialog.ShowAsync();
                    break;
            }
        }));
    }
}
