using KariyerPortali.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var db = new ApplicationDbContext())
                {
                    var loggedInUser = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    ViewBag.LoggedInUser = loggedInUser;
                }
            }
        }
    }
}