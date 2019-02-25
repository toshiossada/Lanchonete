using Microsoft.EntityFrameworkCore.Migrations;

namespace Dextra.Lanchonete.Api.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "PedidoLanche",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoLanche_IngredienteId",
                table: "PedidoLanche",
                column: "IngredienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoLanche_Ingredientes_IngredienteId",
                table: "PedidoLanche",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoLanche_Ingredientes_IngredienteId",
                table: "PedidoLanche");

            migrationBuilder.DropIndex(
                name: "IX_PedidoLanche_IngredienteId",
                table: "PedidoLanche");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "PedidoLanche");
        }
    }
}
