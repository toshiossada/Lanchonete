using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dextra.Lanchonete.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoLanche",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdLanche = table.Column<int>(nullable: false),
                    ValorFinal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoLanche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancheIngredientes",
                columns: table => new
                {
                    LancheId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancheIngredientes", x => new { x.IngredienteId, x.LancheId });
                    table.ForeignKey(
                        name: "FK_LancheIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancheIngredientes_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientesAdicionais",
                columns: table => new
                {
                    PedidoLancheId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesAdicionais", x => new { x.IngredienteId, x.PedidoLancheId });
                    table.ForeignKey(
                        name: "FK_IngredientesAdicionais_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientesAdicionais_PedidoLanche_PedidoLancheId",
                        column: x => x.PedidoLancheId,
                        principalTable: "PedidoLanche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesAdicionais_PedidoLancheId",
                table: "IngredientesAdicionais",
                column: "PedidoLancheId");

            migrationBuilder.CreateIndex(
                name: "IX_LancheIngredientes_LancheId",
                table: "LancheIngredientes",
                column: "LancheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientesAdicionais");

            migrationBuilder.DropTable(
                name: "LancheIngredientes");

            migrationBuilder.DropTable(
                name: "PedidoLanche");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Lanches");
        }
    }
}
