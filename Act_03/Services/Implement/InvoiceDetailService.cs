using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;
using System.Linq.Expressions;

namespace Act_03.Services.Implement
{
    public class InvoiceDetailService : IGenericService<InvoiceDetail>
    {
        private readonly IInvoiceDetailRepository _InvoiceDetailRepository;
        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _InvoiceDetailRepository = invoiceDetailRepository;
        }

        ///METODOS
        public bool Delete(int id)
        {
            return _InvoiceDetailRepository.Delete(id);
        }

        public List<InvoiceDetail> GetAll()
        {
            Expression<Func<InvoiceDetail, bool>> condicion = (x => x.Activo == 1);
            var result = _InvoiceDetailRepository.GetAll(condicion);
            if (result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public InvoiceDetail? GetById(int id)
        {
            Expression<Func<InvoiceDetail, bool>> condicion = (x => x.Activo == 1 && x.Id.Equals(id));
            var result = _InvoiceDetailRepository.GetByFilter(condicion);
            if (result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public bool Insert(InvoiceDetail invoiceDetail)
        {
            return _InvoiceDetailRepository.Insert(invoiceDetail);
        }

        public bool Update(int id, InvoiceDetail invoiceDetail)
        {
            return _InvoiceDetailRepository.Update(id, invoiceDetail);
        }
    }
}
