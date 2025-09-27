using Act_04.Models.Domain;
using System.Linq.Expressions;

namespace Act_4.Repositories.ShipmentRepo
{
    public interface IShipmentRepository
    {
        List<Shipment>? GetAll(Expression<Func<Shipment, bool>> condicion);
        bool Delete(int id);
    }
}
