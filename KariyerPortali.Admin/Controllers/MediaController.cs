﻿using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class MediaController : Controller
    {
        private readonly IFileService fileService;
        // GET: Media

        public MediaController(IFileService fileService)
        {
            this.fileService = fileService;
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
        public ActionResult Create(FileFormViewModel fileForm, System.Web.HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var file = Mapper.Map<FileFormViewModel, KariyerPortali.Model.File>(fileForm);
                file.CreatedBy = "mdemirci"; //User.Identity.Name
                file.CreateDate = DateTime.Now;
                file.UpdatedBy = "mdemirci";
                file.UpdateDate = DateTime.Now;
                if (upload != null)
                {
                    if (Path.GetExtension(upload.FileName) == ".doc" || Path.GetExtension(upload.FileName) == ".pdf" || Path.GetExtension(upload.FileName) == ".rtf")
                    {
                        string dosyaYolu = Path.GetFileName(upload.FileName);
                        var yuklemeYeri = Path.Combine(Server.MapPath("~/Uploads/File"), dosyaYolu);
                        upload.SaveAs(yuklemeYeri);
                        file.FileName = upload.FileName;
                    }
                    else return View(fileForm);
                   

                }
                fileService.CreateFile(file);
                fileService.SaveFile();
                return RedirectToAction("Index");
            }
            return View(fileForm);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var file = fileService.GetFile(id.Value);
                if (file != null)
                {
                    var fileViewModel = Mapper.Map<KariyerPortali.Model.File, FileFormViewModel>(file);
                    return View(fileViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FileFormViewModel fileForm)
        {
            if (ModelState.IsValid)
            {
                var university = Mapper.Map<FileFormViewModel, KariyerPortali.Model.File>(fileForm);
                fileService.UpdateFile(university);
                fileService.SaveFile();
                return RedirectToAction("Index");
            }
            return View(fileForm);
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {


            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedFiles = fileService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedFiles
                         select new[] { string.Empty, c.FileName, c.CreatedBy, c.CreateDate.ToString(), c.UpdatedBy, c.UpdateDate.ToString(), string.Empty };
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