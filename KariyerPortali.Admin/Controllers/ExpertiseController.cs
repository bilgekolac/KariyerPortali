using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class ExpertiseController : Controller
    { 
        private readonly IExpertiseService expertiseService;

        public ExpertiseController(IExpertiseService expertiseService)
        {
            this.expertiseService = expertiseService;
        }

        // GET: Expertise
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
        public ActionResult Create(ExpertiseFormViewModel expertiseForm)
        {
            if (ModelState.IsValid)
            {
                var expertise = Mapper.Map<ExpertiseFormViewModel, Expertise>(expertiseForm);
                expertiseService.CreateExpertise(expertise);
                expertiseService.SaveExpertise();
                return RedirectToAction("Index");
            }
            return View(expertiseForm);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var expertise = expertiseService.GetExpertise(id.Value);
                if (expertise != null)
                {
                    var expertiseViewModel = Mapper.Map<Expertise, ExpertiseViewModel>(expertise);
                    return View(expertiseViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpertiseFormViewModel expertiseForm)
        {
            if (ModelState.IsValid)
            {
                var expertise = Mapper.Map<ExpertiseFormViewModel, Expertise>(expertiseForm);
                expertiseService.UpdateExpertise(expertise);
                expertiseService.SaveExpertise();
                return RedirectToAction("Index");
            }
            return View(expertiseForm);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var expertise = expertiseService.GetExpertise(id.Value);
                if (expertise != null)
                {
                    expertiseService.DeleteExpertise(expertise);
                    expertiseService.SaveExpertise();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
  
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedExpertises = expertiseService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from l in displayedExpertises
                         select new[] { l.ExpertiseId.ToString(), l.ExpertiseId.ToString(), l.ExpertiseName.ToString(), string.Empty };
            
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