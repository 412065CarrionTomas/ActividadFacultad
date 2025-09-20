using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetAll(Expression<Func<PaymentMethod, bool>> condicion);
        PaymentMethod? GetById(int id, Expression<Func<PaymentMethod, bool>> condicion);
        bool Insert(PaymentMethod paymentMethod);
        bool Update(int id, PaymentMethod paymentMethod);
        bool Delete(int id);
    }
}
