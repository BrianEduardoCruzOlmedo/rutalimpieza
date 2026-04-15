using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAspnet.Migrations
{
    /// <inheritdoc />
    public partial class Prueba1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    id_chofer = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choferes", x => x.id_chofer);
                });

            migrationBuilder.CreateTable(
                name: "Colonias",
                columns: table => new
                {
                    id_colonia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Habitantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Km_carretera = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonias", x => x.id_colonia);
                });

            migrationBuilder.CreateTable(
                name: "Despachadores",
                columns: table => new
                {
                    id_despachador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despachadores", x => x.id_despachador);
                });

            migrationBuilder.CreateTable(
                name: "Folio_Detalles",
                columns: table => new
                {
                    id_detalle = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_folio = table.Column<int>(type: "INTEGER", nullable: false),
                    id_colonia = table.Column<int>(type: "INTEGER", nullable: false),
                    Km_Limpiados_En_Este_Folio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Porcentaje_Alcanzado_En_Este_Folio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folio_Detalles", x => x.id_detalle);
                });

            migrationBuilder.CreateTable(
                name: "Folios",
                columns: table => new
                {
                    Id_Folio = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha_orden = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_captura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Turno = table.Column<int>(type: "INTEGER", nullable: false),
                    id_ruta = table.Column<int>(type: "INTEGER", nullable: false),
                    id_despachador = table.Column<int>(type: "INTEGER", nullable: false),
                    id_chofer = table.Column<int>(type: "INTEGER", nullable: false),
                    id_tipo_unidad = table.Column<int>(type: "INTEGER", nullable: false),
                    id_unidadcantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    puches = table.Column<decimal>(type: "TEXT", nullable: false),
                    km_salir = table.Column<decimal>(type: "TEXT", nullable: false),
                    km_regreso = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_inicio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_Final = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_cargado = table.Column<decimal>(type: "TEXT", nullable: false),
                    Diesel_unidad = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folios", x => x.Id_Folio);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Unidades",
                columns: table => new
                {
                    id_tipo_unidad = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre_Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Unidades", x => x.id_tipo_unidad);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    id_unidad = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre_Unidad = table.Column<string>(type: "TEXT", nullable: false),
                    id_tipo_unidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.id_unidad);
                    table.ForeignKey(
                        name: "FK_Unidades_Tipos_Unidades_id_tipo_unidad",
                        column: x => x.id_tipo_unidad,
                        principalTable: "Tipos_Unidades",
                        principalColumn: "id_tipo_unidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_id_tipo_unidad",
                table: "Unidades",
                column: "id_tipo_unidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropTable(
                name: "Colonias");

            migrationBuilder.DropTable(
                name: "Despachadores");

            migrationBuilder.DropTable(
                name: "Folio_Detalles");

            migrationBuilder.DropTable(
                name: "Folios");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Tipos_Unidades");
        }
    }
}
