using KeepSafeForPassword.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Core.Service
{
    public interface IDataService
    {
        ObservableCollection<Account> GetAccounts();
        void AddAccount(Account account);
        Task AddAccountAsync(Account account);
        void RemoveAccount(Account account);
        Task RemoveAccountAsync(Account account);

        ObservableCollection<Password> GetPasswords();
        void AddPassword(Password password);
        Task AddPasswordAsync(Password password);
        void RemovePassword(Password password);
        Task RemovePasswordAsync(Password password);

        ObservableCollection<Password> GetAddress();
        ObservableCollection<Password> GetContacts();
        ObservableCollection<Password> GetDatabases();
        ObservableCollection<Password> GetSecureNotes();
        ObservableCollection<Password> GetSevers();
        ObservableCollection<Password> GetWifis();

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
