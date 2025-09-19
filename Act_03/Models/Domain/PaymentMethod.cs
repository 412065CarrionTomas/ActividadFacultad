using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Domain
{
    [Table("PaymentsMethods")]
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Required]
        public string nombreFormaPago { get; set; } = string.Empty;
        [Required]
        public int Activo { get; set; } = 0;

    }
}
