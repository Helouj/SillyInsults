using Data;
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
            Random rand = new Random(DateTime.Now.Millisecond);
            //var AdjectiveSVC = new AdjectiveService();
            var NounSvc = new NounService();

            // var TitleSvc = new TitleService(); 
            string[] arr = { "Noun", "Adjective", "Title" };
            int[] arr1 = new int[3];
            //i < 3
            for (int i = 0; i < 1; i++)
            {
                arr1[i] = NounSvc.GetNumberOfEntries(arr[i]);
                int randnumber = rand.Next() % arr1[i] + 1;

                if (i == 0)
                {
                    var service = new NounService();
                    var modelInDB = service.GetNounByID(randnumber);

                    var model = new Noun
                    {
                        NounID = modelInDB.NounID,
                        NounWord = modelInDB.NounWord
                    };
                    return View(model);
                }
            }
            //determine which function to call based on what it's given
            return View();
            //already have number of entries in each table for this.  Based on that, I need to generate a random number, do modulo(number of entries), then get that entry from the table, and display it on the screen

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