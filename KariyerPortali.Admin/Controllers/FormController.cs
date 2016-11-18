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
            if (id.HasValue)
            {
                var frm = formService.GetForm(id.Value);
                if (frm != null)
                {
                    formService.SaveForm();
                    var formViewModel = Mapper.Map<Form, FormViewModel>(frm);
                    return View(formViewModel);
                }
            }
            return HttpNotFound();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                var frm = formService.GetForm(id.Value);
                if (frm != null)
                {
                    var formViewModel = Mapper.Map<Form, FormViewModel>(frm);
                    ViewBag.FormId = new SelectList(formService.GetForms(), "FormId", "FormName");
                    ViewBag.FormInfoId = new SelectList(formInfoService.GetFormInfos(), "FormInfoId", "FormInfoName");
                    return View(formViewModel);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormFormViewModel form)
        {
            ViewBag.FormId = new SelectList(formService.GetForms(), "FormId", "FormName");
            ViewBag.FormInfoId = new SelectList(formInfoService.GetFormInfos(), "FormInfoId", "FormInfoName");
            if (ModelState.IsValid)
            {
                var frm = Mapper.Map<FormFormViewModel, Form>(form);
                formService.UpdateForm(frm);
                formService.SaveForm();
                return RedirectToAction("Index");
            }

            return View(form);
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
                         select new[] { c.FormId.ToString(), c.FormName.ToString(), (c.Description != null ? c.Description.ToString() : string.Empty), (c.ClosingDescription != null ? c.ClosingDescription.ToString() : string.Empty), string.Empty };
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