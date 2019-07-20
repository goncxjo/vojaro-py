﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Migrations
{
    [DbContext(typeof(VojaroDbContext))]
    partial class VojaroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vojaro.core.Entities.Alumno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Ciudad")
                        .HasMaxLength(255);

                    b.Property<string>("Dirección")
                        .HasMaxLength(255);

                    b.Property<int>("Edad");

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Pais")
                        .HasMaxLength(255);

                    b.Property<string>("Telefono1")
                        .HasColumnName("Telefono_1")
                        .HasMaxLength(255);

                    b.Property<string>("Telefono2")
                        .HasColumnName("Telefono_2")
                        .HasMaxLength(255);

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("vojaro.core.Entities.AlumnoAsignatura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AlumnoId")
                        .HasColumnName("AlumnoID");

                    b.Property<long?>("CarreraId")
                        .HasColumnName("CarreraID");

                    b.Property<string>("EstadoAsignatura")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("CarreraId");

                    b.ToTable("AlumnoAsignatura");
                });

            modelBuilder.Entity("vojaro.core.Entities.Asignatura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("CargaHoraria");

                    b.Property<long?>("CarreraId")
                        .HasColumnName("CarreraID");

                    b.Property<string>("Codigo")
                        .HasMaxLength(10);

                    b.Property<int>("Cuatrimestre");

                    b.Property<bool>("EsAsignaturaComun");

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long?>("UniversidadId")
                        .HasColumnName("UniversidadID");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.HasIndex("UniversidadId");

                    b.ToTable("Asignatura");
                });

            modelBuilder.Entity("vojaro.core.Entities.AsignaturaCorrelativa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprobada");

                    b.Property<long?>("AsignaturaId")
                        .HasColumnName("AsignaturaID");

                    b.Property<long?>("CorrelativaId")
                        .HasColumnName("CorrelativaID");

                    b.Property<bool>("Regularizada");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.HasIndex("CorrelativaId");

                    b.ToTable("AsignaturaCorrelativa");
                });

            modelBuilder.Entity("vojaro.core.Entities.Carrera", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DepartamentoUniversidadId")
                        .HasColumnName("DepartamentoUniversidadID");

                    b.Property<byte>("Duracion")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<byte?>("TipoCarreraId")
                        .HasColumnName("TipoCarreraID");

                    b.Property<long?>("UniversidadId")
                        .HasColumnName("UniversidadID");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoUniversidadId");

                    b.HasIndex("TipoCarreraId");

                    b.HasIndex("UniversidadId");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("vojaro.core.Entities.CarreraOrientacion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CarreraId")
                        .HasColumnName("CarreraID");

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("CarreraOrientacion");
                });

            modelBuilder.Entity("vojaro.core.Entities.DepartamentoUniversidad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long?>("UniversidadId")
                        .HasColumnName("UniversidadID");

                    b.HasKey("Id");

                    b.HasIndex("UniversidadId");

                    b.ToTable("DepartamentoUniversidad");
                });

            modelBuilder.Entity("vojaro.core.Entities.SedeUniversidad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasMaxLength(255);

                    b.Property<string>("Dirección")
                        .HasMaxLength(255);

                    b.Property<DateTime>("FechaCarga");

                    b.Property<DateTime?>("FechaModificacion");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Pais")
                        .HasMaxLength(255);

                    b.Property<string>("Telefono1")
                        .HasColumnName("Telefono_1")
                        .HasMaxLength(255);

                    b.Property<string>("Telefono2")
                        .HasColumnName("Telefono_2")
                        .HasMaxLength(255);

                    b.Property<long?>("UniversidadId")
                        .HasColumnName("UniversidadID");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("UniversidadId");

                    b.ToTable("SedeUniversidad");
                });

            modelBuilder.Entity("vojaro.core.Entities.TipoCarrera", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TipoCarrera");
                });

            modelBuilder.Entity("vojaro.core.Entities.Universidad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<long?>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Universidad");
                });

            modelBuilder.Entity("vojaro.core.Entities.AlumnoAsignatura", b =>
                {
                    b.HasOne("vojaro.core.Entities.Alumno", "Alumno")
                        .WithMany("AlumnoAsignatura")
                        .HasForeignKey("AlumnoId")
                        .HasConstraintName("FK__AlumnoAsi__Alumn__5DCAEF64");

                    b.HasOne("vojaro.core.Entities.Carrera", "Carrera")
                        .WithMany("AlumnoAsignatura")
                        .HasForeignKey("CarreraId")
                        .HasConstraintName("FK__AlumnoAsi__Carre__5EBF139D");
                });

            modelBuilder.Entity("vojaro.core.Entities.Asignatura", b =>
                {
                    b.HasOne("vojaro.core.Entities.Carrera", "Carrera")
                        .WithMany("Asignatura")
                        .HasForeignKey("CarreraId")
                        .HasConstraintName("FK__Asignatur__Carre__4D94879B");

                    b.HasOne("vojaro.core.Entities.Universidad", "Universidad")
                        .WithMany("Asignatura")
                        .HasForeignKey("UniversidadId")
                        .HasConstraintName("FK__Asignatur__Unive__4CA06362");
                });

            modelBuilder.Entity("vojaro.core.Entities.AsignaturaCorrelativa", b =>
                {
                    b.HasOne("vojaro.core.Entities.Asignatura", "Asignatura")
                        .WithMany("AsignaturaCorrelativaAsignatura")
                        .HasForeignKey("AsignaturaId")
                        .HasConstraintName("FK__Asignatur__Asign__5441852A");

                    b.HasOne("vojaro.core.Entities.Asignatura", "Correlativa")
                        .WithMany("AsignaturaCorrelativaCorrelativa")
                        .HasForeignKey("CorrelativaId")
                        .HasConstraintName("FK__Asignatur__Corre__5535A963");
                });

            modelBuilder.Entity("vojaro.core.Entities.Carrera", b =>
                {
                    b.HasOne("vojaro.core.Entities.DepartamentoUniversidad", "DepartamentoUniversidad")
                        .WithMany("Carrera")
                        .HasForeignKey("DepartamentoUniversidadId")
                        .HasConstraintName("FK__Carrera__Departa__4316F928");

                    b.HasOne("vojaro.core.Entities.TipoCarrera", "TipoCarrera")
                        .WithMany("Carrera")
                        .HasForeignKey("TipoCarreraId")
                        .HasConstraintName("FK__Carrera__TipoCar__4222D4EF");

                    b.HasOne("vojaro.core.Entities.Universidad", "Universidad")
                        .WithMany("Carrera")
                        .HasForeignKey("UniversidadId")
                        .HasConstraintName("FK__Carrera__Univers__440B1D61");
                });

            modelBuilder.Entity("vojaro.core.Entities.CarreraOrientacion", b =>
                {
                    b.HasOne("vojaro.core.Entities.Carrera", "Carrera")
                        .WithMany("CarreraOrientacion")
                        .HasForeignKey("CarreraId")
                        .HasConstraintName("FK__CarreraOr__Carre__48CFD27E");
                });

            modelBuilder.Entity("vojaro.core.Entities.DepartamentoUniversidad", b =>
                {
                    b.HasOne("vojaro.core.Entities.Universidad", "Universidad")
                        .WithMany("DepartamentoUniversidad")
                        .HasForeignKey("UniversidadId")
                        .HasConstraintName("FK__Departame__Unive__3D5E1FD2");
                });

            modelBuilder.Entity("vojaro.core.Entities.SedeUniversidad", b =>
                {
                    b.HasOne("vojaro.core.Entities.Universidad", "Universidad")
                        .WithMany("SedeUniversidad")
                        .HasForeignKey("UniversidadId")
                        .HasConstraintName("FK__SedeUnive__Unive__3A81B327");
                });
#pragma warning restore 612, 618
        }
    }
}
