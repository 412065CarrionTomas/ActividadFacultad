using Act_01.Domain;

namespace Act_03.Services.MethodIndependet
{
    public interface IPaymentMethodService
    {
        List<PaymentMethod> GetAll();
        PaymentMethod GetById(int id);
        bool Insert(PaymentMethod payment);
        bool Update(int id, PaymentMethod paymentMethod);
        bool Delete(int id);
    }
}
