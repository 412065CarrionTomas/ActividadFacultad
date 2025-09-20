
using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;
using Act_03.Models.Repositories.RepositoryIndependet;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Linq.Expressions;

namespace Act_03.Services.ImplementDTOs
{
    public class InvoiceDTOService : IGenericDTOService<InvoiceDTO>
    {
        private readonly IInvoiceRepository _InvoiceRepository;
        private readonly IPaymentMethodRepository _PaymentMethod;
        private readonly IArticleRepository _ArticleRepository;

        public InvoiceDTOService(IInvoiceRepository genericReposotiry,
                                    IPaymentMethodRepository paymentMethod,
                                     IArticleRepository articleRepository)
        {
            _InvoiceRepository = genericReposotiry;
            _PaymentMethod = paymentMethod;
            _ArticleRepository = articleRepository;
        }
        public bool DeleteDTO(int id)
        {
            return _InvoiceRepository.Delete(id);
        }

        public List<InvoiceDTO> GetAllDTO()
        {
            Expression<Func<Invoice, bool>> condicion = x => x.Activo == 1;
            List<Invoice> invoicesLts = _InvoiceRepository.GetAll(condicion);
            if (invoicesLts == null) { throw new InvalidOperationException(); }
            List<InvoiceDTO> invoiceDTOLts = new List<InvoiceDTO>();
            foreach (Invoice i in invoicesLts)
            {
                var objDTO = new InvoiceDTO(i);
                invoiceDTOLts.Add(objDTO);
            }
            return invoiceDTOLts;
        }

        public InvoiceDTO? GetDTOById(int id)
        {
            Expression<Func<Invoice, bool>> condicion = x => x.Activo == 1 && x.Id.Equals(id);
            Invoice? invoice = _InvoiceRepository.GetByFilter(condicion);
            if (invoice == null) { throw new InvalidOperationException(); }
            InvoiceDTO invoiceDTO = new InvoiceDTO(invoice);
            return invoiceDTO;
        }

        public bool InsertDTO(InvoiceDTO tentity)
        {
            
            Invoice invoiceInsert = new Invoice();

            var articlesInDTO = tentity.InvoiceDetailsDTOLts.Select(x => x.IdArticulo).ToList();
            if(_ArticleRepository.GetAllById(articlesInDTO) == false) { throw new InvalidOperationException(); }

            Expression<Func<PaymentMethod, bool>> condicionPM = x => x.Activo == 1 && x.Id.Equals(tentity.IdPaymentMethod);
            if(_PaymentMethod.GetByFilter(condicionPM) == null) { throw new InvalidOperationException(); }

            invoiceInsert.Activo = 1;
            invoiceInsert.Fecha = tentity.Fecha;
            invoiceInsert.paymentMethod = new PaymentMethod() { Id = tentity.IdPaymentMethod };
            invoiceInsert.Cliente = tentity.Cliente;
            invoiceInsert.invoiceDetailsList =
                tentity.InvoiceDetailsDTOLts.Select(dto => new InvoiceDetail
                {
                    article = new Article() { Id = dto.IdArticulo},
                    cantidad = dto.Cantidad
                }).ToList();
           return _InvoiceRepository.Insert(invoiceInsert);
        }

        public bool UpdateDTO(int id, InvoiceDTO tentity)
        {
            Expression<Func<Invoice, bool>> condicion = x => x.Activo == 1 && x.Id.Equals(id);
            Invoice? invoiceUpdate = _InvoiceRepository.GetByFilter(condicion);

            if (invoiceUpdate == null) { throw new InvalidOperationException(); }

            var articlesInDTO = tentity.InvoiceDetailsDTOLts.Select(x => x.IdArticulo).ToList();
            if(_ArticleRepository.GetAllById(articlesInDTO) == false) { throw new InvalidOperationException(); }

            Expression<Func<PaymentMethod, bool>> condicionPM = (x => x.Id.Equals(tentity.IdPaymentMethod) && x.Activo == 1);
            if(_PaymentMethod.GetByFilter(condicionPM) == null) { throw new InvalidOperationException(); }

            invoiceUpdate.Activo = 1;
            invoiceUpdate.Fecha = tentity.Fecha;
            invoiceUpdate.paymentMethod = new PaymentMethod() { Id = tentity.IdPaymentMethod };
            invoiceUpdate.Cliente = tentity.Cliente;
            invoiceUpdate.invoiceDetailsList =
                tentity.InvoiceDetailsDTOLts.Select(dto => new InvoiceDetail()
                {
                    article = new Article() { Id = dto.IdArticulo },
                    cantidad = dto.Cantidad
                }).ToList();
            return _InvoiceRepository.Update(id, invoiceUpdate);
        }
    }
}
