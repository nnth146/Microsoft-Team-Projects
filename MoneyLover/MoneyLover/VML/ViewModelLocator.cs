using Microsoft.Toolkit.Mvvm.DependencyInjection;
using MoneyLover.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.VML
{
    public class ViewModelLocator
    {
        public AddTransactionDialogViewModel AddTransactionDialog => Ioc.Default.GetService<AddTransactionDialogViewModel>();
        public AddWalletDialogViewModel AddWalletDialog => Ioc.Default.GetService<AddWalletDialogViewModel>();
        public BudgetPageViewModel BudgetPage => Ioc.Default.GetService<BudgetPageViewModel>();
        public CalendarPageViewModel CalendarPage => Ioc.Default.GetService<CalendarPageViewModel>();
        public DeleteTransactionDialogViewModel DeleteTransactionDialog => Ioc.Default.GetService<DeleteTransactionDialogViewModel>();
        public DeleteWalletDialogViewModel DeleteWalletDialog => Ioc.Default.GetService<DeleteWalletDialogViewModel>();
        public EditTransactionViewModel EditTransaction => Ioc.Default.GetService<EditTransactionViewModel>();
        public EditWalletDialogViewModel EditWalletDialog => Ioc.Default.GetService<EditWalletDialogViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public ReportPageViewModel ReportPage => Ioc.Default.GetService<ReportPageViewModel>();
        public TransactionPageViewModel TransactionPage => Ioc.Default.GetService<TransactionPageViewModel>();
        public WaitingPageViewModel WaitingPage => Ioc.Default.GetService<WaitingPageViewModel>();
        public AnnualPageViewModel AnnualPage => Ioc.Default.GetService<AnnualPageViewModel>();
        public MonthlyPageViewModel MonthlyPage => Ioc.Default.GetService<MonthlyPageViewModel>();
        public AddCategoryDialogViewModel AddCategoryDialog => Ioc.Default.GetService<AddCategoryDialogViewModel>();
        public EditCategoryDialogViewModel EditCategoryDialog => Ioc.Default.GetService<EditCategoryDialogViewModel>();
    }
}
