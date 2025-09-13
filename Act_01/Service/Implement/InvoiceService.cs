using Act_01.Data;
using Act_01.Domain;
using Actividad_Facultad.Data;
using Actividad_Facultad.Data.Interfaces;
using Actividad_Facultad.Data.Repositories;
using Actividad_Facultad.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Service.Implement
{
    public class InvoiceServices : IGenericService<Invoice>
    {
        //agregar variable de clase de la clase 
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Invoice> _InvoiceRepository;
        //Inyeccion DI
        public InvoiceServices(IGenericRepository<Invoice> genericRepository,
                                IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _InvoiceRepository = genericRepository;
        }

        public int Delete(int id)
        {
            int result = _InvoiceRepository.Delete(id);
            _UnitOfWork.Commit();
            return result;
        }

        public List<Invoice> GetAll()
        {
            return _InvoiceRepository.GetAll();
        }

        public Invoice? GetById(int id)
        {
            return _InvoiceRepository.GetById(id);
        }

        public int Save(Invoice invoice)
        {
            try
            {
                int result = _InvoiceRepository.Save(invoice);
                _UnitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _UnitOfWork.Rollback();
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}
