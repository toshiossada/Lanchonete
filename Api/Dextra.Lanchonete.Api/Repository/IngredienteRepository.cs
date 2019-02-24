using System.Collections.Generic;
using System.Linq;
using Dextra.Lanchonete.Api.Models;

namespace Dextra.Lanchonete.Api.Repository
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly MyAppContext _context;
        public IngredienteRepository(MyAppContext context) => _context = context;
        public void Add(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            _context.SaveChanges();
        }

        public Ingrediente Find(int id) =>  _context.Ingredientes.FirstOrDefault(r => r.Id == id);

        public Ingrediente FindByDescription(string description) => _context.Ingredientes.Where(r => r.Descricao == description).FirstOrDefault();

        public IEnumerable<Ingrediente> GetAll() => _context.Ingredientes.ToList();

        public void Remove(int id)
        {
            var entity = _context.Ingredientes.First(r => r.Id == id);
            _context.Ingredientes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Ingrediente ingrediente)
        {
            _context.Ingredientes.Update(ingrediente);
            _context.SaveChanges();
        }
    }
}