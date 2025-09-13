using Act_01.Data;
using Act_01.Data.Utils;
using Act_01.Domain;
using Actividad_Facultad.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Quic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Data.Implement
{
    public class InvoiceDetailRepository : IGenericRepository<InvoiceDetail>
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IUnitOfWork _unitOfWork;

        //CONSTRUCTOR DI
        public InvoiceDetailRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Delete(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@nroDetalle",
                    valor = id
                }
            };
            return _unitOfWork.ExecuteSPNonQuery("sp_DetalleFactura_Delete", parameters);

        }

        public List<InvoiceDetail> GetAll()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();
            var dt = _unitOfWork.ExecuteSPQuery("sp_DetalleFactura_Get");
            if (dt == null || dt.Rows.Count == 0)
            {
                return invoiceDetails;
            }
            foreach (DataRow row in dt.Rows)
            {
                InvoiceDetail i = new InvoiceDetail()
                {
                    nroDetalle = row.GetInt("nroDetalle"),
                    nroFactura = row.GetInt("nroFactura"),
                    article = new Article()
                    {
                        ArticuloID = row.GetInt("articuloID")
                    },
                    cantidad = row.GetInt("cantidad")
                };
                invoiceDetails.Add(i);
            }
            return invoiceDetails;
        }

        public InvoiceDetail? GetById(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@nroDetalle",
                    valor = id
                }
            };
            var dt = _unitOfWork.ExecuteSPQuery("sp_DetalleFactura_Get", parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    nroDetalle = dt.Rows[0].GetInt("nroDetalle"),
                    nroFactura = dt.Rows[0].GetInt("nroFactura"),
                    article = new Article()
                    {
                        ArticuloID = dt.Rows[0].GetInt("articuloID")
                    },
                    cantidad = dt.Rows[0].GetInt("cantidad")
                };
                return invoiceDetail;
            }
            return null;
        }

        public int Save(InvoiceDetail invoiceDetail)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@nroDetalle",
                    valor = invoiceDetail.nroDetalle
                },
                new ParameterSP()
                {
                    nombre = "@nroFactura",
                    valor = invoiceDetail.nroFactura
                },
                new ParameterSP()
                {
                    nombre = "@articuloID",
                    valor = invoiceDetail.article.ArticuloID
                },
                new ParameterSP()
                {
                    nombre = "@cantidad",
                    valor = invoiceDetail.cantidad
                }
            };
            return _unitOfWork.ExecuteSPWithReturn("sp_DetalleFactura_UPSERT", parameters);
        }
    }
}
