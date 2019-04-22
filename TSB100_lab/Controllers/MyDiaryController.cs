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
        UserInfoDBEntities db = new UserInfoDBEntities();

        // GET: MyDiary
        public ActionResult Index()
        {

            List<DiaryContent> DiaryContentList = db.DiaryContent.ToList();

            return View(DiaryContentList);
        }

        //Get
        public ActionResult CreateEntry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEntry(DiaryContent diaryContent)
        {
            var diaryContentResult = new DiaryContent
            {
                Author = User.Identity.Name,
                Date = DateTime.Now,
                Entry = diaryContent.Entry,
                Important = diaryContent.Important
            };

            db.DiaryContent.Add(diaryContentResult);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEntry(int id /*, DiaryContent userOwnership*/)
        {
            /*
            
            if (User.Identity.Name == userOwnership.Author)
            {
                DiaryContent deletedEntry = db.DiaryContent.Find(id);
                db.DiaryContent.Remove(deletedEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Alert = "Det är bara ägaren av ett inlägg som kan radera det";
                return RedirectToAction("Index");
            }
            */
            /* var user = from row in db.UserCredentials
                           where row.Username.ToUpper() == username.ToUpper()
                           && row.Password == password
                           select row; */
            
            DiaryContent deletedEntry = db.DiaryContent.Find(id);
            db.DiaryContent.Remove(deletedEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditEntry(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DiaryContent editableContent = db.DiaryContent.Find(id);
            return View(editableContent);
        }

        [HttpPost]
        public ActionResult EditEntry(DiaryContent editedContent)
        {
            db.Entry(editedContent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}