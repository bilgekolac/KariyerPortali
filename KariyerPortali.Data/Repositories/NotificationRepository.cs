using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Notification GetLatestNotification()
        {
            var query = this.DbContext.Notifications.OrderByDescending(o => o.NotificationDate).FirstOrDefault();

            return query;
        }

        public List<Notification> GetLatestNotifications()
        {
            var query = this.DbContext.Notifications.OrderByDescending(o => o.NotificationDate).Take(10).ToList();
            return query;
        }
    }

    public interface INotificationRepository: IRepository<Notification>
    {
        Notification GetLatestNotification();

    }

}
