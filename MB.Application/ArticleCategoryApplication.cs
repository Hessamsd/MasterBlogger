using _01_Framework;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System.Globalization;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;

        }


        public List<ArticleCategoryViewModel> List()
        {

            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return result;


            //var articleCategories = _articleCategoryRepository.GetAll();
            //return articleCategories.Select(articleCategory => new ArticleCategoryViewModel
            //{
            //    Id = articleCategory.Id,
            //    Title = articleCategory.Title,
            //    IsDeleted = articleCategory.IsDeleted,
            //    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
            //}).OrderDescending().ToList();
        }


        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articeleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articeleCategory);
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();

        }

        public RenameArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(int id)
        {
            _unitOfWork.BeginTran();
            var articelCategory = _articleCategoryRepository.Get(id);
            articelCategory.Remove();
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }

        public void Activate(int id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            //_articleCategoryRepository.Save();
            _unitOfWork.CommitTran();
        }
    }
}
