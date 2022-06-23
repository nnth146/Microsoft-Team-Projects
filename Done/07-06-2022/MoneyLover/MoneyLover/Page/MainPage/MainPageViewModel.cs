using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MoneyLover.Messenger;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace MoneyLover.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            InitializeNavItems();
        }

        #region Xử lý Navigation View

        public IEnumerable<NavItem> NavItems { get; set; }

        private void InitializeNavItems()
        {
            NavItems = new List<NavItem>
            {
                new NavItem
                {
                    Content = "Budgets",
                    Icon = CommonHelper.GetAppResources("Icon Budget") as string,
                    Page = typeof(BudgetPageViewModel)
                },
                new NavItem
                {
                    Content = "Transactions",
                    Icon = CommonHelper.GetAppResources("Icon Transaction") as string,
                    Page = typeof(TransactionPageViewModel)
                },
                new NavItem
                {
                    Content = "Reports",
                    Icon = CommonHelper.GetAppResources("Icon Report") as string,
                    Page = typeof(ReportPageViewModel)
                },
                //new NavItem
                //{
                //    Content = "Calendar",
                //    Icon = CommonHelper.GetAppResources("Icon Calendar") as string,
                //    Page = typeof(CalendarPageViewModel)
                //},
            };
        }

        private RelayCommand<NavItem> _navSelectionChangedCommand;
        public RelayCommand<NavItem> NavSelectionChangedCommand => _navSelectionChangedCommand ?? (_navSelectionChangedCommand = new RelayCommand<NavItem>(ExecuteNavSelectionChanged));

        private void ExecuteNavSelectionChanged(NavItem obj)
        {
            var frame = messengerService.Send<MPFrameRequestMessage>().Response;

            if(obj != null)
            {
                navigationService.Navigate(frame, obj.Page);
            }
        }
        #endregion

        private RelayCommand _getAddOnCommand;
        public RelayCommand GetAddOnCommand => _getAddOnCommand ?? (_getAddOnCommand = new RelayCommand(() =>
        {
            var frame = messengerService.Send<MPFrameRequestMessage>().Response;

            navigationService.NavigateOneTime(frame, typeof(AddOnPageViewModel));
        }));
    }
}
