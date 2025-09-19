using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    [Table("InvoiceDetails")]
    public class InvoiceDetail
    {
        public int Id { get; set; }
        [Required]
        public int nroFactura { get; set; } = 0;
        [Required]
        public Article article { get; set; } = new Article() { Id = 0, NombreArticulo = "", PrecioUnitario = 0m };
        [Required]
        public int cantidad { get; set; } = 0;
        [Required]
        public int Activo { get; set; } = 0;
    }
}
