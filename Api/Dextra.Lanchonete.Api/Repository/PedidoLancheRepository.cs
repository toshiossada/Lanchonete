using System.Collections.Generic;
using System.Linq;
using Dextra.Lanchonete.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Dextra.Lanchonete.Api.Repository {
    public class PedidoLancheRepository : IPedidoLancheRepository {

        private readonly MyAppContext _context;
        public PedidoLancheRepository (MyAppContext context) => _context = context;
        public void Add (PedidoLanche pedidoLanche) {
            _context.PedidosLanche.Add (pedidoLanche);
            _context.SaveChanges ();
        }

        public PedidoLanche Find (int id) {
            return _context
                .PedidosLanche
                .Include (r => r.IngredientesAdicionais)
                .Include (r => r.Lanche)
                .FirstOrDefault (r => r.Id == id);
        }
        public IEnumerable<PedidoLanche> GetAll () {
            return _context
                .PedidosLanche
                .Include (r => r.IngredientesAdicionais)
                .Include (r => r.Lanche)
                .ToList();
        }

        public void Remove (int id) {
            var entity = _context.PedidosLanche.First (r => r.Id == id);
            _context.PedidosLanche.Remove (entity);
            _context.SaveChanges ();
        }

        public void Update (PedidoLanche pedidoLanche) {
            _context.PedidosLanche.Update (pedidoLanche);
            _context.SaveChanges ();
        }
        
    }
}