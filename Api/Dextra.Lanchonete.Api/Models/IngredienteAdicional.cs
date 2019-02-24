using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models {
    [Table ("IngredientesAdicionais")]
    public class IngredienteAdicional {
        [Required]
        public int PedidoLancheId { get; set; }

        [Required]
        public int IngredienteId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual PedidoLanche PedidoLanche { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
    }
}