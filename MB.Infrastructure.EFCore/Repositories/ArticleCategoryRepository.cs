using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {

        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.articleCategories.OrderByDescending(x => x.Id).ToList();

        }
        public void Create(ArticleCategory entity)
        {
            _context.articleCategories.Add(entity);
            Save();
        }

        public ArticleCategory Get(int id)
        {
            return _context.articleCategories.FirstOrDefault(x => x.Id == id);
           
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.articleCategories.Any(x => x.Title == title);
        }
    }

}
