using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.ObjectModel;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace Uwp.Messenger
{
    public class PlansRequestMessage : RequestMessage<ObservableCollection<Plan>> { }
    public class PlanRequestMessage : RequestMessage<Plan> { }

    public class FoldersRequestMessage : RequestMessage<ObservableCollection<Folder>> { }
    public class FolderRequestMessage : RequestMessage<Folder> { }

    public class NotesRequestMessage : RequestMessage<ObservableCollection<Note>> { }
    public class NoteRequestMessage : RequestMessage<Note> { }

    public class CheckListsRequestMessage : RequestMessage<ObservableCollection<CheckList>> { }
    public class CheckListRequestMessage : RequestMessage<Note> { }

    // Frame
    public class MPFrameRequestMessage : RequestMessage<Frame> { }

    // Date Time
    public class DateTimeRequestMessage : RequestMessage<DateTime> { }

    // Changed Folder
    public class ChangeMessageFolder
    {
        public Folder Folder;
        public ChangeMessageFolder(Folder Folder)
        {
            this.Folder = Folder;
        }
    }

    public class ChangeMessagePlan
    {
        public Plan Plan;
        public ChangeMessagePlan(Plan Plan)
        {
            this.Plan = Plan;
        }
    }

}
