using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

using SleepMakeSense.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;


namespace SleepMakeSense.Controllers
{
    public class DiaryDataController : Controller
    {
        private SleepbetaDataContext Db = new SleepbetaDataContext();

        public ActionResult DiaryDataSetup()
        {
            //Setting up the Selection for the questions
            MyViewModel viewModel = new MyViewModel();
            viewModel.questionSelection = new QuestionsSelections();
            viewModel.UserQuestion = new UserQuestion() { AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId() };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DiaryDataSetup(MyViewModel model)
        {
            //getting User questions and userID 
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            bool noEntry = false;

            //Looking up the questions for the user
            try {
                UserQuestion dataQuery = (from table in Db.UserQuestions
                                          where table.AspNetUserId.Equals(userId)
                                          select table).First();
                if (dataQuery.AspNetUserId == userId)
                {
                    dataQuery = model.UserQuestion;
                    TempData["notice"] = "Successfully Saved";
                }
                else if (dataQuery.AspNetUserId != userId)
                {
                    noEntry = true;
                }
            }
            catch
            {
                noEntry = true;
            }

            if (noEntry)
            {
                Db.UserQuestions.InsertOnSubmit(model.UserQuestion);
                TempData["notice"] = "Successfully Saved";
            }
            Db.SubmitChanges();
            // Taking the user back home
            return RedirectToAction("Index", "Home");
        }


        public ActionResult EnterDiaryData()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Setting up the Selection for the questions
                MyViewModel viewModel = new MyViewModel();
                viewModel.questionSelection = new QuestionsSelections();

                //Getting the current User for DB lookup
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

                //Looking up the questions for the user
                IEnumerable <UserQuestion> dataQuery = from table in Db.UserQuestions
                                where table.AspNetUserId.Equals(userId)
                                select table;

                //Checking if the data is valid and directing to the page
                foreach (UserQuestion questionData in dataQuery)
                {
                    if (questionData.AspNetUserId == userId)
                    {
                        viewModel.UserQuestion = questionData;
                        //For AM/PM based questions - not yet fully implemented
                      //  if (DateTime.UtcNow.AddHours(10).ToString("tt") == "AM") viewModel.Morning = true;
                        return View(viewModel);
                    }
                }
                //Clean error Handeling - takes user back to home page - may be changes to setup later on
                return RedirectToAction("Index", "Home");
            }

            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        public ActionResult EnterDiaryData(MyViewModel model)
        {
            //getting data, userID and time of save
            DiaryData dairyData = model.DiaryData;
            dairyData.AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            dairyData.DateStamp = DateTime.UtcNow.Date;

            // 20161107 Pandita
            // Models.Database Db = new Models.Database();
            //Database lookup of the last 5 days
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-5);
            bool update = false;
            IEnumerable <DiaryData> lastSynced = from table in Db.DiaryDatas
                             where table.AspNetUserId.Equals(dairyData.AspNetUserId) && table.DateStamp >= dateStop
                             orderby table.DateStamp
                             select table;

            //checking for a previous entry from the same day
            foreach (DiaryData query in lastSynced)
            {
                if (query.DateStamp > dateStop)
                {
                    dateStop = query.DateStamp;
                }
                if (query.DateStamp.Date == dairyData.DateStamp)
                {
                    update = true;
                }
            }
            //Updating the database if no match in date is found
            if (update == false)
            {
                Db.DiaryDatas.InsertOnSubmit(dairyData);
            }
            //   else db.Userdatas.Add(data);
            //Commiting to database
            Db.SubmitChanges();
            //redirection to homepage
            TempData["notice"] = "Successfully Saved";
            return RedirectToAction("Index", "Home");
        }

    }
}
