using FocusTask.Messenger;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.SQLite.Model;

namespace FocusTask.ViewModel
{
    public class EditDialogViewModel : ViewModelBase
    {
        public EditDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            SetupColors();

            EditedProject = WeakReferenceMessenger.Default.Send<EditedProjectRequestMessage>().Response;

            ProjectName = EditedProject.Name;
            SelectedColor = EditedProject.Color;
        }

        public Project EditedProject { get; set; }

        public List<string> Colors { get; set; } = new List<string>();
        public string SelectedColor { get; set; }

        private void SetupColors()
        {
            for (int i = 1; i < 21; i++)
            {
                if (i < 10)
                {
                    Colors.Add("Color0" + i);
                }
                else
                {
                    Colors.Add("Color" + i);
                }

            }
        }

        public string ProjectName { get; set; }

        private RelayCommand _primaryButtonCommand;
        public RelayCommand PrimaryButtonCommand => _primaryButtonCommand ?? (_primaryButtonCommand = new RelayCommand(() =>
        {

            EditedProject.Name = string.IsNullOrEmpty(ProjectName) ? EditedProject.Name : ProjectName;
            EditedProject.Color = SelectedColor;
            dataService.SaveChanges();

            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _secondaryButtonCommand;
        public RelayCommand SecondaryButtonCommand => _secondaryButtonCommand ?? (_secondaryButtonCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
