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
    public class SectorController : BaseController
    {
        private readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }
       
        // GET: Sector
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
        public ActionResult Create(SectorFormViewModel sectorForm)
        {
            if (ModelState.IsValid)
            {
                var sector = Mapper.Map<SectorFormViewModel, Sector>(sectorForm);

                sectorService.CreateSector(sector);
                sectorService.SaveSector();
                return RedirectToAction("Index");
            }
            return View(sectorForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedSectors = sectorService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from e in displayedSectors
                         select new[] { e.SectorId.ToString(), e.SectorId.ToString(), e.SectorName, string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);

        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var sector = sectorService.GetSector(id.Value);
                if (sector != null)
                {
                    var sectorViewModel = Mapper.Map<Sector, SectorViewModel>(sector);
                    return View(sectorViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectorFormViewModel sectorForm)
        {
            if (ModelState.IsValid)
            {
                var sector = Mapper.Map < SectorFormViewModel, Sector>(sectorForm);
                sectorService.UpdateSector(sector);
                sectorService.SaveSector();
                return RedirectToAction("Index");
            }
            return View(sectorForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var sector = sectorService.GetSector(id.Value);
                if (sector != null)
                {
                    sectorService.DeleteSector(sector);
                    sectorService.SaveSector();
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }

    }
}