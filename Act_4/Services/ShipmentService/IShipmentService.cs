using Act_04.Models.Domain;
using Act_4.DTOS.ShipmentDTOs;

namespace Act_4.Services.ShipmentService
{
    public interface IShipmentService
    {

        List<ShipmentDTORead>? GetAllByFilter(string? state =null, string? addrres=null);
        bool Delete(int id);
    }
}
