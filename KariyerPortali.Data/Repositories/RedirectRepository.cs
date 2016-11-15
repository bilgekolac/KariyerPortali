using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class RedirectRepository : RepositoryBase<Redirect>, IRedirectRepository
    {
        public RedirectRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IRedirectRepository : IRepository<Redirect>
    {

    }
}
