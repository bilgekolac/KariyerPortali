using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Languages.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(l => l.LanguageName.Contains(sSearch));
                }
            }

            var allLanguages = query;
            IEnumerable<Language> filteredLanguages = allLanguages;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageId);
                        break;
                    case 2:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageName);
                        break;

                    default:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 1:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageId);
                        break;
                    case 2:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageName);
                        break;

                    default:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageId);
                        break;
                }
            }
            var displayedLanguages = filteredLanguages.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedLanguages = displayedLanguages.Take(displayLength);
            }

            
            totalRecords = allLanguages.Count();
            totalDisplayRecords = filteredLanguages.Count();
            return displayedLanguages.ToList();
        }
    }
    public interface ILanguageRepository : IRepository<Language>
    {
        IEnumerable<Language> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
