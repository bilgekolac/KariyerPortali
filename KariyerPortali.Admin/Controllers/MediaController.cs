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
        public ActionResult Create(FileFormViewModel fileForm)
        {
          
            if (ModelState.IsValid)
            {
                var file = Mapper.Map<FileFormViewModel, File>(fileForm);
                file.CreatedBy = "mdemirci"; //User.Identity.Name
                file.CreateDate = DateTime.Now;
                file.UpdatedBy = "mdemirci";
                file.UpdateDate = DateTime.Now;
                file.FileName = "aysenur"; //upload.FileName;
                fileService.CreateFile(file);
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
                         select new[] { string.Empty, c.FileName, c.CreatedBy ,c.CreateDate.ToString() ,c.UpdatedBy ,c.UpdateDate.ToString(), string.Empty };
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