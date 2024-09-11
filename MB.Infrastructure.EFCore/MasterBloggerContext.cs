using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.Comment.Agg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class MasterBloggerContext : DbContext
    {

        public DbSet<ArticleCategory> articleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }    
        public DbSet<Commentt> Comments { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 

            //modelBuilder.ApplyConfiguration(new CommentMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
