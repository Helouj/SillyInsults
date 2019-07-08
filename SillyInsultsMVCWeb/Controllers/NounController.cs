using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SillyInsultsMVCWeb.Controllers
{
    public class NounController : Controller
    {
        // GET: Noun

        public ActionResult Index()
        {
            NounService service = new NounService();
            IEnumerable<NounDetail> model = service.GetNouns();
            return View(model);
        }

        // GET: Noun/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Noun/Create
        public ActionResult Create(NounCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new NounService();

            if (service.CreateNoun(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Noun could not be created.");

            return View(model);

        }



        // GET: Noun/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new NounService();
            var modelInDB = service.GetNounByID(id);

            var model = new NounEdit
            {
                NounID = modelInDB.NounID,
                NounWord = modelInDB.NounWord
            };
            return View(model);
        }

        // POST: Noun/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NounEdit model)
        {

            if (!ModelState.IsValid)
            // TODO: Add update logic here
            {
                return View(model);
                
            }if(model.NounID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

            return View(model);
            }

            var service = new NounService();

            if (service.UpdateNoun(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


    

        // GET: Noun/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = new NounService();
            var model = svc.GetNounByID(id);
            return View(model);
        }

        // POST: Noun/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new NounService();
            service.DeleteNoun(id);

            TempData["SaveResult"] = "your noun was deleted";

            return RedirectToAction("Index");
        }
    }
}
