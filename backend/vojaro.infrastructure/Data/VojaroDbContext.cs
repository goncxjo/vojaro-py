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
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ciudad).HasMaxLength(255);

                entity.Property(e => e.Dirección).HasMaxLength(255);

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pais).HasMaxLength(255);

                entity.Property(e => e.Telefono1)
                    .HasColumnName("Telefono_1")
                    .HasMaxLength(255);

                entity.Property(e => e.Telefono2)
                    .HasColumnName("Telefono_2")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AlumnoAsignatura>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.EstadoAsignatura)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.AlumnoAsignatura)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK__AlumnoAsi__Alumn__5DCAEF64");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.AlumnoAsignatura)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__AlumnoAsi__Carre__5EBF139D");
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UniversidadId).HasColumnName("UniversidadID");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Asignatura)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__Asignatur__Carre__4D94879B");

                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.Asignatura)
                    .HasForeignKey(d => d.UniversidadId)
                    .HasConstraintName("FK__Asignatur__Unive__4CA06362");
            });

            modelBuilder.Entity<AsignaturaCorrelativa>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AsignaturaId).HasColumnName("AsignaturaID");

                entity.Property(e => e.CorrelativaId).HasColumnName("CorrelativaID");

                entity.HasOne(d => d.Asignatura)
                    .WithMany(p => p.AsignaturaCorrelativaAsignatura)
                    .HasForeignKey(d => d.AsignaturaId)
                    .HasConstraintName("FK__Asignatur__Asign__5441852A");

                entity.HasOne(d => d.Correlativa)
                    .WithMany(p => p.AsignaturaCorrelativaCorrelativa)
                    .HasForeignKey(d => d.CorrelativaId)
                    .HasConstraintName("FK__Asignatur__Corre__5535A963");
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

                entity.Property(e => e.UniversidadId).HasColumnName("UniversidadID");

                entity.HasOne(d => d.DepartamentoUniversidad)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.DepartamentoUniversidadId)
                    .HasConstraintName("FK__Carrera__Departa__4316F928");

                entity.HasOne(d => d.TipoCarrera)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.TipoCarreraId)
                    .HasConstraintName("FK__Carrera__TipoCar__4222D4EF");

                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.UniversidadId)
                    .HasConstraintName("FK__Carrera__Univers__440B1D61");
            });

            modelBuilder.Entity<CarreraOrientacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.FechaCarga).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.CarreraOrientacion)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__CarreraOr__Carre__48CFD27E");
            });

            modelBuilder.Entity<DepartamentoUniversidad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UniversidadId).HasColumnName("UniversidadID");

                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.DepartamentoUniversidad)
                    .HasForeignKey(d => d.UniversidadId)
                    .HasConstraintName("FK__Departame__Unive__3D5E1FD2");
            });

            modelBuilder.Entity<SedeUniversidad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ciudad).HasMaxLength(255);

                entity.Property(e => e.Dirección).HasMaxLength(255);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pais).HasMaxLength(255);

                entity.Property(e => e.Telefono1)
                    .HasColumnName("Telefono_1")
                    .HasMaxLength(255);

                entity.Property(e => e.Telefono2)
                    .HasColumnName("Telefono_2")
                    .HasMaxLength(255);

                entity.Property(e => e.UniversidadId).HasColumnName("UniversidadID");

                entity.HasOne(d => d.Universidad)
                    .WithMany(p => p.SedeUniversidad)
                    .HasForeignKey(d => d.UniversidadId)
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
                entity.Property(e => e.Id).HasColumnName("ID");

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
