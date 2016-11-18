using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class LinkRepository : RepositoryBase<Link>, ILinkRepository
    {
        public LinkRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');
            var query = this.DbContext.Links.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.LinkId.ToString().Contains(sSearch) || c.LinkName.Contains(sSearch) || c.Url.Contains(sSearch) || c.Visible.ToString().Contains(sSearch));
                }
            }
            var allLinks = query;
            IEnumerable<Link> filteredLinks = allLinks;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLinks = filteredLinks.OrderBy(l => l.LinkId);
                        break;
                    case 2:
                        filteredLinks = filteredLinks.OrderBy(l => l.LinkName);
                        break;
                    case 3:
                        filteredLinks = filteredLinks.OrderBy(l => l.Url);
                        break;
                    case 4:
                        filteredLinks = filteredLinks.OrderBy(l => l.Visible);
                        break;
                    default:
                        filteredLinks = filteredLinks.OrderBy(l => l.LinkId);
                        break;
                }
                
            }
            else
            {
                switch (sortColumnIndex)
                {
                   case 1:
                        filteredLinks = filteredLinks.OrderByDescending(l => l.LinkId);
                        break;
                    case 2:
                        filteredLinks = filteredLinks.OrderByDescending(l => l.LinkName);
                        break;
                    case 3:
                        filteredLinks = filteredLinks.OrderByDescending(l => l.Url);
                        break;
                    case 4:
                        filteredLinks = filteredLinks.OrderByDescending(l => l.Visible);
                        break;
                    default:
                        filteredLinks = filteredLinks.OrderByDescending(l => l.LinkId);
                        break;
                }

            }
            var displayedLinks = filteredLinks.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedLinks = displayedLinks.Take(displayLength);
            }
            totalRecords = allLinks.Count();
            totalDisplayRecords = filteredLinks.Count();
            return displayedLinks.ToList();
        }

    }
    public interface ILinkRepository : IRepository<Link>
    {
        IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}
