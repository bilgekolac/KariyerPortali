using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class RedirectController:BaseController
    {
        private readonly IRedirectService redirectService;
         public RedirectController(IRedirectService redirectService)
        {
            this.redirectService = redirectService;
        }
        public ActionResult Index()
        {

            return View();

        }
    }
}
