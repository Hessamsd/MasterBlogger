using MB.Application.Contracts.Comment;
using MB.Domain.Comment.Agg;

namespace MB.Domain.Comment
{
    public interface ICommentRepository
    {
        void CreatAndSave(Commentt entity);

        List<CommentViewModel> GetList();
    }
}
