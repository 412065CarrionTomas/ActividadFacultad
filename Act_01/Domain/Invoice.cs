using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    public class Invoice
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public string Cliente { get; set; }

        public List<InvoiceDetail> invoiceDetailsList { get; set; }

        public Invoice()
        {
            invoiceDetailsList = new List<InvoiceDetail>();
        }
    }
}
