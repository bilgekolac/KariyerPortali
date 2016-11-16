using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface ICategoryService
    {
        int GetPostCountByPost(int post);
        IEnumerable<Category> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void SaveCategory();
        
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICategoryService Members
        public IEnumerable<Category> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var categories = categoryRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return categories;
        }
        public IEnumerable<Category> GetCategories()
        {
            var categories = categoryRepository.GetAll();
            return categories;
        }
        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }
        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }
        public void DeleteCategory(Category category)
        {
            categoryRepository.Delete(category);
        }
        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
        
        public int GetPostCountByPost(int post)
        {
            return categoryRepository.GetMany(c => c.CategoryId == post).Count();
        }
        #endregion
    }
}
