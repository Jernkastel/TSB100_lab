using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSB100_lab.Models;

namespace TSB100_lab.Controllers
{
    public class MyDiaryController : Controller
    {
        // GET: MyDiary
        public ActionResult Index()
        {

            var DiaryList = new List<DiaryEntry>
            {
                new DiaryEntry() { Author = User.Identity.Name, Date = DateTime.Now, Entry = "This is a Placeholder entry", Importance = false}
            };

            return View(DiaryList);
        }
    }
}