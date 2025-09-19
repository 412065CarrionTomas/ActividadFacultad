using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    [Table("Articles")]
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string NombreArticulo { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public Decimal PrecioUnitario { get; set; } = 0m;
        [Required]
        public int Activo { get; set; } = 0;

    }
}
