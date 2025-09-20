using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    [Table("Invoices")]
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required]
        public PaymentMethod paymentMethod { get; set; } = new PaymentMethod() { Id = 0, nombreFormaPago = "" };
        [Required]
        public string Cliente { get; set; } = string.Empty;
        [Required]
        public List<InvoiceDetail> invoiceDetailsList { get; set; } = new List<InvoiceDetail>(){ new InvoiceDetail()
        {
            Id = 0,
            Activo = 0,
            cantidad = 0,
            nroFactura = 0,
            article = new Article() { Activo = 0, NombreArticulo = "", Id = 0, PrecioUnitario = 0m }
        } 
        };
        [Required]
        public int Activo { get; set; } = 0;

        public Invoice()
        {
            invoiceDetailsList = new List<InvoiceDetail>();
        }
    }
}
