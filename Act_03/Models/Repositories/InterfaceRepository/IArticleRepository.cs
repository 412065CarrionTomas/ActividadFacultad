using Act_01.Domain;
using Act_03.Models.Repositories.Implement;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.RepositoryIndependet
{
    public interface IArticleRepository
    {
        bool GetAllById(List<int> idLts);
        List<Article> GetAll(Expression<Func<Article, bool>> condicion);
        Article? GetByFilter(Expression<Func<Article, bool>> condicion);
        bool Insert(Article Article);
        bool Update(int id, Article Article);
        bool Delete(int id);
    }
}
