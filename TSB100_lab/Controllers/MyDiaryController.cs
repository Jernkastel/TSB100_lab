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

        //Get
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
            //UserId is set to either 1(admin) or 2(John_doe) depending on user identity.
            //This is a hard-coded and temporary solution. Not at all how it should be done.
            //Since there currently only exists two users, and no function to add more exists within the webage itself, it works as a bandaid solution.
            int tempId = 0;
            if (User.Identity.Name == "John_doe")
            {
                tempId = 2;
            }
            else
            {
                tempId = 1;
            }

            var diaryContentResult = new DiaryContent
            {
                UserId = tempId,
                Author = User.Identity.Name,
                Date = DateTime.Now,
                Entry = diaryContent.Entry,
                Important = diaryContent.Important
            };
            //The try-catches are bad and serve no real purpose in the current iteration
            try
            {
                db.DiaryContent.Add(diaryContentResult);
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEntry(int id)
        {
            //Deletes entry and saves changes to database
            try
            {
                DiaryContent deletedEntry = db.DiaryContent.Find(id);
                db.DiaryContent.Remove(deletedEntry);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
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
            try
            {
                db.Entry(editedContent).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index");

        }
    }
}