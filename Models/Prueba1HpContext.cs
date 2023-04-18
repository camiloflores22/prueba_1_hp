using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_1_hp.Models;

public partial class Prueba1HpContext : DbContext
{
    public Prueba1HpContext()
    {
    }

    public Prueba1HpContext(DbContextOptions<Prueba1HpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteAsignatura> EstudianteAsignaturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {  
 }
}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PRIMARY");

            entity.ToTable("asignatura");

            entity.Property(e => e.IdAsignatura)
                .HasColumnType("int(11)")
                .HasColumnName("id_asignatura");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(100)
                .HasColumnName("codigo_asignatura");
            entity.Property(e => e.DescripcionAsignatura)
                .HasMaxLength(100)
                .HasColumnName("descripcion_asignatura");
            entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(100)
                .HasColumnName("nombre_asignatura");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PRIMARY");

            entity.ToTable("estudiante");

            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");
            entity.Property(e => e.ApellidoEstudiante)
                .HasMaxLength(100)
                .HasColumnName("apellido_estudiante");
            entity.Property(e => e.DireccionEstudiante)
                .HasMaxLength(100)
                .HasColumnName("direccion_estudiante");
            entity.Property(e => e.Edad)
                .HasColumnType("int(11)")
                .HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(100)
                .HasColumnName("nombre_estudiante");
            entity.Property(e => e.RutEstudiante)
                .HasMaxLength(100)
                .HasColumnName("rut_estudiante");
        });

        modelBuilder.Entity<EstudianteAsignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiante_asignatura");

            entity.HasIndex(e => e.AsignaturaIdAsignatura, "fk_Estudiante_has_Asignatura_Asignatura1_idx");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "fk_Estudiante_has_Asignatura_Estudiante_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AsignaturaIdAsignatura)
                .HasColumnType("int(11)")
                .HasColumnName("Asignatura_id_asignatura");
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_id_estudiante");

            entity.HasOne(d => d.AsignaturaIdAsignaturaNavigation).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.AsignaturaIdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Estudiante_has_Asignatura_Asignatura1");

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Estudiante_has_Asignatura_Estudiante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
