using System.ComponentModel.DataAnnotations;

namespace Act_04.Models.Domain
{
    public class Shipment
    {

        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public int DniClient { get; set; } = 0;
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string SecretWord { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = "";

        public ICollection<ShipmentDetail> ShipmentDetailsLts { get; set; } = new List<ShipmentDetail>() { new ShipmentDetail()
                                                                                                {
                                                                                                    Product =new Product()
                                                                                                    {
                                                                                                        Id=0,
                                                                                                        Name="",
                                                                                                        Price=0m
                                                                                                    },
                                                                                                    Comentary ="",
                                                                                                    Quantity=0
                                                                                                } };

        public Shipment()
        {
            new List<ShipmentDetail>();
        }
    }
}
