using Act_04.Models.Domain;

namespace Act_4.DTOS.ShipmentDetailDTOs
{
    public class ShipmentDetailReadDTOs
    {
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public int Quantety { get; set; }
        public string Comentary { get; set; }

        public ShipmentDetailReadDTOs(ShipmentDetail shipment)
        {
            IdDetail = shipment.Id;
            IdProduct = shipment.Product.Id;
            NameProduct = shipment.Product.Name;
            Price = shipment.Product.Price;
            Quantety = shipment.Quantity;
            Comentary = shipment.Comentary;
        }
    }
}
