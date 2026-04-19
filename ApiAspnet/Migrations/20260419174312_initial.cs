using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAspnet.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colonias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Habitantes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    KM_Estimados = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Unidades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    LtrsDieselTanque = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Unidades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RutaDetalleColonia",
                columns: table => new
                {
                    ID_Ruta = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Colonia = table.Column<int>(type: "INTEGER", nullable: false),
                    HabitantesAtendidos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaDetalleColonia", x => new { x.ID_Ruta, x.ID_Colonia });
                    table.ForeignKey(
                        name: "FK_RutaDetalleColonia_Colonias_ID_Colonia",
                        column: x => x.ID_Colonia,
                        principalTable: "Colonias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutaDetalleColonia_Rutas_ID_Ruta",
                        column: x => x.ID_Ruta,
                        principalTable: "Rutas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ID_TipoUnidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_Tipos_Unidades_ID_TipoUnidad",
                        column: x => x.ID_TipoUnidad,
                        principalTable: "Tipos_Unidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha_orden = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_TerminoEstimado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_TerminoReal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ID_Unidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Ruta = table.Column<int>(type: "INTEGER", nullable: false),
                    km_Recorridos = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_inicio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_Recargado = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_Final = table.Column<decimal>(type: "TEXT", nullable: false),
                    CapacidadDiesel = table.Column<decimal>(type: "TEXT", nullable: false),
                    Autonomia = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Folios_Rutas_ID_Ruta",
                        column: x => x.ID_Ruta,
                        principalTable: "Rutas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folios_Unidades_ID_Unidad",
                        column: x => x.ID_Unidad,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isChofer = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    DetalleDiarioID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empleados_Folios_DetalleDiarioID",
                        column: x => x.DetalleDiarioID,
                        principalTable: "Folios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DetalleDiarioID",
                table: "Empleados",
                column: "DetalleDiarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Folios_ID_Ruta",
                table: "Folios",
                column: "ID_Ruta");

            migrationBuilder.CreateIndex(
                name: "IX_Folios_ID_Unidad",
                table: "Folios",
                column: "ID_Unidad");

            migrationBuilder.CreateIndex(
                name: "IX_RutaDetalleColonia_ID_Colonia",
                table: "RutaDetalleColonia",
                column: "ID_Colonia");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_ID_TipoUnidad",
                table: "Unidades",
                column: "ID_TipoUnidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "RutaDetalleColonia");

            migrationBuilder.DropTable(
                name: "Folios");

            migrationBuilder.DropTable(
                name: "Colonias");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Tipos_Unidades");
        }
    }
}
