using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class NotificationFormViewModel
    {
        public int NotificationId { get; set; }
        [DisplayName("Mesaj")]
        public string Message { get; set; }
        [DisplayName("Detaylar")]
        public string Details { get; set; }
        [DisplayName("Bildirim Tarihi")]
        public DateTime NotificationDate { get; set; }
        [DisplayName("Bildirim Tipi")]
        public virtual NotificationType NotificationType { get; set; }

    }
}