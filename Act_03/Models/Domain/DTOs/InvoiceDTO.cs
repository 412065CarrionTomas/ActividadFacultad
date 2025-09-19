using Act_01.Domain;

namespace Act_03.Models.Domain.DTOs
{
    public class InvoiceDTO
    {
        public DateTime Fecha { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Cliente { get; set; }
        public int Activo { get; set; }

        public InvoiceDTO(Invoice invoice)
        {
            Fecha = invoice.Fecha;
            PaymentMethod = invoice.paymentMethod;
            Cliente = invoice.Cliente;
            Activo = invoice.Activo;
        }
    }
}
