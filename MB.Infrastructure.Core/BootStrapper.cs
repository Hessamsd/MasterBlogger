using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MB.Application;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.Core
{
    public class BootStrapper
    {


        public static void Config(IServiceCollection services, string? connectionstring)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();



            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();



            services.AddDbContext<MasterBloggerContext>(option => option.UseSqlServer(connectionstring));

        }


    }


}
