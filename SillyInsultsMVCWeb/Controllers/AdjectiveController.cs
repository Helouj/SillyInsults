using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SillyInsultsMVCWeb.Controllers
{
    public class AdjectiveController : Controller
    {
        // GET: Adjective

        public ActionResult Index()
        {
            AdjectiveService service = new AdjectiveService();
            IEnumerable<AdjectiveDetail> model = service.GetAdjectives();
            return View(model);
        }

        // GET: Adjective/Details/5
       
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Adjective/Create
        public ActionResult Create(AdjectiveCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new AdjectiveService();

            if (service.CreateAdjective(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Adjective could not be created.");

            return View(model);

        }



        // GET: Adjective/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new AdjectiveService();
            var modelInDB = service.GetAdjectiveByID(id);

            var model = new AdjectiveEdit
            {
                AdjectiveID = modelInDB.AdjectiveID,
                AdjectiveWord = modelInDB.AdjectiveWord
            };
            return View(model);
        }

        // POST: Adjective/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdjectiveEdit model)
        {

            if (!ModelState.IsValid)
            // TODO: Add update logic here
            {
                return View(model);

            }
            if (model.AdjectiveID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

                return View(model);
            }

            var service = new AdjectiveService();

            if (service.UpdateAdjective(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }




        // GET: Adjective/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = new AdjectiveService();
            var model = svc.GetAdjectiveByID(id);
            return View(model);
        }

        // POST: Adjective/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new AdjectiveService();
            service.DeleteAdjective(id);

            TempData["SaveResult"] = "your adjective was deleted";

            return RedirectToAction("Index");
        }
    }
}
