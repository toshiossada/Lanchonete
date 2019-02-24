using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models
{
    [Table("LancheIngredientes")]
    public class LancheIngrediente
    {        
        public int LancheId { get; set; }
        public int IngredienteId { get; set; }

        public virtual Lanche Lanches { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
    }
}