using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;

namespace Dextra.Lanchonete.Api.Repository {
    public interface ILancheRepository {
        void Add (Lanche lanche);
        IEnumerable<Lanche> GetAll ();
        Lanche Find (int id);
        void Remove (int id);
        void Update (Lanche lanche);
    }
}