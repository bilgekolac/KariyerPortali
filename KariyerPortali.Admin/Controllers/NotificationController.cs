using KariyerPortali.Admin.Models;
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
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificatinService)
        {
            this.notificationService = notificatinService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxHandler (jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;

            var displayedNotifications = notificationService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from n in displayedNotifications
                         select new[] { n.NotificationId.ToString(), n.Message.ToString(), n.Details.ToString(),
                         n.Param1.ToString(),n.Param2.ToString(),n.Param3.ToString(),n.NotificationDate.ToShortDateString(), n.NotificationType.ToString()};
            
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result
            },
               JsonRequestBehavior.AllowGet);
        }
    }
}