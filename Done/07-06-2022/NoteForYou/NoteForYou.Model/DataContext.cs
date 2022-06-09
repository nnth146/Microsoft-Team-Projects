using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class DataContext : DbContext
    {
        public DbSet<AddressNote> AddressNotes { get; set; }
        public DbSet<BasicNote> BasicNotes { get; set; }
        public DbSet<ContactNote> ContactNotes { get; set; }
        public DbSet<ImageNote> ImageNotes { get; set; }
        public DbSet<ListNote> ListNotes { get; set; }
        public DbSet<SecureNote> SecureNotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = NoteForYouv2.db");
        }
    }
}
