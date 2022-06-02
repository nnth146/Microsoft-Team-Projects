using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWP.Core.Service
{
    public class DialogService : IDialogService
    {
        private Dictionary<Type, Type> _dialogs;
        public Dictionary<Type, Type> Dialogs => _dialogs ?? (_dialogs = new Dictionary<Type, Type>());

        public ContentDialog CurrentDialog { get; set; }

        private ContentDialog _questionDialog { get; set; } = new ContentDialog
        {
            Title = "Notification",
            Background = new SolidColorBrush(Colors.White),
            CornerRadius = new CornerRadius(4),
            PrimaryButtonText = "OK",
            SecondaryButtonText = "Cancel",
        };

        public DialogService(Dictionary<Type, Type> dialogs)
        {
            _dialogs = dialogs;
        }

        public async Task showAsync(Type dialogViewModelType)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;
            CurrentDialog = dialog;
            await dialog.ShowAsync();
        }

        public async Task showMessageAsync(string message)
        {
            MessageDialog messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }

        public async Task showQuestionDialogAsync(string message, ICommand primaryCommand)
        {
            _questionDialog.Content = message;
            _questionDialog.PrimaryButtonCommand = primaryCommand;

            CurrentDialog = _questionDialog;

            await _questionDialog.ShowAsync();
        }
    }
}
