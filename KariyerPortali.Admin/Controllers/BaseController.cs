using KariyerPortali.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                using (var db = new ApplicationDbContext())
                {
                    var loggedInUser = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    ViewBag.LoggedInUser = loggedInUser;
                }
            }
 	            base.OnActionExecuting(filterContext);
        }
        
    }
}