using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        [Required]      
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descricao { get; set; }
        public ICollection<LancheIngrediente> LancheIngredientes { get; set; } 

        public Lanche()
        {
            LancheIngredientes = new Collection<LancheIngrediente>();
        }
    }
}