using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Words.Models;

#nullable disable

namespace Data.Words.Entity
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

        public virtual DbSet<WordChange> WordChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<WordChange>(entity =>
            {
                entity.HasKey(e => e.WordId)
                    .HasName("PK__AZ__00CBFA317F60ED59");

                entity.ToTable("WordChange");

                entity.Property(e => e.WordId).HasColumnName("WORD_ID");

                entity.Property(e => e.Word)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("WORD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
