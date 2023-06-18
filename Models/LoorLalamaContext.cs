using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Loor_Lalama.Models;

public partial class LoorLalamaContext : DbContext
{
    public LoorLalamaContext()
    {
    }

    public LoorLalamaContext(DbContextOptions<LoorLalamaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<HistorialAcceso> HistorialAccesos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.ToTable("Genero");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<HistorialAcceso>(entity =>
        {
            entity.ToTable("HistorialAcceso");

            entity.HasIndex(e => e.UsuarioId, "IX_HistorialAcceso_UsuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialAccesos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.GeneroId, "IX_Usuarios_GeneroId");

            entity.Property(e => e.Clave)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Genero).WithMany(p => p.Usuarios).HasForeignKey(d => d.GeneroId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
