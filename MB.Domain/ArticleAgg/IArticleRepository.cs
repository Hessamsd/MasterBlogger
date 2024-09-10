using MB.Application.Contracts.Article;
using System.Dynamic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);

        Article Get(int id);
        void Save();
        
    }
}
