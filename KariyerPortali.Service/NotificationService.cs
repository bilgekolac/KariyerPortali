using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{

    public interface INotificationService
    {
        IEnumerable<Notification> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Notification> GetLatestNotifications();
        Notification GetLatestNotification(int id);

    }
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IUnitOfWork unitOfWork;
        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            this.notificationRepository = notificationRepository;
            this.unitOfWork = unitOfWork;
        }


        #region INotificationService Members

        public IEnumerable<Notification> GetLatestNotifications()
        {
            var notifications = notificationRepository.GetAll().OrderByDescending(n=>n.NotificationDate).Take(10);
            return notifications;
        }


        public Notification GetLatestNotification(int id)
        {
            var notification = notificationRepository.GetById(id);
            return notification;
        }

        public IEnumerable<Notification> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var notifications = notificationRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return notifications;
        }

        #endregion
    }
}
