using KariyerPortali.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var user = new ApplicationDbContext().Users.FirstOrDefault(u => u.UserName == username);
            ViewBag.UserPhoto = user.ImagePath;
            ViewBag.UserName = username;
            return View();
        }

        public ActionResult About()
        {
            System.Net.WebClient myWebClient;
            myWebClient = new System.Net.WebClient();

            Byte[] buffer;
            buffer = myWebClient.DownloadData("http://connect.kliksoft.net/rh/?launcher=false&guestname=Murat%20Demirci");
            string content;

            content = System.Text.Encoding.UTF8.GetString(buffer);

            return View(model:content);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}