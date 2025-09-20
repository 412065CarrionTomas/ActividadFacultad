using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;
using System.Linq.Expressions;

namespace Act_03.Services.Implement
{
    public class InvoiceService : IGenericService<Invoice>
    {
        private readonly IInvoiceRepository _InvoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _InvoiceRepository = invoiceRepository;
        }
        //INVOICE METODOS
        public bool Delete(int id)
        {
            return _InvoiceRepository.Delete(id);
        }

        public List<Invoice> GetAll()
        {
            Expression<Func<Invoice,bool>> condicion  = (x => x.Activo == 1);
            return _InvoiceRepository.GetAll(condicion);
        }

        public Invoice? GetById(int id)
        {
            Expression<Func<Invoice, bool>> condicion = (x => x.Activo == 1 && x.Id.Equals(id));
            return _InvoiceRepository.GetByFilter(condicion);
        }

        public bool Insert(Invoice invoice)
        {
            return _InvoiceRepository.Insert(invoice);
        }
        public bool Update(int id, Invoice invoiceUpdate)
        {
            return _InvoiceRepository.Update(id, invoiceUpdate);
        }
    }
}
