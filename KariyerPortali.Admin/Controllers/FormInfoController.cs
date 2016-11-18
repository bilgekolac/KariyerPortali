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
        [HttpPost]
        public ActionResult Create(FormInfoFormViewModel formInfo)
        {
            if (ModelState.IsValid)
            {
                var frmInfo = Mapper.Map<FormInfoFormViewModel, FormInfo>(formInfo);

                formInfoService.CreateFormInfo(frmInfo);

                formInfoService.SaveFormInfo();
                return RedirectToAction("Index");

            }
            return View(formInfo);

        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var frmInfo = formInfoService.GetFormInfo(id.Value);
                if (frmInfo != null)
                {
                    formInfoService.SaveFormInfo();
                    var formInfoViewModel = Mapper.Map<FormInfo, FormInfoViewModel>(frmInfo);
                    return View(formInfoViewModel);
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
                var frmInfo = formInfoService.GetFormInfo(id.Value);
                if (frmInfo != null)
                {
                    var formInfoViewModel = Mapper.Map<FormInfo, FormInfoViewModel>(frmInfo);
                    ViewBag.FormInfoId = new SelectList(formInfoService.GetFormInfos(), "FormInfoId", "FormInfoDescription");
                    return View(formInfoViewModel);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormInfoFormViewModel formInfo)
        {
            ViewBag.FormInfoId = new SelectList(formInfoService.GetFormInfos(), "FormInfoId", "FormInfoDescription");
            if (ModelState.IsValid)
            {
                var frmInfo = Mapper.Map<FormInfoFormViewModel, FormInfo>(formInfo);
                formInfoService.UpdateFormInfo(frmInfo);
                formInfoService.SaveFormInfo();
                return RedirectToAction("Index");
            }

            return View(formInfo);
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
    }
}