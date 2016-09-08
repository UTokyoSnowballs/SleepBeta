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
        public ActionResult Index()
        {
            MyViewModel model = new MyViewModel();
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Models.Database Db = new Models.Database();
                DateTime endStop = DateTime.UtcNow.Date.AddDays(-5);
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var lastSynced = from a in Db.Userdatas
                                 where a.AspNetUserId.Equals(userId) && a.FitbitData.Equals(false) && a.DateStamp >= endStop
                                 orderby a.DateStamp
                                 select a;
                foreach (Userdata data in lastSynced)
                {
                    if (data.DateStamp == DateTime.UtcNow.Date)
                    {
                        model.Userdata = data;
                        return View(model);
                    }
                }

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