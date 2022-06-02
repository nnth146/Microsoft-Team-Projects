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

        Task showMessageAsync(string message);

        Task showQuestionDialogAsync(string message, ICommand primaryCommand);
    }
}
