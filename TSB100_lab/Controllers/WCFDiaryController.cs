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
            WCFDiaryService.WCFDiaryServiceClient client = new WCFDiaryService.WCFDiaryServiceClient();
            List<WCFDiaryService.WCFDiaryServiceData> wcfDiaryList = client.GetDiaryData().ToList();
            return View(wcfDiaryList);
        }
    }
}