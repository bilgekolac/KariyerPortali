using KariyerPortali.Admin.Models;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class FormInfoController : BaseController
    {
        private readonly IFormInfoService formInfoService;
        public FormInfoController(IFormInfoService formInfoService)
        {
            this.formInfoService = formInfoService;
        }
        // GET: FormInfo
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedForms = formInfoService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedForms
                         select new[] { c.FormInfoId.ToString(), c.FormInfoDescription.ToString(), (c.FormInfoDescription != null ? c.FormInfoDescription.ToString() : string.Empty), c.Required.ToString(), (c.Value != null ? c.Value.ToString() : string.Empty), string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}