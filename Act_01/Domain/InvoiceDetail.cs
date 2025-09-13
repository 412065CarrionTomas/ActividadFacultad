using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    public class InvoiceDetail
    {
        public int nroDetalle { get; set; }
        public int nroFactura { get; set; }
        public Article article { get; set; }
        public int cantidad { get; set; }
    }
}
