using ExpenseManagement.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.VML
{
    public class ViewModelLocator
    {
        public AddTransactionDialogViewModel AddTransactionDialog => Ioc.Default.GetService<AddTransactionDialogViewModel>();
        public DeleteTransactionDialogViewModel DeleteTransactionDialog => Ioc.Default.GetService<DeleteTransactionDialogViewModel>();
        public EditTransactionDialogViewModel EditTransactionDialog => Ioc.Default.GetService<EditTransactionDialogViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public EmptyTransactionPageViewModel EmptyTransactionPage => Ioc.Default.GetService<EmptyTransactionPageViewModel>();
        public ListTransactionPageViewModel ListTransactionPage => Ioc.Default.GetService<ListTransactionPageViewModel>();
        public TransactionPageViewModel TransactionPage => Ioc.Default.GetService<TransactionPageViewModel>();
        public ReportPageViewModel ReportPage => Ioc.Default.GetService<ReportPageViewModel>();
        public GiftDialogViewModel GriftDialog => Ioc.Default.GetService<GiftDialogViewModel>();
    }
}
