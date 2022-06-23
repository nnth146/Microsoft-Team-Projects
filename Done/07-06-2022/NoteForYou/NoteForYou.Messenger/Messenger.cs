using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NoteForYou.Messenger
{
    //Lấy sub frame mà không cần truyền qua parameter nữa
    public class FrameNavigatedRequestMessage : RequestMessage<Frame> { }
    public class AddNotePageSubFrameRequestMessage : FrameNavigatedRequestMessage { }

    public class MainPageSubFrameRequestMessage : FrameNavigatedRequestMessage { }

    public class GoBackBehavior { }
    public class AddNotePageGoBackBeHavior : GoBackBehavior { }

    public class UpdateUIBehavior { }
    public class NotesPageUpdateUIBehavior : UpdateUIBehavior { }

    public class SelectedNoteRequestMessage : RequestMessage<Note> { }

    public class SaveChangeDb { }


}
