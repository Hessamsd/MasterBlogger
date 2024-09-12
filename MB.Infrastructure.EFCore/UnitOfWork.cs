using _01_Framework;

namespace MB.Infrastructure.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MasterBloggerContext _context;

        public UnitOfWork(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            
            _context.Database.CommitTransaction();
            _context.SaveChanges();

        }


        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
