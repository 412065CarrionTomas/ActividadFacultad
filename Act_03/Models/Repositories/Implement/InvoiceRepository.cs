using Act_01.Domain;
using Act_03.Models.Context;
using Act_03.Models.Interface;
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

        public Invoice? GetById(int id, Expression<Func<Invoice, bool>> condicion)
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
            if(_InvoicesContext.SaveChanges() == 0) { return false; }
            else { return true; }
        }
        public bool Update(int id, Invoice invoiceUpdate)
        {
            var invoice = _InvoicesContext.Invoices.Find(id);
            if(invoice == null) { return false; }
            invoice.Cliente = invoiceUpdate.Cliente;
            invoice.paymentMethod = invoiceUpdate.paymentMethod;
            invoice.Fecha = invoiceUpdate.Fecha;
            invoice.Activo = invoiceUpdate.Activo;
            _InvoicesContext.Entry(invoice).State = EntityState.Modified;
            if(_InvoicesContext.SaveChanges() > 0 ) { return true; }
            else { return false; }
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
