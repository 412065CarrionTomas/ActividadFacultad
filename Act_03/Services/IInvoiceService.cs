using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Microsoft.AspNetCore.Components.Web;
using System.Linq.Expressions;

namespace Act_03.Services
{
    public interface IInvoiceService
    {
        List<InvoiceDTO> GetAllDTO();
        List<Invoice> GetAll();
        Invoice? GetById(int id);
        bool Insert(Invoice invoice);
        bool Update(int id, Invoice invoiceUpdate);
        bool Delete(int id);
    }
}
