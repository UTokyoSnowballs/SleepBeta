using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleepMakeSense.Models;
using Microsoft.AspNet.Identity;

namespace SleepMakeSense.Controllers
{
    public class HomeController : Controller
    {
        private Database Db = new Models.Database();

        public ActionResult Index()
        {
            MyViewModel model = new MyViewModel();
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                DateTime endStop = DateTime.UtcNow.Date.AddDays(-5);
                model.TodaySync = true;
                model.QuestionsSetup = false;
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

                //Getting Table Data
                var userQuestions = from table in Db.UserQuestions
                                    where table.AspNetUserId.Equals(userId)
                                    select table;

                var lastSynced = from table in Db.DiaryDatas
                                 where table.AspNetUserId.Equals(userId) && table.DateStamp >= endStop
                                 orderby table.DateStamp
                                 select table;

                foreach (UserQuestion userQuestion in userQuestions)
                {
                    if (userQuestion.AspNetUserId == userId )
                    {
                        model.QuestionsSetup = true;
                    }
                }

                foreach (DiaryData diaryData in lastSynced)
                {
                    if (diaryData.AspNetUserId == userId && diaryData.DateStamp == DateTime.UtcNow.Date)
                    {
                        model.TodaySync = false;
                    }
                }

                return View(model);

            }

            return View();
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