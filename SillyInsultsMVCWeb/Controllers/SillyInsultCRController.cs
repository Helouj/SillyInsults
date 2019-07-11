using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Services;
using SillyInsultsMVCWeb.Models;

namespace SillyInsultsMVCWeb.Controllers
{
    public class SillyInsultCRController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SillyInsultCR
        public ActionResult Index()
        {

            SillyInsultService service = new SillyInsultService();
            IEnumerable<SillyInsultCR> model = service.GetSillyInsults();
            return View(model);

            //return View(db.SillyInsults.ToList());
        }

        // GET: SillyInsultCR/Details/5


        // GET: SillyInsultCR/Create
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Noun/Create
        public ActionResult Create(SillyInsultCR model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new SillyInsultService();

            if (service.CreateSillyInsult(model))
            {
                TempData["SaveResult"] = "Your insult was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Insult could not be created.");

            return View(model);

        }


        // GET: SillyInsultCR/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = new SillyInsultService();
            var model = svc.GetSillyInsultByID(id);
            return View(model);
        }
        

        // POST: Title/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new SillyInsultService();
            service.DeleteSillyInsult(id);

            TempData["SaveResult"] = "your title was deleted";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
