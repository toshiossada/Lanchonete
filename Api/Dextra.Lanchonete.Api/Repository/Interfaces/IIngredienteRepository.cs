using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;

namespace Dextra.Lanchonete.Api.Repository {
    public interface IIngredienteRepository {
        void Add (Ingrediente ingrediente);
        IEnumerable<Ingrediente> GetAll ();
        Ingrediente Find (int id);
        Ingrediente FindByDescription(string description);
        void Remove (int id);
        void Update (Ingrediente ingrediente);
    }
}