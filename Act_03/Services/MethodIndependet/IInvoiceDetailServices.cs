using Act_01.Domain;
using Act_03.Services.Implement;

namespace Act_03.Services.MethodIndependet
{
    public interface IInvoiceDetailServices
    {
        List<InvoiceDetail> GetAll();
        InvoiceDetail? GetById(int id);
        bool Insert(InvoiceDetail invoiceDetail);
        bool Update(int id, InvoiceDetail invoiceDetail);
        bool Delete(int id);
    }
}
