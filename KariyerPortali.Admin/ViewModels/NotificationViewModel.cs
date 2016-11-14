using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public DateTime NotificationDate { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }

        public virtual NotificationType NotificationType { get; set; }
    }
}