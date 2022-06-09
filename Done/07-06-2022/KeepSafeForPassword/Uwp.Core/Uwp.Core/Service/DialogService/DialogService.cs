using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Uwp.Core.Controls;
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

        private ContentDialog _currentDialog { get; set; }

        private QuestionDialog _questionDialog { get; set; } = new QuestionDialog();

        private MessageContentDialog _messageDialog { get; set; } = new MessageContentDialog();

        public DialogService(Dictionary<Type, Type> dialogs)
        {
            _dialogs = dialogs;
        }

        #region Xử lý ContentDialog

        public async Task showAsync(Type dialogViewModelType)
        {
            //convert type ViewModel -> type Dialog
            //Tạo instance of type Dialog
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;

            _currentDialog = dialog;

            await dialog.ShowAsync();
        }

        public async Task showAsync(Type dialogViewModelType, ICommand primaryCommand)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;

            dialog.PrimaryButtonCommand = primaryCommand;

            _currentDialog = dialog;

            await dialog.ShowAsync();
        }

        public async Task showAsync(Type dialogViewModelType, ICommand primaryCommand, ICommand secondaryCommand)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;

            dialog.PrimaryButtonCommand = primaryCommand;
            dialog.SecondaryButtonCommand = secondaryCommand;

            _currentDialog = dialog;

            await dialog.ShowAsync();
        }

        public async Task showAsync(Type dialogViewModelType, ICommand primaryCommand, object primaryCommandParameter)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;

            dialog.PrimaryButtonCommand = primaryCommand;
            dialog.PrimaryButtonCommandParameter = primaryCommandParameter;

            _currentDialog = dialog;

            await dialog.ShowAsync();
        }

        public async Task showAsync(Type dialogViewModelType, ICommand primaryCommand, ICommand secondaryCommand, object primaryCommandParameter, object secondaryCommandParameter)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;

            dialog.PrimaryButtonCommand = primaryCommand;
            dialog.PrimaryButtonCommandParameter = primaryCommandParameter;
            dialog.SecondaryButtonCommand = secondaryCommand;
            dialog.SecondaryButtonCommandParameter = secondaryCommandParameter;

            _currentDialog = dialog;

            await dialog.ShowAsync();
        }

        public void HideCurrentDialog()
        {
            _currentDialog.Hide();
        }
        #endregion

        #region Xử lý MessageDialog
        public async Task showMessageDialogAsync(string message)
        {
            MessageDialog messageDialog = new MessageDialog(message);

            await messageDialog.ShowAsync();
        }

        public async Task showMessageContentDialogAsync(string message)
        {
            _messageDialog.Content = message;

            await _messageDialog.ShowAsync();
        }

        public async Task showQuestionDialogAsync(string message, ICommand primaryCommand)
        {
            _questionDialog.Content = message;
            _questionDialog.PrimaryButtonCommand = primaryCommand;

            _currentDialog = _questionDialog;

            await _questionDialog.ShowAsync();
        }

        public async Task showQuestionDialogAsync(string message, ICommand primaryCommand, ICommand secondaryCommand)
        {
            _questionDialog.Content = message;
            _questionDialog.PrimaryButtonCommand = primaryCommand;
            _questionDialog.SecondaryButtonCommand = secondaryCommand;

            _currentDialog = _questionDialog;

            await _questionDialog.ShowAsync();
        }


        public async Task showQuestionDialogAsync(string message, ICommand primaryCommand, object primaryCommandParameter)
        {
            _questionDialog.Content = message;
            _questionDialog.PrimaryButtonCommand = primaryCommand;
            _questionDialog.PrimaryButtonCommandParameter = primaryCommandParameter;

            _currentDialog = _questionDialog;

            await _questionDialog.ShowAsync();
        }

        public async Task showQuestionDialogAsync(string message, ICommand primaryCommand, ICommand secondaryCommand, object primaryCommandParameter, object secondaryCommandParameter)
        {
            _questionDialog.Content = message;
            _questionDialog.PrimaryButtonCommand = primaryCommand;
            _questionDialog.PrimaryButtonCommandParameter = primaryCommandParameter;
            _questionDialog.SecondaryButtonCommand = secondaryCommand;
            _questionDialog.SecondaryButtonCommandParameter = secondaryCommandParameter;

            _currentDialog = _questionDialog;

            await _questionDialog.ShowAsync();
        }

        #endregion
    }
}
