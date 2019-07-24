using Microsoft.EntityFrameworkCore;
using vojaro.core.Entities;

namespace vojaro.infrastructure.Data
{
    public partial class VojaroDbContext : DbContext
    {
        public VojaroDbContext()
        {
        }

        public VojaroDbContext(DbContextOptions<VojaroDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AlumnoAsignatura> AlumnoAsignatura { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<AsignaturaCorrelativa> AsignaturaCorrelativa { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<CarreraOrientacion> CarreraOrientacion { get; set; }
        public virtual DbSet<DepartamentoUniversidad> DepartamentoUniversidad { get; set; }
        public virtual DbSet<PlanCarrera> PlanCarrera { get; set; }
        public virtual DbSet<SedeUniversidad> SedeUniversidad { get; set; }
        public virtual DbSet<TipoCarrera> TipoCarrera { get; set; }
        public virtual DbSet<Universidad> Universidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=vojaro;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.DNI);
                entity.Property(e => e.DNI).HasColumnName("DNI");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.FechaCarga).HasColumnType("date");
                entity.Property(e => e.FechaModificacion).HasColumnType("date");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AlumnoAsignatura>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.CarreraId });
                entity.Property(e => e.EstadoAsignatura)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.FechaCarga).HasColumnType("date");
                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.AlumnoAsignatura)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK__AlumnoAsi__Alumn__5DCAEF64");
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlanCarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.PlanCarrera)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.PlanCarreraId)
                    .HasConstraintName("FK__Asignatur__PlanC__4D94879B");

                entity.HasMany(d => d.Correlativas)
                    .WithOne(p => p.Asignatura)
                    .HasForeignKey(d => d.AsignaturaId);

                entity.HasMany(d => d.Dependencias)
                    .WithOne(p => p.Correlativa)
                    .HasForeignKey(d => d.CorrelativaId);
            });

            modelBuilder.Entity<AsignaturaCorrelativa>(entity =>
            {
                entity.HasKey(e => new { e.AsignaturaId, e.CorrelativaId });
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DepartamentoUniversidadId).HasColumnName("DepartamentoUniversidadID");
                entity.Property(e => e.Duracion).HasDefaultValueSql("((1))");
                entity.Property(e => e.FechaCarga).HasColumnType("date");
                entity.Property(e => e.FechaModificacion).HasColumnType("date");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.TipoCarreraId).HasColumnName("TipoCarreraID");

                entity.HasOne(d => d.DepartamentoUniversidad)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.DepartamentoUniversidadId)
                    .HasConstraintName("FK__Carrera__Departa__4316F928");

                entity.HasOne(d => d.TipoCarrera)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.TipoCarreraId)
                    .HasConstraintName("FK__Carrera__TipoCar__4222D4EF");
            });

            modelBuilder.Entity<CarreraOrientacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Orientaciones)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__CarreraOr__Carre__48CFD27E");
            });

            modelBuilder.Entity<DepartamentoUniversidad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UniversidadCodigo).HasColumnName("UniversidadCodigo");

                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.UniversidadCodigo)
                    .HasConstraintName("FK__Departame__Unive__3D5E1FD2");
            });

            modelBuilder.Entity<PlanCarrera>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__PlanCarre__Carre__48CFD27E");
            });

            modelBuilder.Entity<SedeUniversidad>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.UniversidadCodigo).HasColumnName("UniversidadCodigo");
                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.UniversidadCodigo)
                    .HasConstraintName("FK__SedeUnive__Unive__3A81B327");
            });

            modelBuilder.Entity<TipoCarrera>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
