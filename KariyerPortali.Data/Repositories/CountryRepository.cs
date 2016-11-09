using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Country> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Countries.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.CountryName.Contains(sSearch));
                }
            }

            var allCountries = query;

            IEnumerable<Country> filteredCountries = allCountries;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryId);
                        break;
                    case 2:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryName);
                        break;

                    default:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryId);
                        break;
                    case 2:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryName);
                        break;

                    default:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryId);
                        break;
                }
            }
            var displayedCountries = filteredCountries.Skip(displayStart).Take(displayLength);

            totalRecords = allCountries.Count();
            totalDisplayRecords = filteredCountries.Count();
            return displayedCountries.ToList();

        }
    }
    public interface ICountryRepository : IRepository<Country>
    {
        IEnumerable<Country> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
