using Microsoft.EntityFrameworkCore;
using System;

namespace Uwp.SQLite.Model
{
    public class DataContext : DbContext
    {
        public DbSet<FolderModel> Folders { get; set; }
        public DbSet<StudyModel> Studies { get; set; }
        public DbSet<TopicModel> Topics { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "FlashCard.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
