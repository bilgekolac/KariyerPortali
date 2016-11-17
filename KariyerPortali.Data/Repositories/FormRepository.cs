using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class FormRepository : RepositoryBase<Form>, IFormRepository
    {
        public FormRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Forms.Include("FormInfo").AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {

                    query = query.Where(c => c.FormName.Contains(sSearch) || c.Description.Contains(sSearch) || c.ClosingDescription.Contains(sSearch));
                }
            }
            var allForms = query;

            IEnumerable<Form> filteredForms = allForms;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredForms = filteredForms.OrderBy(c => c.FormName);
                        break;
                    case 1:
                        filteredForms = filteredForms.OrderBy(c => c.Description);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderBy(c => c.ClosingDescription);
                        break;
                    default:
                        filteredForms = filteredForms.OrderBy(c => c.FormName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredForms = filteredForms.OrderByDescending(c => c.FormName);
                        break;
                    case 1:
                        filteredForms = filteredForms.OrderByDescending(c => c.Description);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderByDescending(c => c.ClosingDescription);
                        break;
                    default:
                        filteredForms = filteredForms.OrderByDescending(c => c.FormName);
                        break;
                }
            }

            var displayedForms = filteredForms.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedForms = displayedForms.Take(displayLength);
            }
            totalRecords = allForms.Count();
            totalDisplayRecords = filteredForms.Count();
            return displayedForms.ToList();
        }
    }
    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
