using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Words.Data.Models;

#nullable disable

namespace Words.Data.Entity
{
    public partial class WordContext : DbContext
    {
        public WordContext()
        {
        }

        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Word>(entity =>
            {
                entity.ToTable("Word");

                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.Property(e => e.WordText)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
