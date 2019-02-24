using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;

namespace Dextra.Lanchonete.Api.Repository
{
    public interface IPedidoLancheRepository
    {
         
        void Add (PedidoLanche pedidoLanche);
        IEnumerable<PedidoLanche> GetAll ();
        PedidoLanche Find (int id);
        void Remove (int id);
        void Update (PedidoLanche pedidoLanche);
   
    }
}