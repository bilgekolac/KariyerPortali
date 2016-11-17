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
    public class FormController : BaseController
    {
        private readonly IFormService formService;
        private readonly IFormInfoService formInfoService;
        public FormController(IFormService formService, IFormInfoService formInfoService)
        {
            this.formService = formService;
            this.formInfoService = formInfoService;
        }
        // GET: Form
        public ActionResult Create()
        {
            var form = new FormFormViewModel();
            return View(form);
        }

        [HttpPost]
        public ActionResult Create(FormFormViewModel form)
        {
            if (ModelState.IsValid)
            {
                var frm = Mapper.Map<FormFormViewModel, Form>(form);
                
                formService.CreateForm(frm);

                formService.SaveForm();
                return RedirectToAction("Index");

            }
            return View(form);

        }

        public ActionResult Details(int? id)
        {
            return View();
        }

        public ActionResult Index()
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
            var displayedForms = formService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedForms
                         select new[] { c.JobId.ToString(), c.Title.ToString(), (c.Description != null ? c.Description.ToString() : string.Empty), (c.Employer != null ? c.Employer.EmployerName.ToString() : string.Empty), (c.Employer != null ? c.City.CityName.ToString() : string.Empty), c.JobType.ToString(), c.Createdate.ToShortDateString(), string.Empty };
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