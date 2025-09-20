using Act_01.Domain;
using Act_03.Controllers;
using Act_03.Models.Repositories.Implement;
using Act_03.Models.Repositories.InterfaceRepository;
using Act_03.Models.Repositories.RepositoryIndependet;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Act_03.Services.Implement
{
    public class ArticleService : IGenericService<Article>
    {
        private readonly IArticleRepository _ArticleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _ArticleRepository = articleRepository;
        }
        public bool Delete(int id)
        {
            return _ArticleRepository.Delete(id);
        }

        public List<Article> GetAll()
        {
            Expression<Func<Article, bool>> condicion = (x => x.Activo == 1);
            var result = _ArticleRepository.GetAll(condicion);
            if (result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public Article GetById(int id)
        {
            Expression<Func<Article, bool>> condicion = (x => x.Activo == 1 && x.Id.Equals(id));
            var result = _ArticleRepository.GetByFilter(condicion);
            if (result == null) { throw new InvalidOperationException(); }
            return result;
        }

        public bool Insert(Article article)
        {
            return _ArticleRepository.Insert(article);
        }
        public bool Update(int id, Article article)
        {
            return _ArticleRepository.Update(id, article);
        }
    }
}
