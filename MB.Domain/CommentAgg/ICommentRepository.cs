using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.Comment.Agg;

namespace MB.Domain.Comment
{
    public interface ICommentRepository : IRepository<int,Commentt>

    {
        List<CommentViewModel> GetList();
    }
}
