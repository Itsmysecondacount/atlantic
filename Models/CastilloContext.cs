using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_tecnica_Atlantic.Models;

public partial class CastilloContext : DbContext
{
    public CastilloContext()
    {
    }

    public CastilloContext(DbContextOptions<CastilloContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Castillo;User Id=sa;Password=tokyo3;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Codcat).HasName("PK__Categori__4069C4700BC00F96");

            entity.HasIndex(e => e.Nomcat, "UQ__Categori__716D28CBBB304A6A").IsUnique();

            entity.Property(e => e.Codcat).HasColumnName("codcat");
            entity.Property(e => e.Nomcat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomcat");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Copro).HasName("PK__Producto__93158ED58FCBA04F");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.Nompro, "UQ__Producto__882F081393BB9067").IsUnique();

            entity.Property(e => e.Copro).HasColumnName("copro");
            entity.Property(e => e.Codcat).HasColumnName("codcat");
            entity.Property(e => e.Nompro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nompro");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.CodcatNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Codcat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__codcat__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
