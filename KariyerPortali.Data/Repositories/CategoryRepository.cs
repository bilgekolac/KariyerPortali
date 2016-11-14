using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Category> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');
            var query = this.DbContext.Categories.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.CategoryId.ToString().Contains(sSearch) || c.CategoryName.Contains(sSearch) || c.Slug.Contains(sSearch) || c.ParentName.Contains(sSearch) || c.Description.Contains(sSearch) || c.Quantity.ToString().Contains(sSearch) );
                }
            }
            var allCategories = query;
            IEnumerable<Category> filteredCategories = allCategories;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCategories = filteredCategories.OrderBy(c => c.CategoryId);
                        break;
                    case 2:
                        filteredCategories = filteredCategories.OrderBy(c => c.CategoryName);
                        break;
                    case 3:
                        filteredCategories = filteredCategories.OrderBy(c => c.Slug);
                        break;
                    case 4:
                        filteredCategories = filteredCategories.OrderBy(c => c.Description);
                        break;
                    default:
                        filteredCategories = filteredCategories.OrderBy(c => c.CategoryId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.CategoryId);
                        break;
                    case 2:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.CategoryName);
                        break;
                    case 3:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Slug);
                        break;
                    case 4:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.Description);
                        break;
                    default:
                        filteredCategories = filteredCategories.OrderByDescending(c => c.CategoryId);
                        break;
                }

            }
            var displayedCategories = filteredCategories.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedCategories = displayedCategories.Take(displayLength);
            }
            totalRecords = allCategories.Count();
            totalDisplayRecords = filteredCategories.Count();
            return displayedCategories.ToList();
        }

    }
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}
