using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.InterfaceRepository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll(Expression<Func<Invoice, bool>> condicion);
        Invoice? GetByFilter(Expression<Func<Invoice, bool>> condicion);
        bool Insert(Invoice Invoice);
        bool Update(int id, Invoice Invoice);
        bool Delete(int id);
    }
}
