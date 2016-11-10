using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Pages.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.Title.Contains(sSearch) || p.CreatedBy.Contains(sSearch) || p.ViewCount.ToString().Contains(sSearch) || p.UpdateDate.ToString().Contains(sSearch));
                }
            }

            var allPages = query;



            IEnumerable<Page> filteredPages = allPages;



            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredPages = filteredPages.OrderByDescending(p => p.Title);
                        break;
                    case 1:
                        filteredPages = filteredPages.OrderByDescending(p => p.CreatedBy);
                        break;
                    case 2:
                        filteredPages = filteredPages.OrderByDescending(c => c.ViewCount);
                        break;
                    case 3:
                        filteredPages = filteredPages.OrderByDescending(c => c.UpdateDate);
                        break;
                    default:
                        filteredPages = filteredPages.OrderByDescending(c => c.Title);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredPages = filteredPages.OrderBy(p => p.Title);
                        break;
                    case 1:
                        filteredPages = filteredPages.OrderBy(p => p.CreatedBy);
                        break;
                    case 2:
                        filteredPages = filteredPages.OrderBy(c => c.ViewCount);
                        break;
                    case 3:
                        filteredPages = filteredPages.OrderBy(c => c.UpdateDate);
                        break;
                    default:
                        filteredPages = filteredPages.OrderBy(c => c.Title);
                        break;
                }
            }
            var displayedPages = filteredPages.Skip(displayStart).Take(displayLength);

            totalRecords = allPages.Count();
            totalDisplayRecords = filteredPages.Count();
            return displayedPages.ToList();
        }
    }

    public interface IPageRepository : IRepository<Page>
    {
        IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}