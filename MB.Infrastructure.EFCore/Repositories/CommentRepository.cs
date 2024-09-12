using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.Comment;
using MB.Domain.Comment.Agg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<int, Commentt>, ICommentRepository
    {
        private readonly MasterBloggerContext _Context;

        public CommentRepository(MasterBloggerContext masterBloggerContext) : base(masterBloggerContext)
        {
            _Context = masterBloggerContext;

        }

        public List<CommentViewModel> GetList()
        {

            return _Context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title,

            }).ToList();
        }
    }
}
