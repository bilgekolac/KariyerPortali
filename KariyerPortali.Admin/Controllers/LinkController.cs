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
    public class LinkController : BaseController
    {


        private readonly ILinkService linkService;

        public LinkController(ILinkService linkService)
        {
            this.linkService = linkService;
        }
        // GET: Link
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
        public ActionResult Create(LinkFormViewModel linkForm)
        {
            if (ModelState.IsValid)
            {
                var link = Mapper.Map<LinkFormViewModel, Link>(linkForm);

                linkService.CreateLink(link);
                linkService.SaveLink();
                return RedirectToAction("Index");
            }
            return View(linkForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedLinks = linkService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedLinks
                         select new[] { c.LinkId.ToString(), c.LinkId.ToString(), c.LinkName, c.Url, c.Visible.ToString(), string.Empty };
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
                var link = linkService.GetLink(id.Value);
                if (link != null)
                {
                    var linkViewModel = Mapper.Map<Link, LinkViewModel>(link);
                    return View(linkViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LinkFormViewModel linkForm)
        {
            if (ModelState.IsValid)
            {
                var link = Mapper.Map<LinkFormViewModel, Link>(linkForm);
                linkService.UpdateLink(link);
                linkService.SaveLink();
                return RedirectToAction("Index");
            }
            return View(linkForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var link = linkService.GetLink(id.Value);
                if (link != null)
                {
                    linkService.DeleteLink(link);
                    linkService.SaveLink();
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }

    }
}