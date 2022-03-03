using Microsoft.AspNet.Identity;
using RacingHub.Models.Team;
using RacingHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingHubMVC.Controllers
{
    public class TeamController : Controller
    {
        //GET: Teams
        public ActionResult Index()
        {
            //This Method will display races for a specific user.
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamServices(userId);
            var model = service.GetTeams();

            return View(model);

            //return View();
        }
        private TeamServices CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamServices(userId);
            return teamService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamServices(userId);
            service.CreateTeam(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Team/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);
            return View(model);
        }


        //GET: Edit
        //Team/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateTeamService();
            var detail = svc.GetTeamById(id);
            var model = new TeamEdit
            {
                TeamId = detail.TeamId,
                TeamName = detail.TeamName,
                TeamDescription = detail.TeamDescription,
                ModifiedUtc = DateTime.Now,

            };
            return View(model);
        }

        //POST: Edit
        //Team/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (model.TeamId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            {
                ModelState.AddModelError("", "You do not have permission to do this");
            }

            var service = CreateTeamService();

            if (service.EditTeam(model))
            {
                TempData["SaveResult"] = "Your team has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Team/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);
            return View(model);
        }

        //POST: Delete
        //Race/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRace(int id)
        {
            var service = CreateTeamService();
            service.DeleteTeam(id);
            TempData["SaveResult"] = "Your Team has been deleted.";

            return RedirectToAction("Index");
        }
    }
}