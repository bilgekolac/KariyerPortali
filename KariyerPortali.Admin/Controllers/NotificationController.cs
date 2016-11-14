using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class NotificationController:BaseController
    {
        private readonly INotificationService notificatinService;

        public NotificationController(INotificationService notificatinService)
        {
            this.notificatinService = notificatinService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}