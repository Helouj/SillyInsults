using Data;
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
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexGenerate()
        {
            //most of the code here I wrote so that this function could be called for all 3 tables, instead of a function in each table
            Random rand = new Random(DateTime.Now.Millisecond);
            var AdjectiveSvc = new AdjectiveService();
            var NounSvc = new NounService();
            var TitleSvc = new TitleService();

            int randAdjIndex;
            int randNounIndex;
            int randTitleIndex;

            IEnumerable<AdjectiveDetail> AdjList = AdjectiveSvc.GetAdjectives();
            IEnumerable<NounDetail> NounList = NounSvc.GetNouns();
            IEnumerable<TitleDetail> TitleList = TitleSvc.GetTitles();
            
            //generate 3 random parts, store it in a table, then display the insult
            //int numberOfAdjectives = AdjectiveSvc.GetNumberOfEntries("Adjective");
            randAdjIndex = (rand.Next() % AdjList.Count());
            randNounIndex = (rand.Next() % NounList.Count());
            randTitleIndex = (rand.Next() % TitleList.Count());

            var AdjObj = AdjList.ElementAt(randAdjIndex);
            var NounObj = NounList.ElementAt(randNounIndex);
            var TitleObj = TitleList.ElementAt(randTitleIndex);
            

            SillyInsultHistory insult = new SillyInsultHistory();
            insult.AdjectiveWord = AdjObj.AdjectiveWord;
            insult.NounWord = NounObj.NounWord;
            insult.TitleWord = TitleObj.TitleWord;


            return View(insult);

        }
        //determine which function to call based on what it's given

        //already have number of entries in each table for this.  Based on that, I need to generate a random number, do modulo(number of entries), then get that entry from the table, and display it on the screen



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
