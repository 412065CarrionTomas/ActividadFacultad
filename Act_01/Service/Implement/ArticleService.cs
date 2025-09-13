using Act_01.Data;
using Act_01.Domain;
using Actividad_Facultad.Data;
using Actividad_Facultad.Data.Interfaces;
using Actividad_Facultad.Data.Repositories;
using Actividad_Facultad.Service.Interfaces;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Service.Implement
{
    public class ArticleService : IGenericService<Article>
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IGenericRepository<Article> _ArticleRepository;
        private readonly IUnitOfWork _UnitOfWork;
        //INYECCION DE DEPENDENCIAS
        public ArticleService(IGenericRepository<Article> genericRepository,
                                IUnitOfWork unitOfWork)
        {
            _ArticleRepository = genericRepository;
            _UnitOfWork = unitOfWork;
        }

        //LOGICA DE NEGOCIO
        public List<Article> GetAll()
        {
            List<Article> lts = _ArticleRepository.GetAll();
            return lts;
        }
        public Article? GetById(int id)
        {
            return _ArticleRepository.GetById(id);
        }
        public int Delete(int id)
        {
            int result = _ArticleRepository.Delete(id);
            _UnitOfWork.Commit();
            return result;
        }
        public int Save(Article a)
        {
            int result = _ArticleRepository.Save(a);
            _UnitOfWork.Commit();
            return result;
        }


    }
}
