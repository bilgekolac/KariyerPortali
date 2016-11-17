using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class SeoSettingRepository : RepositoryBase<SeoSetting>, ISeoSettingRepository
    {
        public SeoSettingRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<SeoSetting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.SeoSettings.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.Title.Contains(sSearch) );
                }
            }

            var allSeoSettings = query;

            IEnumerable<SeoSetting> filteredSeoSettings = allSeoSettings;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSeoSettings = filteredSeoSettings.OrderBy(c => c.SeoSettingId);
                        break;
                    case 2:
                        filteredSeoSettings = filteredSeoSettings.OrderBy(c => c.Title);
                        break;
                    case 3:
                        filteredSeoSettings = filteredSeoSettings.OrderBy(c => c.Description);
                        break;
                        case 4:
                        filteredSeoSettings = filteredSeoSettings.OrderBy(c => c.Keyword);
                        break;
                    default:
                        filteredSeoSettings = filteredSeoSettings.OrderBy(c => c.SeoSettingId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                     case 1:
                        filteredSeoSettings = filteredSeoSettings.OrderByDescending(c => c.SeoSettingId);
                        break;
                    case 2:
                        filteredSeoSettings = filteredSeoSettings.OrderByDescending(c => c.Title);
                        break;
                    case 3:
                        filteredSeoSettings = filteredSeoSettings.OrderByDescending(c => c.Description);
                        break;
                        case 4:
                        filteredSeoSettings = filteredSeoSettings.OrderByDescending(c => c.Keyword);
                        break;
                    default:
                        filteredSeoSettings = filteredSeoSettings.OrderByDescending(c => c.SeoSettingId);
                        break;
                }
            }

            var displayedSeoSettings = filteredSeoSettings.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedSeoSettings = displayedSeoSettings.Take(displayLength);
            }

            totalRecords = allSeoSettings.Count();
            totalDisplayRecords = filteredSeoSettings.Count();
            return displayedSeoSettings.ToList();
        }
    }
    public interface ISeoSettingRepository : IRepository<SeoSetting>
    {
        IEnumerable<SeoSetting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
    
}
