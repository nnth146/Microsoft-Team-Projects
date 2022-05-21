using FocusTask.Models;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Messenger
{
    public class Messenger
    {
        public class ProjectMessage : RequestMessage<ProjectModel>
        {
        }

        public class ProjectsMessage : RequestMessage<ObservableCollection<ProjectModel>>
        {
        }

        public class NoteValueChangedMessage : RequestMessage<string>
        {
        }
    }
}
