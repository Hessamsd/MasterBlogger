using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {

        public List<ArticleQueryView> Articles { get; set; }

        private readonly IArticleQuery article;

        public IndexModel(IArticleQuery article)
        {
            this.article = article;
        }

        public void OnGet()
        {
            Articles = article.GetArticles();
        }
    }
}