using Act_04.Models.Domain;
using Act_4.DTOS.ShipmentDetailDTOs;

namespace Act_4.DTOS.ShipmentDTOs
{
    public class ShipmentDTORead
    {
        public int Id { get; set; }
        public int DniClient { get; set; }
        public string Addrress { get; set; }
        public string State { get; set; }
        public List<ShipmentDetailReadDTOs> DetailsDTOsLts { get; set; }
        public ShipmentDTORead(Shipment shipment)
        {
            Id = shipment.Id;
            DniClient = shipment.DniClient;
            Addrress = shipment.Address;
            State = shipment.State;
            DetailsDTOsLts = shipment.ShipmentDetailsLts.Select(x => new ShipmentDetailReadDTOs(x)).ToList();
        }
    }
}
