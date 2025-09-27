using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Act_04.Models.Domain
{
    public class ShipmentDetail
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; } = new Product() { Id = 0, Name="", Price=0m };
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public string Comentary { get; set; } = "";

        [JsonIgnore]
        public virtual Shipment ShipmentNavigation { get; set; }
    }
}
