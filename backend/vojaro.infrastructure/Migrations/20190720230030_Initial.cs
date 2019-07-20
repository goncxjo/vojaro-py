using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vojaro.infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(maxLength: 255, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Dirección = table.Column<string>(maxLength: 255, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 255, nullable: true),
                    Pais = table.Column<string>(maxLength: 255, nullable: true),
                    Telefono_1 = table.Column<string>(maxLength: 255, nullable: true),
                    Telefono_2 = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.ID);
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
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
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
                    UniversidadID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoUniversidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Departame__Unive__3D5E1FD2",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SedeUniversidad",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    UniversidadID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Dirección = table.Column<string>(maxLength: 255, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 255, nullable: true),
                    Pais = table.Column<string>(maxLength: 255, nullable: true),
                    Telefono_1 = table.Column<string>(maxLength: 255, nullable: true),
                    Telefono_2 = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeUniversidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SedeUnive__Unive__3A81B327",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    TipoCarreraID = table.Column<byte>(nullable: true),
                    DepartamentoUniversidadID = table.Column<long>(nullable: true),
                    UniversidadID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Duracion = table.Column<byte>(nullable: false, defaultValueSql: "((1))")
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
                    table.ForeignKey(
                        name: "FK__Carrera__Univers__440B1D61",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignatura",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AlumnoID = table.Column<long>(nullable: true),
                    CarreraID = table.Column<long>(nullable: true),
                    EstadoAsignatura = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK__AlumnoAsi__Alumn__5DCAEF64",
                        column: x => x.AlumnoID,
                        principalTable: "Alumno",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlumnoAsi__Carre__5EBF139D",
                        column: x => x.CarreraID,
                        principalTable: "Carrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    UniversidadID = table.Column<long>(nullable: true),
                    CarreraID = table.Column<long>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Cuatrimestre = table.Column<int>(nullable: false),
                    CargaHoraria = table.Column<byte>(nullable: false),
                    EsAsignaturaComun = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Asignatur__Carre__4D94879B",
                        column: x => x.CarreraID,
                        principalTable: "Carrera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Asignatur__Unive__4CA06362",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarreraOrientacion",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: true),
                    ModificadoPor = table.Column<long>(nullable: true),
                    Version = table.Column<int>(nullable: false),
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
                name: "AsignaturaCorrelativa",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AsignaturaID = table.Column<long>(nullable: true),
                    CorrelativaID = table.Column<long>(nullable: true),
                    Regularizada = table.Column<bool>(nullable: false),
                    Aprobada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCorrelativa", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Asignatur__Asign__5441852A",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Asignatur__Corre__5535A963",
                        column: x => x.CorrelativaID,
                        principalTable: "Asignatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_AlumnoID",
                table: "AlumnoAsignatura",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_CarreraID",
                table: "AlumnoAsignatura",
                column: "CarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_CarreraID",
                table: "Asignatura",
                column: "CarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_UniversidadID",
                table: "Asignatura",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCorrelativa_AsignaturaID",
                table: "AsignaturaCorrelativa",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCorrelativa_CorrelativaID",
                table: "AsignaturaCorrelativa",
                column: "CorrelativaID");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_DepartamentoUniversidadID",
                table: "Carrera",
                column: "DepartamentoUniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_TipoCarreraID",
                table: "Carrera",
                column: "TipoCarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_UniversidadID",
                table: "Carrera",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraOrientacion_CarreraID",
                table: "CarreraOrientacion",
                column: "CarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoUniversidad_UniversidadID",
                table: "DepartamentoUniversidad",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_SedeUniversidad_UniversidadID",
                table: "SedeUniversidad",
                column: "UniversidadID");
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
