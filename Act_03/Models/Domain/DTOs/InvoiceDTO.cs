using Act_01.Domain;
using System.Linq;

namespace Act_03.Models.Domain.DTOs
{
    public class InvoiceDTO
    {
        public int? IdInvoice { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPaymentMethod { get; set; }
        public string Cliente { get; set; }
        public List<InvoiceDetailDTO> InvoiceDetailsDTOLts { get; set; }
        

        public InvoiceDTO(Invoice invoice)
        {
            IdInvoice = invoice.Id;
            Fecha = invoice.Fecha;
            IdPaymentMethod = invoice.paymentMethod.Id;
            Cliente = invoice.Cliente;
            InvoiceDetailsDTOLts = invoice.invoiceDetailsList
                                        .Select(x => new InvoiceDetailDTO(x)).ToList();
        }
    }
}
