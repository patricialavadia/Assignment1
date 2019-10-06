using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment1.Models
{
    public partial class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext()
        {
        }

        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<BooksBorrowed> BooksBorrowed { get; set; }
        public virtual DbSet<Member> Member { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=libraryserverone.database.windows.net;Initial Catalog=LibraryDatabase;Persist Security Info=True;User ID=comp2084;Password=Georgian2019");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
        }
    }
}
