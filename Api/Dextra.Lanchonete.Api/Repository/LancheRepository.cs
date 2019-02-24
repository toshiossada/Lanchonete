using System.Collections.Generic;
using System.Linq;
using Dextra.Lanchonete.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Dextra.Lanchonete.Api.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly MyAppContext _context;
        public LancheRepository(MyAppContext context) => _context = context;
        public void Add(Lanche lanche)
        {
            _context.Lanches.Add(lanche);
            _context.SaveChanges();
        }

        public Lanche Find(int id)
        {
            return _context.Lanches
                            .Include(t => t.LancheIngredientes)
                            .Include("LancheIngredientes.Ingrediente")
                            .FirstOrDefault(r => r.Id == id);
        } 
        public IEnumerable<Lanche> GetAll()
        {
            var result = _context
                            .Lanches
                            .Include(t => t.LancheIngredientes)
                            .Include("LancheIngredientes.Ingrediente")
                            .ToList();
            return result;
        }

        public void Remove(int id)
        {
            var entity = _context.Lanches.First(r => r.Id == id);
            _context.Lanches.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Lanche lanche)
        {
            _context.Lanches.Update(lanche);
            _context.SaveChanges();
        }
    }
}