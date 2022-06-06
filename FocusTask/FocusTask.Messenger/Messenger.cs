using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace FocusTask.Messenger
{
    public class MPFrameRequestMessage : RequestMessage<Frame> { }

    public class ProjectsRequestMessage : RequestMessage<ObservableCollection<Project>> { }
    public class SelectedProjectRequestMessage : RequestMessage<Project> { }
    public class EditedProjectRequestMessage : RequestMessage<Project> { }
}
