using Act_01.Data;
using Act_01.Domain;
using Actividad_Facultad.Data;
using Actividad_Facultad.Data.Implement;
using Actividad_Facultad.Data.Interfaces;
using Actividad_Facultad.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Service.Implement
{
    public class InvoiceDetailService : IGenericService<InvoiceDetail>
    {
        //agregar variable de clase de la clase 
        private readonly IGenericRepository<InvoiceDetail> _InvoiceDetailRepository;
        private readonly IUnitOfWork _UnitOfWork;
        //Inyeccion DI
        public InvoiceDetailService(IGenericRepository<InvoiceDetail> genericRepository,
                                    IUnitOfWork unitOfWork)
        {
            _InvoiceDetailRepository = genericRepository;
            _UnitOfWork = unitOfWork;
        }

        //LOGICA NEGOCIO
        public List<InvoiceDetail> GetAll()
        {
            return _InvoiceDetailRepository.GetAll();
        }
        public InvoiceDetail? GetById(int id)
        {
            return _InvoiceDetailRepository.GetById(id);
        }
        public int Delete(int id)
        {
            int result = _InvoiceDetailRepository.Delete(id);
            _UnitOfWork.Commit();
            return result;
        }
        public int Save(InvoiceDetail invoiceDetail)
        {
            int result = _InvoiceDetailRepository.Save(invoiceDetail);
            _UnitOfWork.Commit();
            return result;
        }
    }
}
