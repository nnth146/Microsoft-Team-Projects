using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Messenger
{
    public class Messenger
    {
        public class BudgetMessenger : RequestMessage<Budget>
        {
        }

        public class BudgetsMessenger : RequestMessage<ObservableCollection<Budget>>
        {
        }

        public class TransactionMessenger : RequestMessage<Transaction>
        {
        }

        public class TransactionsMessenger : RequestMessage<ObservableCollection<Transaction>>
        {
        }

        public class CategoryMessenger : RequestMessage<Category>
        {
        }

        public class CategoriesMessenger : RequestMessage<ObservableCollection<Category>>
        {
        }
    }
}
