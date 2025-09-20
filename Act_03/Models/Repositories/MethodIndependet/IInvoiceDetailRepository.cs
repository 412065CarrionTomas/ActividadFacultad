using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.MethodIndependet
{
    public interface IInvoiceDetailRepository
    {
        List<Article> GetAll(Expression<Func<Article, bool>> condicion);
        Article? GetById(int id, Expression<Func<Article, bool>> condicion);
        bool Insert(Article invoice);
        bool Update(int id, Article invoiceDetail);
        bool Delete(int id);
    }
}
