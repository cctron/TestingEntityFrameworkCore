using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestingEntityFrameworkCore.Models
{
    public partial class PostDbContext : DbContext
    {
        public PostDbContext()
        {
        }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=postefcore;Uid=root;Pwd=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.ToTable("alumnos");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("alumnos_cursos_idx");

                entity.Property(e => e.IdAlumno)
                    .HasColumnName("idAlumno")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nacimiento)
                    .HasColumnName("nacimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("alumnos_cursos");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("cursos");

                entity.HasIndex(e => e.IdProfesor)
                    .HasName("profesores_cursos_idx");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProfesor)
                    .HasColumnName("idProfesor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("profesores_cursos");
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.ToTable("profesores");

                entity.Property(e => e.IdProfesor)
                    .HasColumnName("idProfesor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });
        }
    }
}
