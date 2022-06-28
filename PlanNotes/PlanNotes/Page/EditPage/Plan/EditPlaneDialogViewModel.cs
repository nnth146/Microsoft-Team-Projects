using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace PlanNotes.ViewModel
{
    public class EditPlaneDialogViewModel : ViewModelBase
    {
        public EditPlaneDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
        }
    }
}
