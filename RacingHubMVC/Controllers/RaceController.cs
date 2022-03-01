using Microsoft.AspNet.Identity;
using RacingHub.Models.Race;
using RacingHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingHubMVC.Controllers
{
    public class RaceController : Controller
    {
        // GET: Race
        public ActionResult Index()
        {
            //This Method will display races for a specific user.
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RaceService(userId);
            var model = service.GetRaces();

            return View(model);
          
            //return View();
        }
 
        public ActionResult Create()
        {
            return View();
        }
        private RaceService CreateRaceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var raceService = new RaceService(userId);
            return raceService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceCreate model)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RaceService(userId);
            service.CreateRace(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Race/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateRaceService();
            var model = svc.GetRaceById(id);
            return View(model);
        }


        //GET: Edit
        //Race/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateRaceService();
            var detail = svc.GetRaceById(id);
            var model = new RaceEdit
            {
                RaceId = detail.RaceId,
                CarType = detail.CarType,
                RaceName = detail.RaceName,
                RaceDate = detail.RaceDate,
                RaceDescription = detail.RaceDescription,
                DriverLimit = detail.DriverLimit,
            
            };
            return View(model);
        }

        //POST: Edit
        //Race/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RaceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RaceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRaceService();

            if (service.UpdateRace(model))
            {
                TempData["SaveResult"] = "Your race has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your race could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Race/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRaceService();
            var model = svc.GetRaceById(id);
            return View(model);
        }

        //POST: Delete
        //Race/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRace(int id)
        {
            var service = CreateRaceService();
            service.DeleteRace(id);
            TempData["SaveResult"] = "Your Race has been deleted.";

            return RedirectToAction("Index");
        }
    }
}