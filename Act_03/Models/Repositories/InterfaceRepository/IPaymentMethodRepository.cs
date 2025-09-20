using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.InterfaceRepository
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetAll(Expression<Func<PaymentMethod, bool>> condicion);
        PaymentMethod? GetByFilter(Expression<Func<PaymentMethod, bool>> condicion);
        bool Insert(PaymentMethod PaymentMethod);
        bool Update(int id, PaymentMethod PaymentMethod);
        bool Delete(int id);
    }
}
