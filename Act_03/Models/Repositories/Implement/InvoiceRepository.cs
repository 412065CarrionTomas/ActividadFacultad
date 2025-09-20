using Act_01.Domain;
using Act_03.Models.Context;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Act_03.Models.Interface.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext _InvoicesContext;

        public InvoiceRepository(InvoiceContext invoicesContext)
        {
            _InvoicesContext = invoicesContext;
        }
        public List<Invoice> GetAll(Expression<Func<Invoice, bool>> condicion)
        {
            return _InvoicesContext.Invoices
                .Include(x => x.paymentMethod)
                .Include(x => x.invoiceDetailsList)
                    .ThenInclude(x => x.article)
                .Where(condicion).ToList();
        }

        public Invoice? GetByFilter(Expression<Func<Invoice, bool>> condicion)
        {
            return _InvoicesContext.Invoices
                .Include(pm => pm.paymentMethod)
                .Include(x => x.invoiceDetailsList)
                    .ThenInclude(a => a.article)
                .SingleOrDefault(condicion);
        }
        public bool Insert(Invoice invoice)
        {
            _InvoicesContext.Invoices.Add(invoice);
            return _InvoicesContext.SaveChanges() > 0;
        }
        public bool Update(int id, Invoice invoiceUpdate)
        {
            var entityEntry = _InvoicesContext.Invoices.Find(id);
            if(entityEntry == null) { return false; }
            entityEntry.Cliente = invoiceUpdate.Cliente;
            entityEntry.paymentMethod = invoiceUpdate.paymentMethod;
            entityEntry.Fecha = invoiceUpdate.Fecha;
            entityEntry.Activo = invoiceUpdate.Activo;
            _InvoicesContext.Entry(entityEntry).State = EntityState.Modified;
            return _InvoicesContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var invoice = _InvoicesContext.Invoices.Find(id);
            invoice.Activo = 0;
            _InvoicesContext.Entry(invoice).State = EntityState.Modified;
            return _InvoicesContext.SaveChanges() > 0;
        }
        
    }
}
