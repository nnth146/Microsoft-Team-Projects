using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.HCore.Service.Database;
using Windows.UI.Xaml.Controls;

namespace FlashCard1.Pages.Topic.Dialog
{
    public class AddTopicDialogViewModel : ObservableObject
    {
        private IDataService _dataService;
        public AddTopicDialogViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Colors = new ObservableCollection<object>
            {
                new
                {
                    Name = "Red",
                    Color = "#E1432E"
                },
                new
                {
                    Name = "Fresh Purple",
                    Color = "#D260E1"
                },
                new
                {
                    Name = "Baby Blue",
                    Color = "#89CFF0"
                },
                new
                {
                    Name = "Cyan",
                    Color = "#0EE3D8"
                },
                new
                {
                    Name = "Green Lantern",
                    Color = "#49A84C"
                },
            };
        }


        public ObservableCollection<object> Colors { get; set; }

        private RelayCommand<ContentDialog> _cancelCommand;

        public RelayCommand<ContentDialog> CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<ContentDialog>((dialog) =>
        {
            dialog.Hide();
        }));
    }
}
