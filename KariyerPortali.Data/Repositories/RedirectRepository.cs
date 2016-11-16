using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class RedirectRepository : RepositoryBase<Redirect>, IRedirectRepository
    {
        public RedirectRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        //public IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)

        //{
        //    search = search.Trim();
        //    var searchWords = search.Split(' ');

        //    var query = this.DbContext.Redirects.AsQueryable();
        //    foreach (string sSearch in searchWords)
        //    {
        //        if (sSearch != null && sSearch != "")
        //        {
        //            query = query.Where(c => c.RedirectName.Contains(sSearch) || c.OldUrl.Contains(sSearch) || c.NewUrl.Contains(sSearch));
        //        }
        //    }

        //    var allRedirects = query;



        //    IEnumerable<Redirect> filteredRedirects = allRedirects;



        //    if (sortDirection == "asc")
        //    {
        //        switch (sortColumnIndex)
        //        {

        //            case 0:
        //                filteredRedirects = filteredRedirects.OrderBy(c => c.RedirectName);
        //                break;
        //            case 1:
        //                filteredRedirects = filteredRedirects.OrderBy(c => c.OldUrl);
        //                break;
        //            case 2:
        //                filteredRedirects = filteredRedirects.OrderBy(c => c.NewUrl);
        //                break;
        //            case 3:
        //                filteredRedirects = filteredRedirects.OrderBy(c => c.RedirectType);
        //                break;
                   
        //            default:
        //                filteredRedirects = filteredRedirects.OrderBy(c => c.RedirectName);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (sortColumnIndex)
        //        {
        //            case 0:
        //                filteredRedirects = filteredRedirects.OrderByDescending(c => c.RedirectName);
        //                break;
        //            case 1:
        //                filteredRedirects = filteredRedirects.OrderByDescending(c => c.OldUrl);
        //                break;
        //            case 2:
        //                filteredRedirects = filteredRedirects.OrderByDescending(c => c.NewUrl);
        //                break;
        //            case 3:
        //                filteredRedirects = filteredRedirects.OrderByDescending(c => c.RedirectType);
        //                break;

        //            default:
        //                filteredRedirects = filteredRedirects.OrderByDescending(c => c.RedirectName);
        //                break;
                       
                    
        //        }
        //    }
        //    var displayedRedirects = filteredRedirects.Skip(displayStart);
        //    if (displayLength >= 0)
        //    {
        //        displayedRedirects = displayedRedirects.Take(displayLength);
        //    }
        //    totalRecords = allRedirects.Count();
        //    totalDisplayRecords = filteredRedirects.Count();
        //    return displayedRedirects.ToList();
        //}

    }
    public interface IRedirectRepository : IRepository<Redirect>
    {
        //IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}
