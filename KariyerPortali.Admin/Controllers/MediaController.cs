using AutoMapper;
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
        double size;
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
                        file.Size = upload.ContentLength/2048;
                        fileService.CreateFile(file);
                        fileService.SaveFile();
                        return RedirectToAction("Index");
                    }
                    else return View(fileForm);
                }
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
                    var fileViewModel = Mapper.Map<KariyerPortali.Model.File, FileViewModel>(file);
                    return View(fileViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FileFormViewModel fileForm, System.Web.HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var file = Mapper.Map<FileFormViewModel, KariyerPortali.Model.File>(fileForm);
                file.CreateDate = DateTime.Now;
               file.CreatedBy = "aysenur";
                file.UpdateDate = DateTime.Now;
                file.UpdatedBy = "aysenur";
                if (upload != null)
                {
                    try
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
                    catch (Exception) { return View(fileForm); }
                }
                fileService.UpdateFile(file);
                fileService.SaveFile();
                return RedirectToAction("Index");
            }
            return View(fileForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var file = fileService.GetFile(id.Value);
                if (file != null)
                {
                    try
                    {
                        var yuklemeYeri = Path.Combine(Server.MapPath("~/Uploads/File"), file.FileName);
                        if (System.IO.File.Exists(yuklemeYeri))
                        {
                            System.IO.File.Delete(yuklemeYeri);
                        }
                        fileService.DeleteFile(file);
                        fileService.SaveFile();
                        return RedirectToAction("Index");
                    }
                    catch (Exception) { return HttpNotFound(); }
                }

            }
            return HttpNotFound();
        }
        public ActionResult Details(int id)
        {
            var file = fileService.GetFile(id);
            return View(Mapper.Map<KariyerPortali.Model.File, FileViewModel>(file));

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
                         select new[] { c.FileId.ToString(), c.FileName, c.CreatedBy, c.CreateDate.ToString(), c.UpdatedBy, c.UpdateDate.ToString(), string.Empty };
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