using Act_01.Data;
using Act_01.Data.Utils;
using Act_01.Domain;
using Actividad_Facultad.Data.Implement;
using Actividad_Facultad.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Data.Repositories
{
    public class InvoiceRepository : IGenericRepository<Invoice>
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private IUnitOfWork _unitOfWork;
        //DI
        public InvoiceRepository(IUnitOfWork uof)
        {
            _unitOfWork = uof;
        }

        public int Delete(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@nroFactura",
                    valor = id
                }
            };
            return _unitOfWork.ExecuteSPNonQuery("sp_Factura_Delete", parameters);

        }

        public List<Invoice> GetAll()
        {
            List<Invoice> invoicesLts = new List<Invoice>();
            var dt = _unitOfWork.ExecuteSPQuery("sp_Factura_Get");
            if (dt == null || dt.Rows.Count == 0)
            {
                return invoicesLts;
            }
            foreach (DataRow row in dt.Rows)
            {
                int nroFactura = row.GetInt("nroFactura");
                Invoice? invoice = invoicesLts.FirstOrDefault(inv => inv.NroFactura == nroFactura);
                if (invoice == null)
                {
                    invoice = new Invoice
                    {
                        NroFactura = nroFactura,
                        Cliente = row.GetString("cliente"),
                        Fecha = row.GetDateTime("fecha"),
                        paymentMethod = new PaymentMethod
                        {
                            FormaPagoID = row.GetInt("formaPagoID"),
                            nombreFormaPago = row.GetString("nombreFormaPago")
                        },
                        invoiceDetailsList = new List<InvoiceDetail>()
                    };
                    invoicesLts.Add(invoice);
                }

                var iDetail = new InvoiceDetail
                {
                    nroDetalle = row.GetInt("nroDetalle"),
                    nroFactura = nroFactura,
                    article = new Article
                    {
                        ArticuloID = row.GetInt("articuloID"),
                        NombreArticulo = row.GetString("nombreArticulo"),
                        PrecioUnitario = row.GetDecimal("precioUnitario")
                    },
                    cantidad = row.GetInt("cantidad")
                };
                invoice.invoiceDetailsList.Add(iDetail);
            }
            return invoicesLts;
        }

        public Invoice? GetById(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@nroFactura",
                    valor = id
                }
            };
            var dt = _unitOfWork.ExecuteSPQuery("sp_Factura_Get", parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                var firstRow = dt.Rows[0];
                var invoice = new Invoice
                {
                    NroFactura = firstRow.GetInt("nroFactura"),
                    Cliente = firstRow.GetString("cliente"),
                    Fecha = firstRow.GetDateTime("fecha"),
                    paymentMethod = new PaymentMethod
                    {
                        FormaPagoID = firstRow.GetInt("formaPagoID"),
                        nombreFormaPago = firstRow.GetString("nombreFormaPago")
                    },
                    invoiceDetailsList = new List<InvoiceDetail>()
                };

                // Agrega todos los detalles
                foreach (DataRow row in dt.Rows)
                {
                    var invoiceDetail = new InvoiceDetail
                    {
                        nroDetalle = row.GetInt("nroDetalle"),
                        nroFactura = row.GetInt("nroFactura"),
                        article = new Article
                        {
                            ArticuloID = row.GetInt("articuloID"),
                            NombreArticulo = row.GetString("nombreArticulo"),
                            PrecioUnitario = row.GetDecimal("precioUnitario")
                        },
                        cantidad = row.GetInt("cantidad")
                    };
                    invoice.invoiceDetailsList.Add(invoiceDetail);
                }
                return invoice;
            }
            return null;
        }
        public int Save(Invoice invoice)
        {
            int idFactura = -1;
            int resultOk = -1;
            try
            {
                List<ParameterSP> paramInvoice = new List<ParameterSP>()
                {
                    new ParameterSP()
                    {
                        nombre = "@formaPagoID",
                        valor = invoice.paymentMethod.FormaPagoID
                    },
                    new ParameterSP()
                    {
                        nombre = "@cliente",
                        valor = invoice.Cliente
                    }
                };
                idFactura = _unitOfWork.SaveChangesWhitOutput("sp_INSERTAR_MAESTRO", "@nroFactura", paramInvoice);

                foreach (var invoiceDetail in invoice.invoiceDetailsList)
                {
                    List<ParameterSP> paramDetails = new List<ParameterSP>()
                    {
                        new ParameterSP()
                        {
                            nombre = "@nroFactura",
                            valor = idFactura
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
                    resultOk = _unitOfWork.SaveChanges("sp_INSERTAR_ALUMNO", paramDetails);
                }

                return idFactura;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
