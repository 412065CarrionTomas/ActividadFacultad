using Act_01.Domain;
using Act_03.Models.Context;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.Implement
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly InvoiceContext _InvoiceContext;
        public InvoiceDetailRepository(InvoiceContext invoiceContext)
        {
            _InvoiceContext = invoiceContext;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<InvoiceDetail> GetAll(Expression<Func<InvoiceDetail, bool>> condicion)
        {
            return _InvoiceContext.InvoiceDetails
                .Include(x => x.article)
                .Where(condicion).ToList();
        }

        public InvoiceDetail? GetByFilter(Expression<Func<InvoiceDetail, bool>> condicion)
        {
            throw new NotImplementedException();
        }

        public bool Insert(InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }
    }
}
