using Act_01.Domain;

namespace Act_03.Models.Domain.DTOs
{
    public class InvoiceDetailDTO
    {
        public int? IdInvoiceDetail { get; set; }
        public int IdArticulo { get; set; }
        public string? NombreArticulo { get; set; }
        public decimal? PrecioArticulo { get; set; }
        public int Cantidad { get; set; }

        public InvoiceDetailDTO(InvoiceDetail invoiceDetail)
        {
            IdInvoiceDetail = invoiceDetail.Id;
            IdArticulo = invoiceDetail.article.Id;
            NombreArticulo = invoiceDetail.article.NombreArticulo;
            PrecioArticulo = invoiceDetail.article.PrecioUnitario;
            Cantidad = invoiceDetail.cantidad;
        }
        
    }
}
