using Act_04.Models.Domain;
using Act_4.DTOS.ShipmentDetailDTOs;
using Act_4.DTOS.ShipmentDTOs;
using Act_4.Repositories.ShipmentRepo;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;
using System.Net;

namespace Act_4.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _ShipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _ShipmentRepository = shipmentRepository;
        }

        public bool Delete(int id)
        {
            return _ShipmentRepository.Delete(id);
        }


        public List<ShipmentDTORead>? GetAllByFilter(string? state, string? addrres)
        {
            //crear lista de envios dto
            List<ShipmentDTORead> shipmentDTOReadsLts = new List<ShipmentDTORead>();

            //validad si estado no esta presenete en el filtro
            if (state == null)
            {
                Expression<Func<Shipment, bool>> condicionAddrres = (x => x.Address.Equals(addrres) &&
                                                                    x.State.Equals("Active"));

                //guardar objetos traidos en una lista
                List<Shipment>? shipmentsAddrresLts = _ShipmentRepository.GetAll(condicionAddrres);
                if(shipmentsAddrresLts != null)
                {
                    //mapear los dto y crearlos
                    foreach (Shipment shipment in shipmentsAddrresLts)
                    {
                        var ShipmentDTOs = new ShipmentDTORead(shipment);
                        shipmentDTOReadsLts.Add(ShipmentDTOs);
                    }
                    return shipmentDTOReadsLts;
                }
            }
            if(addrres == null)
            {
                Expression<Func<Shipment, bool>> condicionState = (x => x.State.Equals(state));

                //guardar objetos traidos en una lista
                List<Shipment>? shipmentsStateLts = _ShipmentRepository.GetAll(condicionState);
                if (shipmentsStateLts != null)
                {
                    //mapear los dto y crearlos
                    foreach (Shipment shipment in shipmentsStateLts)
                    {
                        var ShipmentDTOs = new ShipmentDTORead(shipment);
                        shipmentDTOReadsLts.Add(ShipmentDTOs);
                    }
                    return shipmentDTOReadsLts;
                }
            }

            //filtro por dirrecion y estado
            Expression<Func<Shipment, bool>> condicion = (x => x.Address.Equals(addrres) &&
                                                          x.State.Equals(state));

            List<Shipment>? shipmentsFilterLts = _ShipmentRepository.GetAll(condicion);
            if(shipmentsFilterLts != null)
            {
                foreach(Shipment shipment in shipmentsFilterLts)
                {
                    var shipmentsDTOs = new ShipmentDTORead(shipment);
                    shipmentDTOReadsLts.Add(shipmentsDTOs);
                }
                return shipmentDTOReadsLts;
            }
            //devolver null si no cumple nada de lo anterior
            return null;
        }
    }
}
