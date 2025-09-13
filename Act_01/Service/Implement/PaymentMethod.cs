using Act_01.Data;
using Act_01.Domain;
using Actividad_Facultad.Data;
using Actividad_Facultad.Data.Implement;
using Actividad_Facultad.Data.Interfaces;
using Actividad_Facultad.Service.Interfaces;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Service.Implement
{
    public class PaymentMethodService : IGenericService<PaymentMethod>
    {
        //agregar variable clase de la clase 
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<PaymentMethod> _PaymentMethodRepository;
        //inyeccion de la DI
        public PaymentMethodService(IGenericRepository<PaymentMethod> genericRepository,
                                    IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _PaymentMethodRepository = genericRepository;
        }

        //LOGICA NEGOCIO
        public List<PaymentMethod> GetAll()
        {
            List<PaymentMethod> lts = _PaymentMethodRepository.GetAll();
            return lts;
        }
        public PaymentMethod? GetById(int id)
        {
            return _PaymentMethodRepository.GetById(id);
        }
        public int Delete(int id)
        {
            int result = _PaymentMethodRepository.Delete(id);
            _UnitOfWork.Commit();
            return result;
        }
        public int Save(PaymentMethod paymentMethod)
        {
            int result = _PaymentMethodRepository.Save(paymentMethod);
            _UnitOfWork.Commit();
            return result;
        }
    }
}
