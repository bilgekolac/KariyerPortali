using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class SettingsController : BaseController
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Theme()
        {
            return View();
        }
    }
}