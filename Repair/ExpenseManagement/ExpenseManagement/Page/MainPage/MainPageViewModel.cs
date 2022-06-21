using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace ExpenseManagement.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            GetData();

            EnabledTransaction = false;
            Basics = new ObservableCollection<Basic>()
            {
                new Basic("/Assets/icons/transaction.png", "Transactions", true),
                new Basic("/Assets/icons/report.png", "Reports", true)
            };

            RegisterMessenger();
        }
        private void RegisterMessenger()
        {
            WeakReferenceMessenger.Default.Register<TransactionsMessenger>(this, (r, m) =>
            {
                m.Reply(Transactions);
            });

            WeakReferenceMessenger.Default.Register<TransactionMessenger>(this, (r, m) =>
            {
                m.Reply(SelectedTransaction);
            });
        }

        private void GetData()
        {
            Transactions = dataService.GetTransactions();
            Transactions.CollectionChanged += Transactions_CollectionChanged;
            OnPropertyChanged(nameof(Transactions));
        }

        private void Transactions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Transaction transaction = e.NewItems[0] as Transaction;
                dataService.AddNewTransaction(transaction);
                Debug.WriteLine("Add");
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                dataService.SaveChanges();
                Debug.WriteLine("Edit");
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Transaction transaction = (Transaction)e.OldItems[0];
                dataService.DeleteTransaction(transaction);
                SelectedBasic = Basics[0];
                OnPropertyChanged(nameof(SelectedBasic));
                Debug.WriteLine("Delete");
            }
            GetData();
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public Transaction SelectedTransaction { get; set; }
        public ObservableCollection<object> ObjectTransaction { get; set; }
        public int TransactionCount => Transactions.Count;

        public ObservableCollection<Basic> Basics { get; set; }
        public Basic SelectedBasic { get; set; }
        public Boolean EnabledTransaction { get; set; }


        private RelayCommand _addtransactionCommand;
        public RelayCommand AddTransactionCommand => _addtransactionCommand ?? (_addtransactionCommand = new RelayCommand(async () =>
        {
            await dialogService.showAsync(typeof(AddTransactionDialogViewModel));
        }));

        private RelayCommand<object> _transactionChangeCommand;
        public RelayCommand<object> TransactionChangeCommand => _transactionChangeCommand ?? (_transactionChangeCommand = new RelayCommand<object>((frame) =>
        {
            if (SelectedTransaction != null)
            {
                EnabledTransaction = true;
                OnPropertyChanged(nameof(EnabledTransaction));
                navigationService.Navigate(frame, typeof(TransactionPageViewModel), SelectedTransaction);
            }
            else
            {
                EnabledTransaction = false;
                OnPropertyChanged(nameof(EnabledTransaction));
            }
        }));

        private RelayCommand _editTransactionCommand;
        public RelayCommand EditTransactionCommand => _editTransactionCommand ?? (_editTransactionCommand = new RelayCommand(async () =>
        {
            if (SelectedTransaction != null)
            { 
                await dialogService.showAsync(typeof(EditTransactionDialogViewModel));
            }
        }));

        private RelayCommand _deleteTransactionCommand;
        public RelayCommand DeleteTransactionCommand => _deleteTransactionCommand ?? (_deleteTransactionCommand = new RelayCommand(async () =>
        {
            if (SelectedTransaction != null)
            {
                await dialogService.showAsync(typeof(DeleteTransactionDialogViewModel));
            }
        }));

        private RelayCommand<object> _basicChangedCommand;
        public RelayCommand<object> BasicChangedCommand => _basicChangedCommand ?? (_basicChangedCommand = new RelayCommand<object>((frame) =>
        {
            if (SelectedBasic != null)
            {
                if (SelectedBasic.Name == "Transactions")
                {
                    if (Transactions.Count > 0)
                    {
                        navigationService.Navigate(frame, typeof(ListTransactionPageViewModel), Transactions);
                    }
                    else
                    {
                        navigationService.Navigate(frame, typeof(EmptyTransactionPageViewModel), Transactions);
                    }
                }
                else if (SelectedBasic.Name == "Reports")
                    navigationService.Navigate(frame, typeof(ReportPageViewModel));
            }
        }));

        private RelayCommand<object> _showSettingCommand;
        public RelayCommand<object> ShowSettingCommand => _showSettingCommand ?? (_showSettingCommand = new RelayCommand<object>((subFrame) =>
        {
            navigationService.NavigateOneTime(subFrame, typeof(SettingPageViewModel));
        }));
    }
}
