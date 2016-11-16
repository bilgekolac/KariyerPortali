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
        //public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        //{
        //    string sSearch = "";
        //    if (param.sSearch != null) sSearch = param.sSearch;
        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
        //    var sortDirection = Request["sSortDir_0"]; // asc or desc
        //    int iTotalRecords;
        //    int iTotalDisplayRecords;
        //    var displayedRedirects = redirectService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

        //    var result = from c in displayedRedirects
        //                 select new[] { c.RedirectId.ToString(), c.RedirectName, c.OldUrl.ToString(), c.NewUrl.ToString(), c.RedirectType.ToString(), string.Empty };
        //    return Json(new
        //    {
        //        sEcho = param.sEcho,
        //        iTotalRecords = iTotalRecords,
        //        iTotalDisplayRecords = iTotalDisplayRecords,
        //        aaData = result.ToList()
        //    },
        //        JsonRequestBehavior.AllowGet);
        //}

    }
}
