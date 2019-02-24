using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;

namespace Dextra.Lanchonete.Api.Business
{
    public interface IPedidoLancheBll
    {
        
        void Add (PedidoLanche pedidoLanche);
        IEnumerable<PedidoLanche> GetAll ();
        PedidoLanche Find (int id);
        void Remove (int id);
        void Update (PedidoLanche pedidoLanche);
        double CalcularPrecoLanche (PedidoLanche pedidoLanche);
    }
}