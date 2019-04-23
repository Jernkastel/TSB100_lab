using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSB100_lab.Controllers
{
    public class WCFDiaryController : Controller
    {
        // GET: WCFDiary
        public ActionResult Index()
        {
            //The try-catches are bad and serve no real purpose in the current iteration
            try
            {
                WCFDiaryService.WCFDiaryServiceClient client = new WCFDiaryService.WCFDiaryServiceClient();
                List<WCFDiaryService.WCFDiaryContentData> wcfDiaryList = client.GetDiaryData().ToList();
                return View(wcfDiaryList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
            
        }
    }
}