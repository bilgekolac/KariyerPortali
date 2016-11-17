using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class FormInfoController : BaseController
    {
        // GET: FormInfo
        public ActionResult Create()
        {
            return View();
        }
    }
}