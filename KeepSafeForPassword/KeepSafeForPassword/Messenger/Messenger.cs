using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace KeepSafeForPassword.Messenger
{
    public class RequireLogin { }
    public class HomePageFrameRequestMessage : RequestMessage<Frame> { }
    public class AddPasswordFrameRequestMessage : RequestMessage<Frame> { }
    public class EditPasswordFrameRequestMessage : RequestMessage<Frame> { }
    public class AddCommandRequestMessage : RequestMessage<RelayCommand<Password>> { }
    public class EditCommandRequestMessage : RequestMessage<RelayCommand> { }
    public class SelectedPasswordRequestMessage : RequestMessage<Password> { }
    public class ScrollIntoViewRequestMessage<T>
    {
        public T Item { get; set; }

        public ScrollIntoViewRequestMessage(T item)
        {
            this.Item = item;
        }
    }

    public class PasswordsRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class AddressRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class ContactsRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class DatabasesRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class SecureNotesRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class SeversRequestMessage : RequestMessage<ObservableCollection<Password>> { }
    public class WifisRequestMessage : RequestMessage<ObservableCollection<Password>> { }
}
