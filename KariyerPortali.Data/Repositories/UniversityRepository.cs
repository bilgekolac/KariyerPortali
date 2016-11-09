using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{

    public class UniversityRepository : RepositoryBase<University>, IUniversityRepository
    {
        public UniversityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<University> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query=this.DbContext.Universities.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(u => u.UniversityId.ToString().Contains(sSearch) || u.UniversityName.Contains(sSearch));
                }
            }
            var allUniversities=query;
            IEnumerable<University>filteredUniversities=allUniversities;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1: filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityId);
                        break;
                    case 2: filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityName);
                        break;

                    default:
                        filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1: filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityId);
                        break;
                    case 2: filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityName);
                        break;

                    default:
                        filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityId);
                        break;
                }
            }
            var displayedUniversities=filteredUniversities.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedUniversities = displayedUniversities.Take(displayLength);
            }
            totalRecords=allUniversities.Count();
            totalDisplayRecords=filteredUniversities.Count();
            return displayedUniversities.ToList();
        }
    }
    public interface IUniversityRepository : IRepository<University>
    {
        IEnumerable<University> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
