using Microsoft.EntityFrameworkCore.Migrations;

namespace Dextra.Lanchonete.Api.Migrations
{
    public partial class Popula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql ("INSERT INTO Ingredientes(Descricao, Valor) VALUES('Alface', 0.4);");
            migrationBuilder.Sql ("INSERT INTO Ingredientes(Descricao, Valor) VALUES('Bacon', 2);");
            migrationBuilder.Sql ("INSERT INTO Ingredientes(Descricao, Valor) VALUES('Hambúrguer de carne', 3);");
            migrationBuilder.Sql ("INSERT INTO Ingredientes(Descricao, Valor) VALUES('Ovo', 0.8);");
            migrationBuilder.Sql ("INSERT INTO Ingredientes(Descricao, Valor) VALUES('Queijo', 1.5);");

            migrationBuilder.Sql ("INSERT INTO Lanches(Descricao) VALUES('X-Bacon');");
            migrationBuilder.Sql ("INSERT INTO Lanches(Descricao) VALUES('X-Burger');");
            migrationBuilder.Sql ("INSERT INTO Lanches(Descricao) VALUES('X-Egg');");
            migrationBuilder.Sql ("INSERT INTO Lanches(Descricao) VALUES('X-Egg-Bacon');");


            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Bacon'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Hambúrguer de carne'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Queijo'));");

            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Burger'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Hambúrguer de carne'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Burger'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Queijo'));");
            
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Ovo'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Hambúrguer de carne'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Queijo'));");

            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Ovo'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Bacon'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Hambúrguer de carne'));");
            migrationBuilder.Sql ("INSERT INTO LancheIngredientes(LancheId, IngredienteId) VALUES((select Top 1 Id from Lanches WHERE Descricao = 'X-Egg-Bacon'), (select Top 1 Id from Ingredientes WHERE Descricao = 'Queijo'));");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql ("DELETE LancheIngredientes;");
            migrationBuilder.Sql ("DELETE Ingredientes;");
            migrationBuilder.Sql ("DELETE Lanches;");

        }
    }
}
