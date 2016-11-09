using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class UniversityController : Controller
    {
        // GET: Universities
        private readonly IUniversityService universityService;
        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UniversityFormViewModel universityForm)
        {
            if (ModelState.IsValid)
            {
                var university = Mapper.Map<UniversityFormViewModel, University>(universityForm);
                universityService.CreateUniversity(university);
                universityService.SaveUniversity();
                return RedirectToAction("Index");
            }
            return View(universityForm);
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UniversityFormViewModel universityForm)
        {
            if (ModelState.IsValid)
            {
                var university = Mapper.Map<UniversityFormViewModel, University>(universityForm);
                universityService.UpdateUniversity(university);
                universityService.SaveUniversity();
                return RedirectToAction("Index");
            }
            return View(universityForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"];
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedUniversities = universityService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from u in displayedUniversities select new[] { u.UniversityId.ToString(), u.UniversityId.ToString(), u.UniversityName.ToString() };
            
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}