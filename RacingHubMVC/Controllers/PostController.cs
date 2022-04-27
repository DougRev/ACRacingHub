using Microsoft.AspNet.Identity;
using RacingHub.Models.Post;
using RacingHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingHubMVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            //This Method will display races for a specific user.
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService();
            var model = service.GetPosts();

            return View(model);

            //return View();
        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService();
            return postService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService();
            service.CreatePost(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Team/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }


        //GET: Edit
        //Post/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreatePostService();
            var detail = svc.GetPostById(id);
            var model = new PostEdit
            {
                PostId = detail.PostId,
                PostName = detail.PostName,
                PostBody = detail.PostBody,
                ModifiedUtc = DateTime.Now,

            };
            return View(model);
        }

        //POST: Edit
        //Post/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PostId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePostService();

            if (service.EditPost(model))
            {
                TempData["SaveResult"] = "Your team has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Post/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }

        //POST: Delete
        //Post/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRace(int id)
        {
            var service = CreatePostService();
            service.DeletePost(id);
            TempData["SaveResult"] = "Your Post has been deleted.";

            return RedirectToAction("Index");
        }
    }
}