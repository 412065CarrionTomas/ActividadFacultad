using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Act_03.Models.Interface;
using System.Linq.Expressions;

namespace Act_03.Services.Implement
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _InvoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _InvoiceRepository = invoiceRepository;
        }
        //INVOICES DTO METODOS
        public List<InvoiceDTO> GetAllDTO()
        {
            Expression<Func<Invoice, bool>> condicion = (x => x.Activo == 1);
            List<Invoice> invoicesLts = _InvoiceRepository.GetAll(condicion);
            List<InvoiceDTO> invoiceDTOLts = new List<InvoiceDTO>();
            foreach(Invoice i in invoicesLts)
            {
                var objDTO = new InvoiceDTO(i);
                invoiceDTOLts.Add(objDTO);
            }
            return invoiceDTOLts;
        }



        /// <summary>
        /// INVOICES METODOS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            return _InvoiceRepository.GetById(id, condicion);
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
