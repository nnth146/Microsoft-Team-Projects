using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class DataContext : DbContext
    {
        private static DataContext _instance = new DataContext();
        public static DataContext Default => _instance;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CommonPassword> Passwords { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<SecureNote> SecureNotes { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Wifi> Wifis { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "KeepSafeForPassword1.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
