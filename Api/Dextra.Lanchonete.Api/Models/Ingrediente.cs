using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dextra.Lanchonete.Api.Models {
    [Table ("Ingredientes")]
    public class Ingrediente {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength (250)]
        public string Descricao { get; set; }

        [Required]
        public double Valor { get; set; }
    }
}