using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System.Collections.ObjectModel;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace Uwp.Messenger
{
    public class FoldersRequestMessage : RequestMessage<ObservableCollection<FolderModel>> { }
    public class FolderRequestMessage : RequestMessage<FolderModel> { }
    public class ContextFolderRequestMessage : RequestMessage<FolderModel> { }

    public class StudiesRequestMessage : RequestMessage<ObservableCollection<StudyModel>> { }
    public class StudyRequestMessage : RequestMessage<StudyModel> { }
    public class ContextStudyRequestMessage : RequestMessage<StudyModel> { }

    public class TopicsRequestMessage : RequestMessage<ObservableCollection<TopicModel>> { }
    public class TopicRequestMessage : RequestMessage<TopicModel> { }

    // Frame
    public class MPFrameRequestMessage : RequestMessage<Frame> { }
    public class ChangeMessage
    {
        public StudyModel Study;
        public ChangeMessage(StudyModel Study)
        {
            this.Study = Study;
        }
    }
}
