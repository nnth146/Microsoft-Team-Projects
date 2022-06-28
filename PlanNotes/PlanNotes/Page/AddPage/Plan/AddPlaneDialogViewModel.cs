using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class AddPlaneDialogViewModel : ViewModelBase
    {
        public AddPlaneDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plans = WeakReferenceMessenger.Default.Send<PlansRequestMessage>().Response;
            NamePlan = "";
        }

        public ObservableCollection<Plan> Plans { get; set; }
        public string NamePlan { get; set; }

        private RelayCommand _addPlanCommand;
        public RelayCommand AddPlanCommand => _addPlanCommand ?? (_addPlanCommand = new RelayCommand(() =>
        {
            Plan plan = new Plan();
            plan.PlanName = string.IsNullOrEmpty(NamePlan) ? "Name Plan..." : NamePlan;
            plan.PlanFolders = new System.Collections.ObjectModel.ObservableCollection<Folder>();
            plan.PlanCreate_On = System.DateTime.Now.ToLocalTime();
            Plans.Add(plan);
            dataService.AddNewPlan(plan);
        }));
    }
}
