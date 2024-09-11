using MB.Domain.Comment;
using MB.Domain.Comment.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
       private readonly MasterBloggerContext _Context;

        public CommentRepository(MasterBloggerContext masterBloggerContext)
        {
            _Context = masterBloggerContext;
                        
        }

        public void CreatAndSave(Commentt entity)
        {
            _Context.Comments.Add(entity);
            _Context.SaveChanges();
        }
    }
}
