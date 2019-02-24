using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models {
    [Table ("PedidoLanche")]
    public class PedidoLanche {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdLanche { get; set; }
        public double ValorFinal { get; set; }

        public virtual Lanche Lanche { get; set; }

        public ICollection<IngredienteAdicional> IngredientesAdicionais { get; set; }

        public PedidoLanche () {
            IngredientesAdicionais = new Collection<IngredienteAdicional> ();
        }

    }
}