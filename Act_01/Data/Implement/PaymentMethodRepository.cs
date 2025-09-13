using Act_01.Data;
using Act_01.Data.Utils;
using Act_01.Domain;
using Actividad_Facultad.Data.Interfaces;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Data.Implement
{
    public class PaymentMethodRepository : IGenericRepository<PaymentMethod>
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private IUnitOfWork _unitOfWork;
        //DI
        public PaymentMethodRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Delete(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@formaPagoID",
                    valor = id
                }
            };
            return _unitOfWork.ExecuteSPNonQuery("sp_FormaPago_Delete", parameters);

        }

        public List<PaymentMethod> GetAll()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            var dt = _unitOfWork.ExecuteSPQuery("sp_FormaPago_Get");
            if (dt == null || dt.Rows.Count == 0)
            {
                return paymentMethods;
            }
            foreach (DataRow row in dt.Rows)
            {
                PaymentMethod pm = new PaymentMethod()
                {
                    FormaPagoID = row.GetInt("formaPagoID"),
                    nombreFormaPago = row.GetString("nombreFormaPago")
                };
                paymentMethods.Add(pm);
            }
            return paymentMethods;
        }

        public PaymentMethod? GetById(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@formaPagoID",
                    valor = id
                }
            };
            var dt = _unitOfWork.ExecuteSPQuery("sp_FormaPago_Get", parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                PaymentMethod pm = new PaymentMethod();
                pm.FormaPagoID = dt.Rows[0].GetInt("formaPagoID");
                pm.nombreFormaPago = dt.Rows[0].GetString("nombreFormaPago");
                return pm;
            }
            return null;
        }

        public int Save(PaymentMethod paymentMethod)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@formaPagoID",
                    valor = paymentMethod.FormaPagoID
                },
                new ParameterSP()
                {
                    nombre = "@nombreFormaPago",
                    valor = paymentMethod.nombreFormaPago
                }
            };
            return _unitOfWork.ExecuteSPWithReturn("sp_formaPago_UPSERT", parameters);
        }
    }
}