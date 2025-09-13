using Act_01.Data;
using Act_01.Data.Utils;
using Act_01.Domain;
using Actividad_Facultad.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Data.Repositories
{
    public class ArticleRepository : IGenericRepository<Article>
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IUnitOfWork _unitOfWork;
        //DI
        public ArticleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Delete(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@articuloID",
                    valor = id
                }
            };

            return _unitOfWork.ExecuteSPNonQuery("sp_Articulo_Delete", parameters);

        }

        public List<Article> GetAll()
        {
            List<Article> article = new List<Article>();
            var dt = _unitOfWork.ExecuteSPQuery("sp_Articulo_Get");
            if (dt == null || dt.Rows.Count == 0)
            {
                return article;
            }
            foreach (DataRow row in dt.Rows)
            {
                Article a = new Article();
                a.ArticuloID = row.GetInt("articuloID");
                a.NombreArticulo = row.GetString("nombreArticulo");
                a.PrecioUnitario = row.GetDecimal("precioUnitario");
                article.Add(a);
            }
            return article;

        }

        public Article? GetById(int id)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@articuloID",
                    valor = id
                }
            };
            var dt = _unitOfWork.ExecuteSPQuery("sp_Articulo_Get", parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                Article a = new Article();
                a.ArticuloID = dt.Rows[0].GetInt("articuloID");
                a.NombreArticulo = dt.Rows[0].GetString("nombreArticulo");
                a.PrecioUnitario = dt.Rows[0].GetDecimal("precioUnitario");
                return a;
            }
            return null;
        }

        public int Save(Article article)
        {
            List<ParameterSP> parameters = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    nombre = "@articuloID",
                    valor = article.ArticuloID
                },
                new ParameterSP()
                {
                    nombre = "@nombreArticulo",
                    valor = article.NombreArticulo
                },
                new ParameterSP()
                {
                    nombre = "@precioUnitario",
                    valor = article.PrecioUnitario
                }
            };
            return _unitOfWork.ExecuteSPWithReturn("sp_articulo_UPSERT", parameters);
        }
    }
}
