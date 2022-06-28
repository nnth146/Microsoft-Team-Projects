using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class DeletePlaneDialogViewModel : ViewModelBase
    {
        public DeletePlaneDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plans = WeakReferenceMessenger.Default.Send<PlansRequestMessage>().Response;
            Plan = WeakReferenceMessenger.Default.Send<PlanRequestMessage>().Response;
            Debug.WriteLine("Count: " + Plans.Count);
            Debug.WriteLine("Name: " + Plan.PlanName);
        }

        public ObservableCollection<Plan> Plans { get; set; }
        public Plan Plan { get; set; }

        private RelayCommand _deletePlanCommand;
        public RelayCommand DeletePlanCommand => _deletePlanCommand ?? (_deletePlanCommand = new RelayCommand(() =>
        {
            dataService.RemovePlan(Plan);
            Plans.Remove(Plan);
        }));
    }
}
