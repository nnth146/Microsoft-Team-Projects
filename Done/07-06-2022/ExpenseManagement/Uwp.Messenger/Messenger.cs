using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Messenger
{
    public class TransactionMessenger : RequestMessage<Transaction> { }

    public class TransactionsMessenger : RequestMessage<ObservableCollection<Transaction>> { }
    public class NoteValueChangedMessage : RequestMessage<string> { }
}
