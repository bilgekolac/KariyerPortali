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

            //if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            //{
            //    using (var db = new ApplicationDbContext())
            //    {
            //        try
            //        {
            //            var loggedInUser = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            //            ViewBag.LoggedInUser = loggedInUser;
            //            base.OnActionExecuting(filterContext);
            //        }
            //        catch (Exception)
            //        {
            //            ViewBag.LoggedInUser = null;
            //            base.OnActionExecuting(filterContext);

            //        }
            //    }
            //}
            if (Request.IsAuthenticated && User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (Session["User"] == null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        string username = User.Identity.Name;
                        var user = db.Users.FirstOrDefault(u => u.UserName == username);
                        Session["User"] = user;
                        ViewBag.LoggedInUser = Session["User"];
                    }
                }
                else
                {
                    ViewBag.LoggedInUser = Session["User"];
                }
            }
            else
            {
                Session["User"] = null;
            }
        }
    }
}