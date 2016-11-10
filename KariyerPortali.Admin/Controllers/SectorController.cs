using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class SectorController : Controller
    {
        private readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }
       
        // GET: Sector
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}