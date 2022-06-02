using ExpenseManagement.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Mvvm.Core.Helper;
using UWP.Mvvm.Core.Service;
using static ExpenseManagement.Messenger.Messenger;

namespace ExpenseManagement.ViewModel
{
    public class MainPageViewModel : ServiceObservableObject
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            transactions = Database.getTransactionByWhere("");
            transactions.CollectionChanged += Transactions_CollectionChanged;
            
            EnabledTransaction = false;
            basics = new ObservableCollection<Basic>()
            {
                new Basic("/Assets/icons/transaction.png", "Transactions", true),
                new Basic("/Assets/icons/calender.png", "Calendar", false),
                new Basic("/Assets/icons/report.png", "Reports", true)
            };
        }

        private void Transactions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Database.addNewTransaction(e.NewItems[0] as Transaction);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Transaction transaction = (Transaction)e.NewItems[0];
                Database.updateTransactionById(transaction, transaction.Id);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Transaction transaction = (Transaction)e.OldItems[0];
                Database.deleteTransactionById(transaction.Id);
            }
            OnPropertyChanged(nameof(transactions));
            selectedBasic = null;
            OnPropertyChanged(nameof(selectedBasic));
            selectedBasic = basics[0];
            OnPropertyChanged(nameof(selectedBasic));   
        }
            
        // Variable
        // ObservableCollection
        public ObservableCollection<Transaction> transactions { get; set; }
        public ObservableCollection<object> objectTransaction { get; set; }
        public ObservableCollection<Basic> basics { get; set; }


        public int transactionCount { get => transactions.Count; }
        public Transaction selectedTransaction { get; set; }
        public Basic selectedBasic { get; set; }
        public Boolean EnabledTransaction { get; set; }

        // RelayCommand
        private RelayCommand _addtransactionCommand;
        public RelayCommand AddTransactionCommand
        {
            get
            {
                if (_addtransactionCommand == null)
                {
                    _addtransactionCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<TransactionsMessenger>(this, (r, m) =>
                        {
                            m.Reply(transactions);
                        });
                        dialogService.showAsync(typeof(AddTransactionDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<TransactionsMessenger>(this);
                    });
                }
                return _addtransactionCommand;
            }
        }

        private RelayCommand<object> _transactionChangeCommand;
        public RelayCommand<object> TransactionChangeCommand
        {
            get
            {
                if(_transactionChangeCommand == null)
                {
                    _transactionChangeCommand = new RelayCommand<object>((frame) =>
                    {
                        if(selectedTransaction != null)
                        {
                            EnabledTransaction = true;
                            OnPropertyChanged(nameof(EnabledTransaction));
                            navigationService.Navigate(frame, typeof(TransactionPageViewModel), selectedTransaction);
                        }
                        else
                        {
                            EnabledTransaction = false;
                            OnPropertyChanged(nameof(EnabledTransaction));
                        }
                    });
                }
                return _transactionChangeCommand;
            }
        }

        private RelayCommand _editTransactionCommand;
        public RelayCommand EditTransactionCommand
        {
            get
            {
                if(_editTransactionCommand == null)
                {
                    _editTransactionCommand = new RelayCommand(() =>
                    {
                        if (selectedTransaction != null)
                        {
                            WeakReferenceMessenger.Default.Register<TransactionsMessenger>(this, (r, m) =>
                            {
                                m.Reply(transactions);
                            });
                            WeakReferenceMessenger.Default.Register<TransactionMessenger>(this, (r, m) =>
                            {
                                m.Reply(selectedTransaction);
                            });
                            dialogService.showAsync(typeof(EditTransactionDialogViewModel));
                            WeakReferenceMessenger.Default.Unregister<TransactionsMessenger>(this);
                            WeakReferenceMessenger.Default.Unregister<TransactionMessenger>(this);
                        }
                    });
                }
                return _editTransactionCommand;
            }
        }

        private RelayCommand _deleteTransactionCommand;
        public RelayCommand DeleteTransactionCommand
        {
            get
            {
                if(_deleteTransactionCommand == null)
                {
                    _deleteTransactionCommand = new RelayCommand(() =>
                    {
                        if(selectedTransaction != null)
                        {
                            WeakReferenceMessenger.Default.Register<TransactionsMessenger>(this, (r, m) =>
                            {
                                m.Reply(transactions);
                            });
                            WeakReferenceMessenger.Default.Register<TransactionMessenger>(this, (r, m) =>
                            {
                                m.Reply(selectedTransaction);
                            });
                            dialogService.showAsync(typeof(DeleteTransactionDialogViewModel));
                            WeakReferenceMessenger.Default.Unregister<TransactionsMessenger>(this);
                            WeakReferenceMessenger.Default.Unregister<TransactionMessenger>(this);
                        }
                    });
                }
                return _deleteTransactionCommand;
            }
        }

        private RelayCommand<object> _basicChangedCommand;
        public RelayCommand<object> BasicChangedCommand
        {
            get
            {
                if(_basicChangedCommand == null)
                {
                    _basicChangedCommand = new RelayCommand<object>((frame) =>
                    {
                        if (selectedBasic != null)
                        {
                            if (selectedBasic.Name == "Transactions")
                            {
                                if (transactions.Count > 0)
                                {
                                    navigationService.Navigate(frame, typeof(ListTransactionPageViewModel), transactions);
                                }
                                else
                                {
                                    navigationService.Navigate(frame, typeof(EmptyTransactionPageViewModel), transactions);
                                }
                            } else if (selectedBasic.Name == "Reports")
                                navigationService.Navigate(frame, typeof(ReportPageViewModel));
                        }
                    });
                }
                return _basicChangedCommand;
            }
        }
    }
}
    