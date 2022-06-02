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
        public AccountPageViewModel AccountPage => Ioc.Default.GetService<AccountPageViewModel>();
        public AddDatabasePageViewModel AddDatabasePage => Ioc.Default.GetService<AddDatabasePageViewModel>();
        public AddSecureNotePageViewModel AddSecureNotePage => Ioc.Default.GetService<AddSecureNotePageViewModel>();
        public AddServerPageViewModel AddServerPage => Ioc.Default.GetService<AddServerPageViewModel>();
        public AddWifiPageViewModel AddWifiPage => Ioc.Default.GetService<AddWifiPageViewModel>();
        public EditDatabasePageViewModel EditDatabasePage => Ioc.Default.GetService<EditDatabasePageViewModel>();
        public EditSecurePageViewModel EditSecurePage => Ioc.Default.GetService<EditSecurePageViewModel>();
        public EditServerPageViewModel EditServerPage => Ioc.Default.GetService<EditServerPageViewModel>();
        public EditWifiPageViewModel EditWifiPage => Ioc.Default.GetService<EditWifiPageViewModel>();
        public HomePageViewModel HomePage => Ioc.Default.GetService<HomePageViewModel>();
        public LoginPageViewModel LoginPage => Ioc.Default.GetService<LoginPageViewModel>();
        public RegisterPageViewModel RegisterPage => Ioc.Default.GetService<RegisterPageViewModel>();
        public ViewAddressPageViewModel ViewAddressPage => Ioc.Default.GetService<ViewAddressPageViewModel>();
        public ViewContactPageViewModel ViewContactPage => Ioc.Default.GetService<ViewContactPageViewModel>();
        public ViewDatabasePageViewModel ViewDatabasePage => Ioc.Default.GetService<ViewDatabasePageViewModel>();
        public ViewPasswordPageViewModel ViewPasswordPage => Ioc.Default.GetService<ViewPasswordPageViewModel>();
        public ViewSecureNotePageViewModel ViewSecureNotePage => Ioc.Default.GetService<ViewSecureNotePageViewModel>();
        public ViewServerPageViewModel ViewServerPage => Ioc.Default.GetService<ViewServerPageViewModel>();
        public ViewWifiPageViewModel ViewWifiPage => Ioc.Default.GetService<ViewWifiPageViewModel>();
        public AddAddressPageViewModel AddAddressPage => Ioc.Default.GetService<AddAddressPageViewModel>();
        public AddPasswordPageViewModel AddPasswordPage => Ioc.Default.GetService<AddPasswordPageViewModel>();
        public EditAddressPageViewModel EditAddressPage => Ioc.Default.GetService<EditAddressPageViewModel>();
        public EditContactPageViewModel EditContactPage => Ioc.Default.GetService<EditContactPageViewModel>();
        public EditPasswordPageViewModel EditPasswordPage => Ioc.Default.GetService<EditPasswordPageViewModel>();
        public AddContactPageViewModel AddContactPage => Ioc.Default.GetService<AddContactPageViewModel>();
    }
}
