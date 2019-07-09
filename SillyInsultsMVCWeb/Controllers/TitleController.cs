using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SillyInsultsMVCWeb.Controllers
{
    public class TitleController : Controller
    {
        // GET: Title

        public ActionResult Index()
        {
            TitleService service = new TitleService();
            IEnumerable<TitleDetail> model = service.GetTitles();
            return View(model);
        }

        // GET: Title/Details/5
       
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Title/Create
        public ActionResult Create(TitleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new TitleService();

            if (service.CreateTitle(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Title could not be created.");

            return View(model);

        }



        // GET: Title/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new TitleService();
            var modelInDB = service.GetTitleByID(id);

            var model = new TitleEdit
            {
                TitleID = modelInDB.TitleID,
                TitleWord = modelInDB.TitleWord
            };
            return View(model);
        }

        // POST: Title/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TitleEdit model)
        {

            if (!ModelState.IsValid)
            // TODO: Add update logic here
            {
                return View(model);
                
            }if(model.TitleID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

            return View(model);
            }

            var service = new TitleService();

            if (service.UpdateTitle(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


    

        // GET: Title/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = new TitleService();
            var model = svc.GetTitleByID(id);
            return View(model);
        }

        // POST: Title/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new TitleService();
            service.DeleteTitle(id);

            TempData["SaveResult"] = "your title was deleted";

            return RedirectToAction("Index");
        }
    }
}
