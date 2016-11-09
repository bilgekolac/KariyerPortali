using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    public IEnumerable<City> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Cities.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.CityName.ToString().Contains(sSearch));
                }
            }

            var allCities = query;

            IEnumerable<City> filteredCities = allCities;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCities = filteredCities.OrderBy(c => c.CityId);
                        break;
                    case 2:
                        filteredCities = filteredCities.OrderBy(c => c.CityName);
                        break;
                  
                    default:
                        filteredCities = filteredCities.OrderBy(c => c.CityId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityId);
                        break;
                    case 2:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityName);
                        break;
          
                    default:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityId);
                        break;
                }
            }

            var displayedCities = filteredCities.Skip(displayStart).Take(displayLength);

            totalRecords = allCities.Count();
            totalDisplayRecords = filteredCities.Count();
            return displayedCities.ToList();
        }
    }
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
