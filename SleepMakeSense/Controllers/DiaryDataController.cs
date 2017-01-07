﻿using System;
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
                                                      where table.AspNetUserId.Equals(userId) && table.DateStamp.Date == DateTime.UtcNow.Date
                                                   select table;

                bool todaysData = false;
                
                foreach (DiaryData diaryData in dataQuery)
                { 
                        viewModel.DiaryData = diaryData;
                        todaysData = true;
                }

                if (!todaysData)
                {
                    viewModel.DiaryData = new DiaryData() { AspNetUserId = userId };
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
            DateTime dateNow = DateTime.UtcNow;
            bool update = false;
            IEnumerable <DiaryData> lastSynced = from table in Db.DiaryDatas
                             where table.AspNetUserId.Equals(System.Web.HttpContext.Current.User.Identity.GetUserId()) && table.DateStamp == DateTime.UtcNow.Date
                                                 orderby table.DateStamp
                             select table;


            //checking for a previous entry from the same day
            foreach (DiaryData query in lastSynced)
            {
                    update = true;
                    query.DateStamp = dateNow;
                    query.WakeUpFreshness = model.DiaryData.WakeUpFreshness;
                    query.Mood = model.DiaryData.Mood;
                    query.Stress = model.DiaryData.Stress;
                    query.Tiredness = model.DiaryData.Tiredness;
                    query.Dream = model.DiaryData.Dream;
                    query.BodyTemp = model.DiaryData.BodyTemp;
                    query.Hormone = model.DiaryData.Hormone;
                    query.SchoolStress = model.DiaryData.SchoolStress;
                    query.CoffeeAmt = model.DiaryData.CoffeeAmt;
                    query.CoffeeTime = model.DiaryData.CoffeeTime;
                    query.AlcoholAmt = model.DiaryData.AlcoholAmt;
                    query.AlcoholTime = model.DiaryData.AlcoholTime;
                    query.NapTime = model.DiaryData.NapTime;
                    query.NapDuration = model.DiaryData.NapDuration;
                    query.DigDeviceDuration = model.DiaryData.DigDeviceDuration;
                    query.GamesDuration = model.DiaryData.GamesDuration;
                    query.SocialActivites = model.DiaryData.SocialActivites;
                    query.SocialActivity = model.DiaryData.SocialActivity;
                    query.MusicDuration = model.DiaryData.MusicDuration;
                    query.TVDuration = model.DiaryData.TVDuration;
                    query.WorkTime = model.DiaryData.WorkTime;
                    query.WorkDuration = model.DiaryData.WorkDuration;
                    query.ExerciseDuration = model.DiaryData.ExerciseDuration;
                    query.ExerciseIntensity = model.DiaryData.ExerciseIntensity;
                    query.DinnerTime = model.DiaryData.DinnerTime;
                    query.SnackTime = model.DiaryData.SnackTime;                
            }
            //Updating the database if no match in date is found
            if (!update)
            {
                model.DiaryData.DateStamp = dateNow;
                model.DiaryData.AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                Db.DiaryDatas.InsertOnSubmit(model.DiaryData);
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
