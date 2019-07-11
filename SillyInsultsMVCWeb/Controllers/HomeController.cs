﻿using Data;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SillyInsultsMVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var svc = new SillyInsultService();
            var model = svc.GetSillyInsults();

            //ViewData["randominsult"] = insult;
           // ViewBag.randominsults = insult;
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexGenerate()
        {
            
            
            var AdjectiveSvc = new AdjectiveService();
            var NounSvc = new NounService();
            var TitleSvc = new TitleService();

            string adjname = AdjectiveSvc.GetRandomAdjective();
            string nounname = NounSvc.GetRandomNoun();
            string titlename = TitleSvc.GetRandomTitle();

            SillyInsultCR insult = new SillyInsultCR();
            insult.AdjectiveWord = adjname;
            insult.NounWord = nounname;
            insult.TitleWord = titlename;

            var svc = new SillyInsultService();
            svc.CreateSillyInsult(insult);
            var model = svc.Get10RecentInsults();

            //ViewData["randominsult"] = insult;
            ViewBag.randomadj = insult.AdjectiveWord;
            ViewBag.randomnoun = insult.NounWord;
            ViewBag.randomtitle = insult.TitleWord;
            //var service = new SillyInsultService();
            return View(model);

            //return View(insult);

        }
        public ActionResult ListInsults()
        {
            SillyInsultService service = new SillyInsultService();
            //IEnumerable<SillyInsultCR> model = service.GetSillyInsults();
            //ViewBag.insultlist = service.GetSillyInsults();
            return View(service.Get10RecentInsults());
            //need to have model contain list of insults, and viewbag have the random insults
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}