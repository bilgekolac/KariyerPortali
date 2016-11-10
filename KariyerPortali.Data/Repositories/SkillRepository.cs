using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
   
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Skill> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Skills.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.SkillName.Contains(sSearch));
                }
            }

            var allSkills = query;

            IEnumerable<Skill> filteredSkills = allSkills;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSkills = filteredSkills.OrderBy(c => c.SkillId);
                        break;
                    case 2:
                        filteredSkills = filteredSkills.OrderBy(c => c.SkillName);
                        break;

                    default:
                        filteredSkills = filteredSkills.OrderBy(c => c.SkillId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredSkills = filteredSkills.OrderByDescending(c => c.SkillId);
                        break;
                    case 2:
                        filteredSkills = filteredSkills.OrderByDescending(c => c.SkillName);
                        break;

                    default:
                        filteredSkills = filteredSkills.OrderByDescending(c => c.SkillId);
                        break;
                }
            }
            var displayedSkills = filteredSkills.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedSkills = displayedSkills.Take(displayLength);
            }
            totalRecords = allSkills.Count();
            totalDisplayRecords = filteredSkills.Count();
            return displayedSkills.ToList();

        }

    }
    public interface ISkillRepository : IRepository<Skill>
    {
        IEnumerable<Skill> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}
