using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSMC20241103.Models
{
    public partial class GSMC20241103DBContext : DbContext
    {
        public GSMC20241103DBContext()
        {
        }

        public GSMC20241103DBContext(DbContextOptions<GSMC20241103DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Componente> Componentes { get; set; } = null!;
        public virtual DbSet<Computadora> Computadoras { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost; database=GSMC20241103DB; integrated security=true;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Componente>(entity =>
            {
                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.HasOne(d => d.Computadora)
                    .WithMany(p => p.Componente)
                    .HasForeignKey(d => d.ComputadoraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Component__Compu__267ABA7A");
            });

            modelBuilder.Entity<Computadora>(entity =>
            {
                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Modelo).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
