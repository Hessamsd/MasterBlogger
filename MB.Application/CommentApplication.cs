using MB.Application.Contracts.Comment;
using MB.Domain.Comment;
using MB.Domain.Comment.Agg;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Commentt(command.Name,
                command.Email, command.Message, command.ArticleId);
            _commentRepository.CreatAndSave(comment);
        }
               

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
    }
}
