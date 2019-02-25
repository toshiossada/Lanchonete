using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dextra.Lanchonete.Api.Migrations
{
    public partial class Correcao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientesAdicionais",
                table: "IngredientesAdicionais");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IngredientesAdicionais",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientesAdicionais",
                table: "IngredientesAdicionais",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesAdicionais_IngredienteId",
                table: "IngredientesAdicionais",
                column: "IngredienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientesAdicionais",
                table: "IngredientesAdicionais");

            migrationBuilder.DropIndex(
                name: "IX_IngredientesAdicionais_IngredienteId",
                table: "IngredientesAdicionais");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredientesAdicionais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientesAdicionais",
                table: "IngredientesAdicionais",
                columns: new[] { "IngredienteId", "PedidoLancheId" });
        }
    }
}
