using _01_Framework.Domain;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.Comment.Agg;





namespace MB.Domain.ArticleAgg
{
    public class Article : DomainBase<int>
    {

        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public int ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Commentt> Comments { get; private set; }





        protected Article()
        {
        }

        public Article(string title, string shortDescription, string image, string content, int articleCategoryId)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            Comments = new List<Commentt>();

        }

        private static void Validate(string title, int articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();
        }




        public void Edit(string title, string shortDescription, string image, string content, int articleCategoryId)
        {

            Validate(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }


        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
