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
    public class PostController : Controller
    {
        // GET: Post
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
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
        [ValidateInput(false)]
        public ActionResult Create(PostFormViewModel postFrom)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostFormViewModel, Post>(postFrom);
                post.CreatedBy = User.Identity.Name;
                post.CreateDate = DateTime.Now;
                post.UptdatedBy = User.Identity.Name;
                post.UpdateDate = DateTime.Now;
                postService.CreatePost(post);
                postService.SavePost();
                return RedirectToAction("Index");
            }
            return View(postFrom);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"];
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedPosts = postService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from p in displayedPosts select new[] { p.PostId.ToString(), p.PostId.ToString(), p.Title.ToString(), p.CreatedBy.ToString(), p.CreateDate.ToString() };
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