using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models {
    [Table ("IngredientesAdicionais")]
    public class IngredienteAdicional {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PedidoLancheId { get; set; }

        [Required]
        public int IngredienteId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public PedidoLanche PedidoLanche { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}