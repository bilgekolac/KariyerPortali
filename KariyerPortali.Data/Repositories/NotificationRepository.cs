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
        public IEnumerable<Notification> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Notifications.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    DateTime dDate;
                    bool dateParsed = false;
                    if (DateTime.TryParse(sSearch, out dDate))
                    {
                        dDate = DateTime.Parse(sSearch);
                        dateParsed = true;
                    }

                    query = query.Where(n => n.Message.Contains(sSearch) || n.Details.Contains(sSearch) ||
                      n.Param1.Contains(sSearch) || n.Param2.Contains(sSearch) || n.Param3.Contains(sSearch) ||
                      (dateParsed==true ? n.NotificationDate==dDate: false) || n.NotificationType.ToString().Contains(sSearch)
                    );
                }
            }

            var allNotifiacations = query;
            IEnumerable<Notification> filteredNotifications = allNotifiacations;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredNotifications = filteredNotifications.OrderBy(n=>n.Message);
                        break;
                    case 1:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.Details);
                        break;
                    case 2:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.Param1);
                        break;
                    case 3:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.Param2);
                        break;

                    case 4:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.Param3);
                        break;
                    case 5:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.NotificationDate);
                        break;
                    case 6:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.NotificationType);
                        break;

                    default:
                        filteredNotifications = filteredNotifications.OrderBy(n => n.NotificationId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.Message);
                        break;
                    case 1:
                        filteredNotifications = filteredNotifications.OrderByDescending(n=>n.Details);
                        break;
                    case 2:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.Param1);
                        break;
                    case 3:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.Param2);
                        break;
                    case 4:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.Param3);
                        break;
                    case 5:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.NotificationDate);
                        break;

                       case 6:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.NotificationType);
                        break;

                    default:
                        filteredNotifications = filteredNotifications.OrderByDescending(n => n.NotificationId);
                        break;
                }
            }

            var displayedNotifications = filteredNotifications.Skip(displayStart).Take(displayLength);
            totalRecords = allNotifiacations.Count();
            totalDisplayRecords = filteredNotifications.Count();
            return displayedNotifications.ToList();

        }

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
        IEnumerable<Notification> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }

}
