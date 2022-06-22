using Microsoft.EntityFrameworkCore;
using System;

namespace Uwp.SQLite.Model
{
    public class DataContext : DbContext
    {
        private static DataContext _instance = new DataContext();
        public static DataContext Default => _instance;

        public DbSet<Project> Projects { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<SubMission> Submissions { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
