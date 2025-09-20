using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.MethodIndependet
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll(Expression<Func<Invoice, bool>> condicion);
        Invoice? GetById(int id, Expression<Func<Invoice, bool>> condicion);
        bool Insert(Invoice invoice);
        bool Update(int id, Invoice invoice);
        bool Delete(int id);
    }
}
