using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    public class PaymentMethod
    {
        public int FormaPagoID { get; set; }
        public string nombreFormaPago { get; set; }

        public override string ToString()
        {
            return $"Forma de pago ID:{FormaPagoID}, Nombre forma de pago: {nombreFormaPago}";
        }
    }
}
