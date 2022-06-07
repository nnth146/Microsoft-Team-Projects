using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MoneyLover.Database;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace MoneyLover.ViewModel
{
    public class AddCategoryDialogViewModel : ViewModelBase
    {
        public AddCategoryDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            setIcon();
            selectedIcon = icons[0];
            NameCategory = "";
        }

        private void setIcon()
        {
            icons = new ObservableCollection<Icon>()
            {
                new Icon(CommonHelper.GetAppResources("Icon Other 1") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 2") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 3") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 4") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 5") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 6") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 7") as string),
                new Icon(CommonHelper.GetAppResources("Icon Other 8") as string),
            };
            OnPropertyChanged(nameof(icons));
        }

        public ObservableCollection<Icon> icons { get; set; }
        public Icon selectedIcon { get; set; }
        public string NameCategory { get; set; }

        private RelayCommand _addNewCategoryCommand;
        public RelayCommand AddNewCategoryCommand
        {
            get
            {
                if(_addNewCategoryCommand == null)
                {
                    _addNewCategoryCommand = new RelayCommand(() =>
                    {
                        Category category = new Category();
                        category.Name = String.IsNullOrEmpty(NameCategory) ? "Category" : NameCategory;
                        category.Icon = selectedIcon.Name;
                        DB.addNewCategory(category);
                    });
                }
                return _addNewCategoryCommand;
            }
        }
    }
}
