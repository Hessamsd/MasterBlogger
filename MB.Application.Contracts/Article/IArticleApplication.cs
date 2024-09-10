namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();

        void Create(CreateArticle command);

        void Edit(EditeArticle command);

        EditeArticle Get(int id);

        void Remove(int id);
        void Activate(int id);
       
    }
}
