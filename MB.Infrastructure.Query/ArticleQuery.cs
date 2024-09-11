using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {

        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }


        public List<ArticleQueryView> GetArticles()
        {

            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {

                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title,

            }).ToList();

        }

        public ArticleQueryView GetArticle(int id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
                ArticleCategory = x.ArticleCategory.Title,

            }).FirstOrDefault(x => x.Id == id);
        }


    }
}
