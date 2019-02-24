using Microsoft.EntityFrameworkCore;

namespace Dextra.Lanchonete.Api.Models {
    public class MyAppContext : DbContext {
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<PedidoLanche> PedidosLanche { get; set; }
        public MyAppContext (DbContextOptions<MyAppContext> options) : base (options) {

        }

        protected override void OnModelCreating(ModelBuilder mb){
            mb.Entity<LancheIngrediente>().HasKey(r => new{ r.IngredienteId, r.LancheId });
            mb.Entity<IngredienteAdicional>().HasKey(r => new{ r.IngredienteId, r.PedidoLancheId });
        }
    }
}