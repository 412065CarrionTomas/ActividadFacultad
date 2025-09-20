using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.InterfaceRepository
{
    public interface IInvoiceDetailRepository
    {
        List<InvoiceDetail> GetAll(Expression<Func<InvoiceDetail, bool>> condicion);
        InvoiceDetail? GetByFilter(Expression<Func<InvoiceDetail, bool>> condicion);
        bool Insert(InvoiceDetail InvoiceDetail);
        bool Update(int id, InvoiceDetail InvoiceDetail);
        bool Delete(int id);
    }
}
