using Act_01.Domain;
using Act_03.Models.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.InterfaceRepository;

namespace Act_03.Models.Repositories.Implement
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly InvoiceContext _InvoiceContext;
        public PaymentMethodRepository(InvoiceContext invoiceContext)
        {
            _InvoiceContext = invoiceContext;
        }
        public bool Delete(int id)
        {
            var paymentMethod = _InvoiceContext.PaymentMethods.Find(id);
            paymentMethod.Activo = 0;
            _InvoiceContext.PaymentMethods.Entry(paymentMethod).State = EntityState.Modified;
            return _InvoiceContext.SaveChanges() > 0;
        }

        public List<PaymentMethod> GetAll(Expression<Func<PaymentMethod, bool>> condicion)
        {
            return _InvoiceContext.PaymentMethods.Where(condicion).ToList();
        }

        public PaymentMethod? GetByFilter (Expression<Func<PaymentMethod, bool>> condicion)
        {
            return _InvoiceContext.PaymentMethods.Single(condicion);
        }

        public bool Insert(PaymentMethod paymentMethod)
        {
            _InvoiceContext.PaymentMethods.Add(paymentMethod);
            return _InvoiceContext.SaveChanges() > 0;
        }

        public bool Update(int id, PaymentMethod paymentMethodUpdate)
        {
            var entityEntry = _InvoiceContext.PaymentMethods.Find(id);
            entityEntry.nombreFormaPago = paymentMethodUpdate.nombreFormaPago;
            entityEntry.Activo = paymentMethodUpdate.Activo;
            _InvoiceContext.PaymentMethods.Entry(entityEntry).State = EntityState.Modified;
            return _InvoiceContext.SaveChanges() > 0;
        }
    }
}
