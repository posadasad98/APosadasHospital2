using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class AposadasHospital2Context : DbContext
{
    public AposadasHospital2Context()
    {
    }

    public AposadasHospital2Context(DbContextOptions<AposadasHospital2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=APosadasHospital2; Trusted_Connection=True; User ID=sa; Password=pass@word1; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__693FA0AF9A0104EC");

            entity.ToTable("Especialidad");

            entity.Property(e => e.NombreEspecialidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.IdHospital).HasName("PK__Hospital__A80B2F2DCAFF2061");

            entity.ToTable("Hospital");

            entity.Property(e => e.AniodeConstruccion).HasColumnType("date");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK__Hospital__IdEspe__15502E78");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
