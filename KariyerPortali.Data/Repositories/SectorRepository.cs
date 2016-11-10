using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class SectorRepository : RepositoryBase<Sector>, ISectorRepository
    {
        public SectorRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Sector> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Sectors.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(e => e.SectorName.Contains(sSearch));
                }
            }
            var allSectors = query;

            IEnumerable<Sector> filteredSectors = allSectors;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSectors = filteredSectors.OrderBy(e => e.SectorId);
                        break;
                    case 2:
                        filteredSectors = filteredSectors.OrderBy(e => e.SectorName);
                        break;

                    default:
                        filteredSectors = filteredSectors.OrderBy(e => e.SectorId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSectors = filteredSectors.OrderByDescending(e => e.SectorId);
                        break;
                    case 2:
                        filteredSectors = filteredSectors.OrderByDescending(e => e.SectorName);
                        break;

                    default:
                        filteredSectors = filteredSectors.OrderByDescending(e => e.SectorId);
                        break;
                }
            }
            var displayedSectors = filteredSectors.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedSectors = displayedSectors.Take(displayLength);
            }
            totalRecords = allSectors.Count();
            totalDisplayRecords = filteredSectors.Count();
            return displayedSectors.ToList();
        }
    }
}
    public interface ISectorRepository : IRepository<Sector>
    {
    IEnumerable<Sector> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
}

