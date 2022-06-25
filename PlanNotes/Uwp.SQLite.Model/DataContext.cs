using Microsoft.EntityFrameworkCore;
using System;

namespace Uwp.SQLite.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Step> Steps { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "PlanNotes.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
