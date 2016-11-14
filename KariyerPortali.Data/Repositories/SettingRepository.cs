using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{

    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Setting GetSettingByName(string name)
        {
            return DbContext.Settings.FirstOrDefault(s => s.Name == name);
        }
    }
    public interface ISettingRepository : IRepository<Setting>
    {
        Setting GetSettingByName(string name);
    }
}
