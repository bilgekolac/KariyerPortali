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
            var notifications = notificationRepository.GetAll();
            return notifications;
        }


        public Notification GetLatestNotification(int id)
        {
            var notification = notificationRepository.GetById(id);
            return notification;
        }

        #endregion
    }
}
