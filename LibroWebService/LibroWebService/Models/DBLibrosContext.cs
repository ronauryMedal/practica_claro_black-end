using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace LibroWebService.Models
{
    public partial class DBLibrosContext : DbContext
    {
        public DBLibrosContext()
        {
        }

        public DBLibrosContext(DbContextOptions<DBLibrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-ANKUSJT\\SQLEXPRESS;Database=DBLibros;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasColumnName("autor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasColumnName("editora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
