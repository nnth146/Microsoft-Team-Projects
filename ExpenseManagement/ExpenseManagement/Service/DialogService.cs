using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UWP.Mvvm.Core.Service
{
    public class DialogService : IDialogService
    {
        private Dictionary<Type, Type> _dialogs;
        public Dictionary<Type, Type> Dialogs => _dialogs ?? (_dialogs = new Dictionary<Type, Type>());
        public DialogService(Dictionary<Type, Type> dialogs)
        {
            _dialogs = dialogs;
        }
        public async Task showAsync(Type dialogViewModelType)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;
            await dialog.ShowAsync();
        }
    }
}
