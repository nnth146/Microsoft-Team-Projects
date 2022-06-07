using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace UWP.Core.Service
{
    public interface IDialogService
    {
        Task showAsync(Type dialogViewModelType);
        Task showAsync(Type dialogViewModelType, ICommand primaryCommand);
        Task showAsync(Type dialogViewModelType, ICommand primaryCommand, ICommand secondaryCommand);
        Task showAsync(Type dialogViewModelType, ICommand primaryCommand, object primaryCommandParameter);
        Task showAsync(Type dialogViewModelType, ICommand primaryCommand, ICommand secondaryCommand, object primaryCommandParameter, object secondaryCommandParameter);

        Task showMessageDialogAsync(string message);

        Task showMessageContentDialogAsync(string message);

        Task showQuestionDialogAsync(string message, ICommand primaryCommand);
        Task showQuestionDialogAsync(string message, ICommand primaryCommand, ICommand secondaryCommand);
        Task showQuestionDialogAsync(string message, ICommand primaryCommand, object primaryCommandParameter);
        Task showQuestionDialogAsync(string message, ICommand primaryCommand, ICommand secondaryCommand, object primaryCommandParameter, object secondaryCommandParameter);

        void HideCurrentDialog();
    }
}
