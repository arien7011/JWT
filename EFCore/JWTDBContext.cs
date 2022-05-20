using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JWTBooks.Models
{
    public partial class JWTDBContext : DbContext
    {
        public JWTDBContext()
        {
        }

        public JWTDBContext(DbContextOptions<JWTDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBook> TblBooks { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_India.1252");

            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("TblBook");

                entity.HasIndex(e => e.BookId, "tblbook_index");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookID");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("TblUser");

                entity.HasIndex(e => e.UserId, "tbluser_index");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .UseIdentityAlwaysColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
