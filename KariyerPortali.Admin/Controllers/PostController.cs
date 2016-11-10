using AutoMapper;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostViewModel, Post>(postViewModel);
                postService.CreatePost(post);
                postService.SavePost();
                return RedirectToAction("Index");
            }
            return View(postViewModel);
        }
    }
}