using KeepSafeForPassword.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Service;

namespace Uwp.Core.Service
{
    public class SQLiteService : IDataService
    {
        public SQLiteService()
        {
        }

        public DataContext Db => DataContext.Default;

        public ObservableCollection<Account> GetAccounts()
        {
            return new ObservableCollection<Account>(
                list: Db.Accounts
                .Include(x => x.Passwords)
                .Include(x => x.Address)
                .Include(x => x.Contacts)
                .Include(x => x.Databases)
                .Include(x => x.SecureNotes)
                .Include(x => x.Server)
                .Include(x => x.Wifis)
                .ToList());
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void AddAccount(Account account)
        {
            Db.Accounts.Add(account);
            SaveChanges();
        }

        public async Task AddAccountAsync(Account account)
        {
            Db.Accounts.Add(account);
            await SaveChangesAsync();
        }

        public void RemoveAccount(Account account)
        {
            Db.Accounts.Remove(account);
            SaveChanges();
        }

        public async Task RemoveAccountAsync(Account account)
        {
            Db.Accounts.Remove(account);
            await SaveChangesAsync();
        }

        public ObservableCollection<Password> GetPasswords()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Passwords);
            passwords.AddRange(account.Address);
            passwords.AddRange(account.Contacts);
            passwords.AddRange(account.Databases);
            passwords.AddRange(account.SecureNotes);
            passwords.AddRange(account.Server);
            passwords.AddRange(account.Wifis);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        private void AddPasswordExcute(Password password)
        {
            Type type = password.GetType();

            switch (type.Name)
            {
                case nameof(CommonPassword):
                    Db.Passwords.Add(password as CommonPassword);
                    break;
                case nameof(Address):
                    Db.Address.Add(password as Address);
                    break;
                case nameof(Contact):
                    Db.Contacts.Add(password as Contact);
                    break;
                case nameof(Database):
                    Db.Databases.Add(password as Database);
                    break;
                case nameof(SecureNote):
                    Db.SecureNotes.Add(password as SecureNote);
                    break;
                case nameof(Server):
                    Db.Servers.Add(password as Server);
                    break;
                case nameof(Wifi):
                    Db.Wifis.Add(password as Wifi);
                    break;
            }
        }

        public void AddPassword(Password password)
        {
            AddPasswordExcute(password);
            SaveChanges();
        }

        public async Task AddPasswordAsync(Password password)
        {
            AddPasswordExcute(password);
            await SaveChangesAsync();
        }


        private void RemovePasswordExcute(Password password)
        {
            Type type = password.GetType();

            Account account = Account.CurrentAccount;

            switch (type.Name)
            {
                case nameof(CommonPassword):
                    Db.Passwords.Remove(password as CommonPassword);
                    account.Passwords.Remove(password as CommonPassword);
                    break;

                case nameof(Address):
                    Db.Address.Remove(password as Address);
                    account.Address.Remove(password as Address);
                    break;

                case nameof(Contact):
                    Db.Contacts.Remove(password as Contact);
                    account.Contacts.Remove(password as Contact);
                    break;

                case nameof(Database):
                    Db.Databases.Remove(password as Database);
                    account.Databases.Remove(password as Database);
                    break;

                case nameof(SecureNote):
                    Db.SecureNotes.Remove(password as SecureNote);
                    account.SecureNotes.Remove(password as SecureNote);
                    break;

                case nameof(Server):
                    Db.Servers.Remove(password as Server);
                    account.Server.Remove(password as Server);
                    break;

                case nameof(Wifi):
                    Db.Wifis.Remove(password as Wifi);
                    account.Wifis.Remove(password as Wifi);
                    break;
            }
        }

        public void RemovePassword(Password password)
        {
            RemovePasswordExcute(password);
            SaveChanges();
        }

        public async Task RemovePasswordAsync(Password password)
        {
            RemovePasswordExcute(password);
            await SaveChangesAsync();
        }

        public ObservableCollection<Password> GetAddress()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Address);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        public ObservableCollection<Password> GetContacts()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Contacts);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        public ObservableCollection<Password> GetDatabases()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Databases);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        public ObservableCollection<Password> GetSecureNotes()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.SecureNotes);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        public ObservableCollection<Password> GetSevers()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Server);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }

        public ObservableCollection<Password> GetWifis()
        {
            List<Password> passwords = new List<Password>();

            Account account = Account.CurrentAccount;

            passwords.AddRange(account.Wifis);

            passwords = passwords.OrderBy(x => x.CreatedOn).ToList();
            passwords.Reverse();

            return new ObservableCollection<Password>(passwords);
        }
    }
}
