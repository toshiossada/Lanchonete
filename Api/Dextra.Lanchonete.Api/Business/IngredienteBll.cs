using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;

namespace Dextra.Lanchonete.Api.Business
{
    public class IngredienteBll : IIngredienteBll
    {
        private readonly IIngredienteRepository _ingredienteRepository;
        public IngredienteBll (IIngredienteRepository ingredienteRepository) {
            _ingredienteRepository = ingredienteRepository;
        }

        public void Add(Ingrediente ingrediente)
        {
            _ingredienteRepository.Add(ingrediente);
        }

        public Ingrediente Find(int id)
        {
            return _ingredienteRepository.Find(id);
        }

        public Ingrediente FindByDescription(string description)
        {
            return _ingredienteRepository.FindByDescription(description);
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _ingredienteRepository.GetAll();
        }

        public void Remove(int id)
        {
            _ingredienteRepository.Remove(id);
        }

        public void Update(Ingrediente ingrediente)
        {
            _ingredienteRepository.Update(ingrediente);
        }
    }
}