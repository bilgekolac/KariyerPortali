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
    }
    public interface IFormInfoRepository : IRepository<FormInfo>
    {

    }
}
