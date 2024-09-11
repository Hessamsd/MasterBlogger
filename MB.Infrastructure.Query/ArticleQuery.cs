using MB.Domain.Comment.agg;
using MB.Domain.Comment.Agg;
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

            return _context.Articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                                .Select(x =>
                                new ArticleQueryView
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    ArticleCategory = x.ArticleCategory.Title,
                                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                                    Image = x.Image,
                                    ShortDescription = x.ShortDescription,
                                    CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)

                                }).ToList();
        }

        public ArticleQueryView GetArticle(int id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x =>
                new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirmed))

            }).FirstOrDefault(x => x.Id == id);
        }


        private static List<CommentQueryView> MapComments(IEnumerable<Commentt> comments)
        {
            return comments.Select(comment => new CommentQueryView
            {
                Name = comment.Name,
                CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                Message = comment.Message
            }).ToList();
        }



        //private static List<CommentQueryView> MapComments(IEnumerable<Commentt> comments)
        //{
        //    var result = new List<CommentQueryView>();  
        //    foreach(var comment in comments)
        //    {
        //        result.Add(new CommentQueryView
        //        {
        //            Name = comment.Name, 
        //            CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
        //            Message = comment.Message,

        //        });
        //    }
        //    return result;  
        //}
    }
}
