using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using System.Dynamic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<int,Article>
    {
        List<ArticleViewModel> GetList();

    }
}
