using Act_04.Models.Context;
using Act_04.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Act_4.Repositories.ShipmentRepo
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ShipmentContext _ShipmentContext;
        public ShipmentRepository(ShipmentContext shipmentContext)
        {
            _ShipmentContext = shipmentContext;
        }
        public bool Delete(int id)
        {
            var keyFind = _ShipmentContext.Shipments.Find(id);
            if(keyFind == null) { return false; }
            keyFind.State = "Canceled";
            return _ShipmentContext.SaveChanges() > 0;
        }

        public List<Shipment>? GetAll(Expression<Func<Shipment,bool>> condicion)
        {
            return _ShipmentContext.Shipments
                .Include(x => x.ShipmentDetailsLts)
                    .ThenInclude(x => x.Product)
                .Where(condicion).ToList();
        }
    }
}
