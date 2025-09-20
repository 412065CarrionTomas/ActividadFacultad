using Act_01.Domain;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.MethodIndependet
{
    public interface IArticleRepository
    {
        List<Article> GetAll(Expression<Func<Article, bool>> condicion);
        Article? GetById(int id, Expression<Func<Article, bool>> condicion);
        bool Insert(Article article);
        bool Update(int id, Article article);
        bool Delete(int id);
    }
}
