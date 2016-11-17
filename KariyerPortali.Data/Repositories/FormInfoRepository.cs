using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class FormInfoRepository : RepositoryBase<FormInfo>, IFormInfoRepository
    {
        public FormInfoRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<FormInfo> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.FormInfos.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.FormInfoDescription.Contains(sSearch) || c.Required.ToString().Contains(sSearch) || c.Value.Contains(sSearch));
                }
            }
            var allFormInfos = query;

            IEnumerable<FormInfo> filteredFormInfos = allFormInfos;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredFormInfos = filteredFormInfos.OrderBy(c => c.FormInfoDescription);
                        break;
                    case 1:
                        filteredFormInfos = filteredFormInfos.OrderBy(c => c.Required);
                        break;
                    case 2:
                        filteredFormInfos = filteredFormInfos.OrderBy(c => c.Value);
                        break;
                    default:
                        filteredFormInfos = filteredFormInfos.OrderBy(c => c.FormInfoDescription);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredFormInfos = filteredFormInfos.OrderByDescending(c => c.FormInfoDescription);
                        break;
                    case 1:
                        filteredFormInfos = filteredFormInfos.OrderByDescending(c => c.Required);
                        break;
                    case 2:
                        filteredFormInfos = filteredFormInfos.OrderByDescending(c => c.Value);
                        break;
                    default:
                        filteredFormInfos = filteredFormInfos.OrderByDescending(c => c.FormInfoDescription);
                        break;
                }
            }

            var displayedFormInfos = filteredFormInfos.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedFormInfos = displayedFormInfos.Take(displayLength);
            }
            totalRecords = allFormInfos.Count();
            totalDisplayRecords = filteredFormInfos.Count();
            return displayedFormInfos.ToList();
        }
    }
    public interface IFormInfoRepository : IRepository<FormInfo>
    {
        IEnumerable<FormInfo> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
    
}
