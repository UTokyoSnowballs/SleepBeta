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

        [HttpGet]
        public ActionResult DiaryDataSetup()
        {
            DiaryDataSetupModel diaryDataSetupData = new DiaryDataSetupModel();
            // Might want to load the data and assign it to the model.

            IEnumerable<UserQuestion> dataQuery = from table in Db.UserQuestions
                            where table.AspNetUserId.Equals(System.Web.HttpContext.Current.User.Identity.GetUserId())
                            select table;
            bool previousEntry = false;

            foreach (UserQuestion entry in dataQuery)
            {
                if (entry.AspNetUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    diaryDataSetupData.userQuestions = entry;
                    previousEntry = true;
                }
            }
            if(!previousEntry)
            {
                diaryDataSetupData.userQuestions = new UserQuestion() { AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId() };
            }

            return View(diaryDataSetupData);//);
        }
        /// <summary>
        /// This Method submits the questions to ask the user.
        /// this is done by looking for any previous entry and updating it.
        /// If it is unable to do so, it will submit a new entry
        /// </summary>
        /// <param name="diaryDataSetupData"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DiaryDataSetup(DiaryDataSetupModel diaryDataSetupData)
        {
            IEnumerable<UserQuestion> dataQuery = from table in Db.UserQuestions
                                                  where table.AspNetUserId.Equals(System.Web.HttpContext.Current.User.Identity.GetUserId())
                                                  select table;
            bool recordPresent = false;

            foreach (UserQuestion entry in dataQuery)
            {
            if (entry.AspNetUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                recordPresent = true;
                entry.WakeUpFreshness = diaryDataSetupData.userQuestions.WakeUpFreshness;
                entry.Mood = diaryDataSetupData.userQuestions.Mood;
                entry.Stress = diaryDataSetupData.userQuestions.Stress;
                entry.Tiredness = diaryDataSetupData.userQuestions.Tiredness;
                entry.Dream = diaryDataSetupData.userQuestions.Dream;
                entry.SchoolQuestions = diaryDataSetupData.userQuestions.SchoolQuestions;
                entry.CoffeeQuestions = diaryDataSetupData.userQuestions.CoffeeQuestions;
                entry.AlcoholQuestions = diaryDataSetupData.userQuestions.AlcoholQuestions;
                entry.NapQuestions = diaryDataSetupData.userQuestions.NapQuestions;
                entry.DigDeviceDurationQuestion = diaryDataSetupData.userQuestions.DigDeviceDurationQuestion;
                entry.GameDurationQuestion = diaryDataSetupData.userQuestions.GameDurationQuestion;
                entry.SocialMediaDurationQuestion = diaryDataSetupData.userQuestions.SocialMediaDurationQuestion;
                entry.SocialActivityDurationQuestion = diaryDataSetupData.userQuestions.SocialActivityDurationQuestion;
                entry.MusicDurationQuestion = diaryDataSetupData.userQuestions.MusicDurationQuestion;
                entry.TVDurationQuestion = diaryDataSetupData.userQuestions.TVDurationQuestion;
                entry.WorkQuestions = diaryDataSetupData.userQuestions.WorkQuestions;
                entry.ExersiseQuestions = diaryDataSetupData.userQuestions.ExersiseQuestions;
                entry.FoodQuestions = diaryDataSetupData.userQuestions.FoodQuestions;
                entry.GenderHormoneQuestion = diaryDataSetupData.userQuestions.GenderHormoneQuestion;
                }
            }

            if (recordPresent == false)
            {
                diaryDataSetupData.userQuestions.AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                Db.UserQuestions.InsertOnSubmit(diaryDataSetupData.userQuestions);
            }

            Db.SubmitChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult EnterDiaryData()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Setting up the Selection for the questions
                DiaryDataViewClass viewModel = new DiaryDataViewClass();
                viewModel.QUESTIONSELECTION = new QuestionsSelections();

                //Getting the current User for DB lookup
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                DateTime dateStop = DateTime.UtcNow.Date.AddDays(-5);

                //Looking up the questions for the user
                UserQuestion userQuestion = (from table in Db.UserQuestions
                                where table.AspNetUserId.Equals(userId)
                                select table).First();
                viewModel.UserQuestion = userQuestion;

                //Looking up for previously saved data
                IEnumerable<DiaryData> dataQuery = from table in Db.DiaryDatas
                                                      where table.AspNetUserId.Equals(userId) && table.DateStamp == dateStop
                                                      select table;

                bool todaysData = false;

                foreach (DiaryData diaryData in dataQuery)
                {
                    if ( diaryData.AspNetUserId == userId && diaryData.DateStamp == DateTime.UtcNow.Date)
                    {
                        viewModel.diaryData = diaryData;
                        todaysData = true;
                    }
                }

                if (!todaysData)
                {
                    viewModel.diaryData = new DiaryData() { AspNetUserId = userId };
                }

                //Checking if the data is valid and directing to the page
                if (userQuestion.AspNetUserId == userId)
                    {
                        //For AM/PM based questions - not yet fully implemented
                      //  if (DateTime.UtcNow.AddHours(10).ToString("tt") == "AM") viewModel.Morning = true;
                        return View(viewModel);
                    }
                //Clean error Handeling - takes user back to home page - may be changes to setup later on
                return RedirectToAction("Index", "Home");
            }
            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        public ActionResult EnterDiaryData(DiaryDataViewClass model)
        {
            // 20161107 Pandita
            // Models.Database Db = new Models.Database();
            //Database lookup of the last 5 days
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-5);
            DateTime dateNow = DateTime.UtcNow.Date;
            bool update = false;
            IEnumerable <DiaryData> lastSynced = from table in Db.DiaryDatas
                             where table.AspNetUserId.Equals(System.Web.HttpContext.Current.User.Identity.GetUserId()) && table.DateStamp >= dateStop
                             orderby table.DateStamp
                             select table;


            //checking for a previous entry from the same day
            foreach (DiaryData query in lastSynced)
            {

                if (query.DateStamp.Date == dateNow && query.AspNetUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    update = true;               
                    query.WakeUpFreshness = model.diaryData.WakeUpFreshness;
                    query.Mood = model.diaryData.Mood;
                    query.Stress = model.diaryData.Stress;
                    query.Tiredness = model.diaryData.Tiredness;
                    query.Dream = model.diaryData.Dream;
                    query.BodyTemp = model.diaryData.BodyTemp;
                    query.Hormone = model.diaryData.Hormone;
                    query.SchoolStress = model.diaryData.SchoolStress;
                    query.CoffeeAmt = model.diaryData.CoffeeAmt;
                    query.CoffeeTime = model.diaryData.CoffeeTime;
                    query.AlcoholAmt = model.diaryData.AlcoholAmt;
                    query.AlcoholTime = model.diaryData.AlcoholTime;
                    query.NapTime = model.diaryData.NapTime;
                    query.NapDuration = model.diaryData.NapDuration;
                    query.DigDeviceDuration = model.diaryData.DigDeviceDuration;
                    query.GamesDuration = model.diaryData.GamesDuration;
                    query.SocialActivites = model.diaryData.SocialActivites;
                    query.SocialActivity = model.diaryData.SocialActivity;
                    query.MusicDuration = model.diaryData.MusicDuration;
                    query.TVDuration = model.diaryData.TVDuration;
                    query.WorkTime = model.diaryData.WorkTime;
                    query.WorkDuration = model.diaryData.WorkDuration;
                    query.ExerciseDuration = model.diaryData.ExerciseDuration;
                    query.ExerciseIntensity = model.diaryData.ExerciseIntensity;
                    query.DinnerTime = model.diaryData.DinnerTime;
                    query.SnackTime = model.diaryData.SnackTime;                
                }
            }
            //Updating the database if no match in date is found
            if (!update)
            {
                Db.DiaryDatas.InsertOnSubmit(model.diaryData);
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
