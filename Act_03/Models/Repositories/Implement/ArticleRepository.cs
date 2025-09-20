using Act_01.Domain;
using Act_03.Models.Context;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.RepositoryIndependet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Act_03.Models.Repositories.Implement
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly InvoiceContext _InvoiceContext;
        public ArticleRepository(InvoiceContext invoiceContext)
        {
            _InvoiceContext = invoiceContext;
        }
        public bool Delete(int id)
        {
            var article = _InvoiceContext.Articles.Find(id);
            if(article == null) { return false; }
            article.Activo = 0;
            _InvoiceContext.Entry(article).State = EntityState.Modified;
            return _InvoiceContext.SaveChanges() > 0;
        }

        public List<Article> GetAll(Expression<Func<Article, bool>> condicion)
        {
            return _InvoiceContext.Articles.Where(condicion).ToList();
        }

        public bool GetAllById(List<int> idLts)
        {
            var count = _InvoiceContext.Articles
                .Where(x => idLts.Contains(x.Id))
                .Count();
            return count == idLts.Count();
        }

        public Article? GetByFilter(Expression<Func<Article, bool>> condicion)
        {
            return _InvoiceContext.Articles.SingleOrDefault(condicion);
        }

        public bool Insert(Article article)
        {
            _InvoiceContext.Articles.Add(article);
            return _InvoiceContext.SaveChanges() > 0;
        }

        public bool Update(int id, Article articleUpdate)
        {
            var entityEntry = _InvoiceContext.Articles.Find(id);
            if(entityEntry == null) { return false; }
            entityEntry.PrecioUnitario = articleUpdate.PrecioUnitario;
            entityEntry.Activo = articleUpdate.Activo;
            entityEntry.NombreArticulo = articleUpdate.NombreArticulo;
            _InvoiceContext.Articles.Entry(entityEntry).State = EntityState.Modified;
            return _InvoiceContext.SaveChanges() > 0;
        }
    }
}
