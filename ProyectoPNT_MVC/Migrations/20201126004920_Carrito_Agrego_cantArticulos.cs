using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPNT_MVC.Migrations
{
    public partial class Carrito_Agrego_cantArticulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComprasId",
                table: "Usuarios",
                newName: "comprasId");

            migrationBuilder.AddColumn<int>(
                name: "cantArticulos",
                table: "Carrito",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantArticulos",
                table: "Carrito");

            migrationBuilder.RenameColumn(
                name: "comprasId",
                table: "Usuarios",
                newName: "ComprasId");
        }
    }
}
