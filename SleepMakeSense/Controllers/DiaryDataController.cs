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
        private SleepBetaDataContext Db = new SleepBetaDataContext();

        [HttpGet]
        public ActionResult DiaryDataSetup()
        {
            DiaryDataSetupModel diaryDataSetupData = new DiaryDataSetupModel() { AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId() };
            // Might want to load the data and assign it to the model.


            //Setting up the Selection for the questions
            //    MyViewModel viewModel = new MyViewModel();
            //    viewModel.UserQuestion = new UserQuestion();
           // UserQuestion userQuestion = new UserQuestion();
            return View(diaryDataSetupData);//);
        }
        /* Old - trying again to fix the null bug
        [HttpPost]
        public ActionResult DiaryDataSetup(UserQuestion userQuestion)
        {
            //getting User questions and userID 
            userQuestion.AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            string userId = userQuestion.AspNetUserId;
            bool noEntry = false;

            //Looking up the questions for the user
            try {
                UserQuestion dataQuery = (from table in Db.UserQuestions
                                          where table.AspNetUserId.Equals(userId)
                                          select table).First();
                if (dataQuery.AspNetUserId == userId)
                {
                    dataQuery = userQuestion;
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
                Db.UserQuestions.InsertOnSubmit(userQuestion);
                TempData["notice"] = "Successfully Saved";
            }
            Db.SubmitChanges();
            // Taking the user back home
            return RedirectToAction("Index", "Home");
        }
        */
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
            var dataQuery = from table in Db.UserQuestions
                                      where table.AspNetUserId.Equals(System.Web.HttpContext.Current.User.Identity.GetUserId())
                                     select table;

            bool recordPresent = false;

            foreach (UserQuestion entry in dataQuery)
            {
                if (entry.AspNetUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    recordPresent = true;
                    entry.WakeUpFreshness = diaryDataSetupData.WakeUpFreshness;
                    entry.Mood = diaryDataSetupData.Mood;
                    entry.Stress = diaryDataSetupData.Stress;
                    entry.Tiredness = diaryDataSetupData.Tiredness;
                    entry.Dream = diaryDataSetupData.Dream;
                    entry.SchoolQuestions = diaryDataSetupData.SchoolQuestions;
                    entry.CoffeeQuestions = diaryDataSetupData.CoffeeQuestions;
                    entry.AlcoholQuestions = diaryDataSetupData.AlcoholQuestions;
                    entry.NapQuestions = diaryDataSetupData.NapQuestions;
                    entry.DigDeviceDurationQuestion = diaryDataSetupData.DigDeviceDurationQuestion;
                    entry.GameDurationQuestion = diaryDataSetupData.GameDurationQuestion;
                    entry.SocialMediaDurationQuestion = diaryDataSetupData.SocialMediaDurationQuestion;
                    entry.SocialActivityDurationQuestion = diaryDataSetupData.SocialActivityDurationQuestion;
                    entry.MusicDurationQuestion = diaryDataSetupData.MusicDurationQuestion;
                    entry.TVDurationQuestion = diaryDataSetupData.TVDurationQuestion;
                    entry.WorkQuestions = diaryDataSetupData.WorkQuestions;
                    entry.ExersiseQuestions = diaryDataSetupData.ExersiseQuestions;
                    entry.FoodQuestions = diaryDataSetupData.FoodQuestions;
                    entry.GenderHormoneQuestion = entry.GenderHormoneQuestion;
                }
            }

                UserQuestion newValue = new UserQuestion()
                {
                    AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                    WakeUpFreshness = diaryDataSetupData.WakeUpFreshness,
                    Mood = diaryDataSetupData.Mood,
                    Stress = diaryDataSetupData.Stress,
                    Tiredness = diaryDataSetupData.Tiredness,
                    Dream = diaryDataSetupData.Dream,
                    SchoolQuestions = diaryDataSetupData.SchoolQuestions,
                    CoffeeQuestions = diaryDataSetupData.CoffeeQuestions,
                    AlcoholQuestions = diaryDataSetupData.AlcoholQuestions,
                    NapQuestions = diaryDataSetupData.NapQuestions,
                    DigDeviceDurationQuestion = diaryDataSetupData.DigDeviceDurationQuestion,
                    GameDurationQuestion = diaryDataSetupData.GameDurationQuestion,
                    SocialMediaDurationQuestion = diaryDataSetupData.SocialMediaDurationQuestion,
                    SocialActivityDurationQuestion = diaryDataSetupData.SocialActivityDurationQuestion,
                    MusicDurationQuestion = diaryDataSetupData.MusicDurationQuestion,
                    TVDurationQuestion = diaryDataSetupData.TVDurationQuestion,
                    WorkQuestions = diaryDataSetupData.WorkQuestions,
                    ExersiseQuestions = diaryDataSetupData.ExersiseQuestions,
                    FoodQuestions = diaryDataSetupData.FoodQuestions,
                    GenderHormoneQuestion = diaryDataSetupData.GenderHormoneQuestion
                };
            if (recordPresent == false)
            {
                Db.UserQuestions.InsertOnSubmit(newValue);
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
                    query.WakeUpFreshness = model.WakeUpFreshness;
                    query.Mood = model.Mood;
                    query.Stress = model.Stress;
                    query.Tiredness = model.Tiredness;
                    query.Dream = model.Dream;
                    query.BodyTemp = model.BodyTemp;
                    query.Hormone = model.Hormone;
                    query.SchoolStress = model.SchoolStress;
                    query.CoffeeAmt = model.CoffeeAmt;
                    query.CoffeeTime = model.CoffeeTime;
                    query.AlcoholAmt = model.AlcoholAmt;
                    query.AlcoholTime = model.AlcoholTime;
                    query.NapTime = model.NapTime;
                    query.NapDuration = model.NapDuration;
                    query.DigDeviceDuration = model.DigDeviceDuration;
                    query.GamesDuration = model.GamesDuration;
                    query.SocialActivites = model.SocialActivites;
                    query.SocialActivity = model.SocialActivity;
                    query.MusicDuration = model.MusicDuration;
                    query.TVDuration = model.TVDuration;
                    query.WorkTime = model.WorkTime;
                    query.WorkDuration = model.WorkDuration;
                    query.ExerciseDuration = model.ExerciseDuration;
                    query.ExerciseIntensity = model.ExerciseIntensity;
                    query.DinnerTime = model.DinnerTime;
                    query.SnackTime = model.SnackTime;
                }
            }
            //Updating the database if no match in date is found
            if (update == false)
            {
                //getting data, userID and time of save
                DiaryData dairyData = new DiaryData()
                {
                    AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                    DateStamp = dateNow,
                    WakeUpFreshness = model.WakeUpFreshness,
                    Mood = model.Mood,
                    Stress = model.Stress,
                    Tiredness = model.Tiredness,
                    Dream = model.Dream,
                    BodyTemp = model.BodyTemp,
                    Hormone = model.Hormone,
                    SchoolStress = model.SchoolStress,
                    CoffeeAmt = model.CoffeeAmt,
                    CoffeeTime = model.CoffeeTime,
                    AlcoholAmt = model.AlcoholAmt,
                    AlcoholTime = model.AlcoholTime,
                    NapTime = model.NapTime,
                    NapDuration = model.NapDuration,
                    DigDeviceDuration = model.DigDeviceDuration,
                    GamesDuration = model.GamesDuration,
                    SocialActivites = model.SocialActivites,
                    SocialActivity = model.SocialActivity,
                    MusicDuration = model.MusicDuration,
                    TVDuration = model.TVDuration,
                    WorkTime = model.WorkTime,
                    WorkDuration = model.WorkDuration,
                    ExerciseDuration = model.ExerciseDuration,
                    ExerciseIntensity = model.ExerciseIntensity,
                    DinnerTime = model.DinnerTime,
                    SnackTime = model.SnackTime
                };
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
