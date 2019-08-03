using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vojaro.infrastructure.Migrations
{
    public partial class Unua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    DNI = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(maxLength: 255, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.DNI);
                });

            migrationBuilder.CreateTable(
                name: "TipoCarrera",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCarrera", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoUniversidad",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniversidadId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoUniversidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Departame__Unive__3D5E1FD2",
                        column: x => x.UniversidadId,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SedeUniversidad",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniversidadId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeUniversidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SedeUnive__Unive__3A81B327",
                        column: x => x.UniversidadId,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoCarreraID = table.Column<byte>(nullable: true),
                    DepartamentoUniversidadID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Duracion = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Carrera__Departa__4316F928",
                        column: x => x.DepartamentoUniversidadID,
                        principalTable: "DepartamentoUniversidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Carrera__TipoCar__4222D4EF",
                        column: x => x.TipoCarreraID,
                        principalTable: "TipoCarrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarreraOrientacion",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarreraID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraOrientacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CarreraOr__Carre__48CFD27E",
                        column: x => x.CarreraID,
                        principalTable: "Carrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanCarrera",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarreraId = table.Column<long>(nullable: false),
                    Anio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCarrera", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PlanCarre__Carre__48CFD27E",
                        column: x => x.CarreraId,
                        principalTable: "Carrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanCarreraID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Cuatrimestre = table.Column<int>(nullable: false),
                    CargaHoraria = table.Column<byte>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: true),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Asignatura_PlanCarrera_PlanCarreraID",
                        column: x => x.PlanCarreraID,
                        principalTable: "PlanCarrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignatura",
                columns: table => new
                {
                    AlumnoId = table.Column<long>(nullable: false),
                    AsignaturaId = table.Column<long>(nullable: false),
                    EstadoAsignatura = table.Column<string>(maxLength: 100, nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignatura", x => new { x.AlumnoId, x.AsignaturaId });
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignaturaCorrelativa",
                columns: table => new
                {
                    AsignaturaId = table.Column<long>(nullable: false),
                    CorrelativaId = table.Column<long>(nullable: false),
                    Regularizada = table.Column<bool>(nullable: false),
                    Aprobada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCorrelativa", x => new { x.AsignaturaId, x.CorrelativaId });
                    table.ForeignKey(
                        name: "FK_AsignaturaCorrelativa_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsignaturaCorrelativa_Asignatura_CorrelativaId",
                        column: x => x.CorrelativaId,
                        principalTable: "Asignatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_AsignaturaId",
                table: "AlumnoAsignatura",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_PlanCarreraID",
                table: "Asignatura",
                column: "PlanCarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCorrelativa_CorrelativaId",
                table: "AsignaturaCorrelativa",
                column: "CorrelativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_DepartamentoUniversidadID",
                table: "Carrera",
                column: "DepartamentoUniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_TipoCarreraID",
                table: "Carrera",
                column: "TipoCarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraOrientacion_CarreraID",
                table: "CarreraOrientacion",
                column: "CarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoUniversidad_UniversidadId",
                table: "DepartamentoUniversidad",
                column: "UniversidadId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCarrera_CarreraId",
                table: "PlanCarrera",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_SedeUniversidad_UniversidadId",
                table: "SedeUniversidad",
                column: "UniversidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoAsignatura");

            migrationBuilder.DropTable(
                name: "AsignaturaCorrelativa");

            migrationBuilder.DropTable(
                name: "CarreraOrientacion");

            migrationBuilder.DropTable(
                name: "SedeUniversidad");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "PlanCarrera");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "DepartamentoUniversidad");

            migrationBuilder.DropTable(
                name: "TipoCarrera");

            migrationBuilder.DropTable(
                name: "Universidad");
        }
    }
}
