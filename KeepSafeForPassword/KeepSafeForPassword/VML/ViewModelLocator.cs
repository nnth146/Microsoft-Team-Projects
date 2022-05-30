using KeepSafeForPassword.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepSafeForPassword.VML
{
    public class ViewModelLocator
    {
        public AddDatabasePageViewModel AddDatabasePage => Ioc.Default.GetService<AddDatabasePageViewModel>();
        public AddSecureNotePageViewModel AddSecureNotePage => Ioc.Default.GetService<AddSecureNotePageViewModel>();
        public AddServerPageViewModel AddServerPage => Ioc.Default.GetService<AddServerPageViewModel>();
        public AddWifiPageViewModel AddWifiPage => Ioc.Default.GetService<AddWifiPageViewModel>();
        public EditDatabasePageViewModel EditDatabasePage => Ioc.Default.GetService<EditDatabasePageViewModel>();
        public EditSecurePageViewModel EditSecurePage => Ioc.Default.GetService<EditSecurePageViewModel>();
        public EditServerPageViewModel EditServerPage => Ioc.Default.GetService<EditServerPageViewModel>();
        public EditWifiPageViewModel EditWifiPage => Ioc.Default.GetService<EditWifiPageViewModel>();
        public HomePageViewModel HomePage => Ioc.Default.GetService<HomePageViewModel>();
        public ImagePageViewModel ImagePage => Ioc.Default.GetService<ImagePageViewModel>();
        public NewPageViewModel NewPage => Ioc.Default.GetService<NewPageViewModel>();
        public ViewDatabasePageViewModel ViewDatabasePage => Ioc.Default.GetService<ViewDatabasePageViewModel>();
        public ViewSecureNotePageViewModel ViewSecureNotePage => Ioc.Default.GetService<ViewSecureNotePageViewModel>();
        public ViewServerPageViewModel ViewServerPage => Ioc.Default.GetService<ViewServerPageViewModel>();
        public ViewWifiPageViewModel ViewWifiPage => Ioc.Default.GetService<ViewWifiPageViewModel>();
    }
}
