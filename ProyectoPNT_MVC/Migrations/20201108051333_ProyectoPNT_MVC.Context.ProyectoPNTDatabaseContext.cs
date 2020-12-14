using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPNT_MVC.Migrations
{
    public partial class ProyectoPNT_MVCContextProyectoPNTDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroArticulo = table.Column<int>(nullable: false),
                    precio = table.Column<double>(nullable: false),
                    descripcion = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    imagen = table.Column<string>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    talle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroPedido = table.Column<int>(nullable: false),
                    fechaCompra = table.Column<DateTime>(nullable: false),
                    articuloId = table.Column<int>(nullable: false),
                    precioTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(nullable: false),
                    nombreCompleto = table.Column<string>(maxLength: 100, nullable: false),
                    contraseña = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    mail = table.Column<string>(nullable: false),
                    carritoId = table.Column<int>(nullable: false),
                    deseadosId = table.Column<int>(nullable: false),
                    ComprasId = table.Column<int>(nullable: false),
                    tipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListaArticulos",
                columns: table => new
                {
                    articuloId = table.Column<int>(nullable: false),
                    compraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaArticulos", x => new { x.articuloId, x.compraId });
                    table.ForeignKey(
                        name: "FK_ListaArticulos_Articulos_articuloId",
                        column: x => x.articuloId,
                        principalTable: "Articulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaArticulos_Compras_compraId",
                        column: x => x.compraId,
                        principalTable: "Compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    articuloId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => new { x.articuloId, x.usuarioId });
                    table.ForeignKey(
                        name: "FK_Carrito_Articulos_articuloId",
                        column: x => x.articuloId,
                        principalTable: "Articulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaCompras",
                columns: table => new
                {
                    compraId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaCompras", x => new { x.compraId, x.usuarioId });
                    table.ForeignKey(
                        name: "FK_ListaCompras_Compras_compraId",
                        column: x => x.compraId,
                        principalTable: "Compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaCompras_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaDeseados",
                columns: table => new
                {
                    articuloId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeseados", x => new { x.articuloId, x.usuarioId });
                    table.ForeignKey(
                        name: "FK_ListaDeseados_Articulos_articuloId",
                        column: x => x.articuloId,
                        principalTable: "Articulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaDeseados_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_usuarioId",
                table: "Carrito",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaArticulos_compraId",
                table: "ListaArticulos",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaCompras_usuarioId",
                table: "ListaCompras",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeseados_usuarioId",
                table: "ListaDeseados",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "ListaArticulos");

            migrationBuilder.DropTable(
                name: "ListaCompras");

            migrationBuilder.DropTable(
                name: "ListaDeseados");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
