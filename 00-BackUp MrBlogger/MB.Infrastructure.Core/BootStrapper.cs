﻿using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MB.Application;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Infrastructure.Query;
using MB.Application.Contracts.Comment;
using MB.Domain.Comment;

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
            services.AddTransient<IArticleValidatorService,ArticleValidatorService>();
            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();






            services.AddDbContext<MasterBloggerContext>(option => option.UseSqlServer(connectionstring));

        }


    }


}
