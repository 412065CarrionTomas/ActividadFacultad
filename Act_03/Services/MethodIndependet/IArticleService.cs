using Act_01.Domain;

namespace Act_03.Services.MethodIndependet
{
    public interface IArticleService
    {
        List<Article> GetAll();
        Article GetById(int id);
        bool Insert(Article article);
        bool Update(int id, Article article);
        bool Delete(int id);
    }
}
