using Act_01.Domain;
using Act_03.Models.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Act_03.Services.Implement
{
    public class PaymentMethodService : IGenericService<PaymentMethod>
    {
        private readonly IPaymentMethodRepository _PaymentMethodRepository;
        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _PaymentMethodRepository = paymentMethodRepository;
        }
        public bool Delete(int id)
        {
            return _PaymentMethodRepository.Delete(id);
        }

        public List<PaymentMethod> GetAll()
        {
            Expression<Func<PaymentMethod, bool>> condicion = (x => x.Activo == 1);
            var result = _PaymentMethodRepository.GetAll(condicion);
            if(result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public PaymentMethod GetById(int id)
        {
            Expression<Func<PaymentMethod, bool>> condicion = (x => x.Activo == 1 && x.Id.Equals(id));
            var result = _PaymentMethodRepository.GetByFilter(condicion);
            if (result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public bool Insert(PaymentMethod payment)
        {
            return _PaymentMethodRepository.Insert(payment);
        }

        public bool Update(int id, PaymentMethod paymentMethod)
        {
            return _PaymentMethodRepository.Update(id, paymentMethod);
        }
    }
}
