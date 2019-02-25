using Microsoft.EntityFrameworkCore.Migrations;

namespace Dextra.Lanchonete.Api.Migrations
{
    public partial class UpdateDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorFinal",
                table: "PedidoLanche",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "LancheId",
                table: "PedidoLanche",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Ingredientes",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_PedidoLanche_LancheId",
                table: "PedidoLanche",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoLanche_Lanches_LancheId",
                table: "PedidoLanche",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoLanche_Lanches_LancheId",
                table: "PedidoLanche");

            migrationBuilder.DropIndex(
                name: "IX_PedidoLanche_LancheId",
                table: "PedidoLanche");

            migrationBuilder.DropColumn(
                name: "LancheId",
                table: "PedidoLanche");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFinal",
                table: "PedidoLanche",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Ingredientes",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
