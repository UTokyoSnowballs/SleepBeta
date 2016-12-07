using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;//
using System.Data.Sql;

using Excel = Microsoft.Office.Interop.Excel;

//Refer to Fitbit Library

using Fitbit.Models;
using SleepMakeSense.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

//Refer to MathNet.Numerics Library for statistical analysis
using MathNet.Numerics.Statistics;


namespace SleepMakeSense.Controllers
{
    
    public class UserdatasController : Controller
    {

        // 20161105 Pandita
        // private ApplicationDbContext db = new ApplicationDbContext();
        private SleepbetaDataContext Db = new SleepbetaDataContext();
        

        /*
        // GET: Userdatas
        public ActionResult Index()
        {
            // 20161107 Pandita
            // return View(db.Userdatas.ToList());
            return View(Db.Userdatas.ToList());

        }

        // GET: Userdatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // GET: Userdatas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult FactorList()
        {
            return View("FactorList");
        }

        // POST: Userdatas/Create
        // To prevent excessive posting attack , please enable the specific property to be bound to.
        // For more information , http: Please refer to the //go.microsoft.com/fwlink/ LinkId = 317598?.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, AwakeningsCount, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialActivity,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
        {
            var data = userdata;
            if (ModelState.IsValid)
            {
                // 20161107 Pandita
                // db.Userdatas.Add(data);
                // db.SaveChanges();

                Db.Userdatas.Add(data);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdata);
        }

        // GET: Userdatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: Userdatas/Edit/5
        // To prevent excessive posting attack , please enable the specific property to be bound to 
        // For more information , http: Please refer to the //go.microsoft.com/fwlink/ LinkId = 317598?.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, AwakeningsCount, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialActivity,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                // 20161107 Pandita
                // db.Entry(userdata).State = EntityState.Modified;
                // db.SaveChanges();

                Db.Entry(userdata).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdata);
        }

        // GET: Userdatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }
       
        // POST: Userdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            // db.Userdatas.Remove(userdata);
            // db.SaveChanges();

            var userdata = Db.Userdatas.Find(id);
            Db.Userdatas.Remove(userdata);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
         */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 20161107 Pandita
                // db.Dispose();
                Db.Dispose();

            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        private FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
        {
            if (Session["FitbitClient"] == null)
            {
                if (accessToken != null)
                {
                    var appCredentials = (FitbitAppCredentials)Session["AppCredentials"];
                    FitbitClient client = new FitbitClient(appCredentials, accessToken);
                    Session["FitbitClient"] = client;
                    return client;
                }
                else
                {
                    throw new Exception("First time requesting a FitbitClient from the session you must pass the AccessToken.");
                }

            }
            else
            {
                return (FitbitClient)Session["FitbitClient"];
            }
        }
   
        private async Task<ActionResult> FitbitDataSync(string userId )
        {

                // Step 1: Retrieve 40 days data and store in "results"
            FitbitClient client = GetFitbitClient();
            int dateStopNumber = 40;
   
            bool userLogedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            IEnumerable<FitbitData> lastSyncedData = from table in Db.FitbitDatas
                                where table.AspNetUserId.Equals(userId) && table.DateStamp >= DateTime.UtcNow.Date.AddDays(-dateStopNumber)
                                 orderby table.DateStamp
                                select table;


            //Getting a list of all the missing data
            List<DateTime> lastSyncedDate = new List<DateTime>();

            for (int i = 0; i >= dateStopNumber; i++)
            {
                bool dayExists = false;
                DateTime iDay = DateTime.UtcNow.Date.AddDays(i - dateStopNumber);
                foreach (FitbitData fitbitData in lastSyncedData)
                {
                    if (iDay == fitbitData.DateStamp)
                    {
                        dayExists = true;
                    }
                }
                if (dayExists != true)
                {
                    lastSyncedDate.Add(iDay);
                }
            }

            DateTime dateStop = lastSyncedDate.Min();
            List<FitbitData> fitbitInputDatas = new List<FitbitData>();



            //Each set is 1 call - calling 40 or 60 only increase the size by a small amount
            //21 calls
                var minutesAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAsleep, dateStop, DateTime.UtcNow);
                var minutesAwake = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAwake, dateStop, DateTime.UtcNow);
                var awakeningsCount = await client.GetTimeSeriesAsync(TimeSeriesResourceType.AwakeningsCount, dateStop, DateTime.UtcNow);
                var timeInBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeInBed, dateStop, DateTime.UtcNow);
                var minutesToFallAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesToFallAsleep, dateStop, DateTime.UtcNow);
                var minutesAfterWakeup = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAfterWakeup, dateStop, DateTime.UtcNow);
                var sleepEfficiency = await client.GetTimeSeriesAsync(TimeSeriesResourceType.SleepEfficiency, dateStop, DateTime.UtcNow);
                var caloriesIn = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesIn, dateStop, DateTime.UtcNow);
                var water = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Water, dateStop, DateTime.UtcNow);
                var caloriesOut = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesOut, dateStop, DateTime.UtcNow);
                var steps = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Steps, dateStop, DateTime.UtcNow);
                var distance = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Distance, dateStop, DateTime.UtcNow);
                var minutesSedentary = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesSedentary, dateStop, DateTime.UtcNow);
                var minutesLightlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesLightlyActive, dateStop, DateTime.UtcNow);
                var minutesFairlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesFairlyActive, dateStop, DateTime.UtcNow);
                var minutesVeryActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesVeryActive, dateStop, DateTime.UtcNow);
                var activityCalories = await client.GetTimeSeriesAsync(TimeSeriesResourceType.ActivityCalories, dateStop, DateTime.UtcNow);
                var timeEnteredBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeEnteredBed, dateStop, DateTime.UtcNow);
                var weight = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Weight, dateStop, DateTime.UtcNow);
                var bmi = await client.GetTimeSeriesAsync(TimeSeriesResourceType.BMI, dateStop, DateTime.UtcNow);
                var fat = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Fat, dateStop, DateTime.UtcNow);

                foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAsleep.DataList)
                {

                    if (Convert.ToDouble(data.Value) > 0)  // Remove entries with no sleep log (e.g. due to battery issue)
                    {
                    fitbitInputDatas.Add(new FitbitData()
                        {
                            DateStamp = data.DateTime.Date.AddDays(-1),
                            MinutesAsleep = data.Value,
                            MinutesAwake = null,
                            AwakeningsCount = null,
                            TimeInBed = null,
                            MinutesToFallAsleep = null,
                            MinutesAfterWakeup = null,
                            SleepEfficiency = null,
                            CaloriesIn = null,
                            Water = null,
                            CaloriesOut = null,
                            Steps = null,
                            Distance = null,
                            MinutesSedentary = null,
                            MinutesLightlyActive = null,
                            MinutesFairlyActive = null,
                            MinutesVeryActive = null,
                            ActivityCalories = null,
                            TimeEnteredBed = null,
                            Weight = null,
                            BMI = null,
                            Fat = null,
                            AspNetUserId = userId
                        });
                    }
                }
                

                foreach (FitbitData fitbitInputData in fitbitInputDatas)
                {
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAwake.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesAwake = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in awakeningsCount.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.AwakeningsCount = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in timeInBed.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.TimeInBed = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesToFallAsleep.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesToFallAsleep = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAfterWakeup.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesAfterWakeup = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in sleepEfficiency.DataList.Where(data => data.DateTime.AddDays(-1) == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.SleepEfficiency = data.Value;
                    }

                    // Potential impacting factors; need filter out untracked factors.
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in caloriesIn.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.CaloriesIn = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in water.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.Water = data.Value;
                    }
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in caloriesOut.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.CaloriesOut = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in steps.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.Steps = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in distance.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.Distance = data.Value;
                    }


                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesSedentary.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesSedentary = data.Value;
                        //if (Convert.ToDouble(item.MinutesSedentary) > 0) CNTminutesSedentary++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesLightlyActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesLightlyActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesLightlyActive) > 0) CNTminutesLightlyActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesFairlyActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesFairlyActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesFairlyActive) > 0) CNTminutesFairlyActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesVeryActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.MinutesVeryActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesVeryActive) > 0) CNTminutesVeryActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in activityCalories.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.ActivityCalories = data.Value;
                        //if (Convert.ToDouble(item.ActivityCalories) > 0) CNTactivityCalories++; 
                    }


                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in timeEnteredBed.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.TimeEnteredBed = data.Value;
                        //if (Convert.ToDouble(item.TimeEnteredBed) > 0) CNTtimeEnteredBed++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in weight.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.Weight = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in bmi.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.BMI = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in fat.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                    fitbitInputData.Fat = data.Value;
                    }
                }
            //Comparing Saved data with new data


            Db.FitbitDatas.InsertAllOnSubmit(fitbitInputDatas);

            Db.SubmitChanges();
            ViewBag.FitbitSynced = true; 

            return View();
        }

        public async Task<ActionResult> Sync()
        {

            /* Todo: Pandita 
             * // Sean -- Good idea :)
             * We could use the View Model instead
            if (ViewBag.FitbitSynced == true) {
                //NoDataSync();
                return View("Sync");
            }
            else
            {*/

                //Comment out the bellow line to disable getting the current logged in user data
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                //UnComment the bellow line to select a specific use to show the users sync page screen
                //string userId = "862a567a-a845-4d48-a2c2-91b2e7627924";


                //Enable Fitbit Data SYNC
                await FitbitDataSync(userId);
                //Retrieves the Data
                 
                MyViewModel model = DataModelCreation(UserDatas(userId));
                return View(model);
            
        }

        public ActionResult NoDataSync()
        {
            return View("Sync");
        }

        /// <summary>
        /// Handels all data retrieval and outputs the user data
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        private List<Userdata> UserDatas(string userId)
        {
            //Item Stup
            DateTime dateStop = DateTime.UtcNow.AddDays(-40);
            List<Userdata> userDatas = new List<Userdata>();

            //Data retieval
            var diaryDatas = from table in Db.DiaryDatas
                             where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                             orderby table.DateStamp
                             select table;

            var fitbitDatas = from table in Db.FitbitDatas
                              where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                              orderby table.DateStamp
                              select table;

            foreach (FitbitData fitbitData in fitbitDatas)
            {
                if (Convert.ToDouble(fitbitData.MinutesAsleep) > 0)  // Remove entries with no sleep log (e.g. due to battery issue)
                {
                    userDatas.Add(new Userdata
                    {
                        DateStamp = fitbitData.DateStamp,
                   //     AspNetUserId = fitbitData.AspNetUserId,
                        FitbitData = fitbitData
                    });
                }
            }
            foreach (Userdata userdata in userDatas)
            {
                foreach (DiaryData diaryData in diaryDatas.Where(diaryData => diaryData.DateStamp == userdata.FitbitData.DateStamp))
                {
                    userdata.DiaryData = diaryData;
                }
            }
            return userDatas;
        }


        public MyViewModel DataModelCreation(List<Userdata> userDatas)
        {
            /*Fixing the data to make it easier to work on in the future.
             * Thinking of making this into a differnt class and splitting it into smaller methods as alot of the code is repetitive
             * Just need to figure out a way to be able to subsite the variable in the code and change to a different varible on each run
             * EG.. steps, then go to distance and use the same generic code
             * It could be split into 3 types, int, time and bool
             * 
             * Update on this thought - should the wakeup freashness be redesigned?
            */

            //Part of the redesign - this will allow the datamining method to flick through all of the classes with less commplication

            MyViewModel viewModel = new MyViewModel();
            ViewBag.FitbitSynced = true;

            //Fitbit Data Counters
            int CNTSteps = 0, CNTDistance = 0, CNTMinutesSedentary = 0, CNTMinutesLightlyActive = 0,
                CNTMinutesFairlyActive = 0, CNTMinutesVeryActive = 0, CNTWater = 0,
                CNTCaloriesOut = 0, CNTActivityCalories = 0, CNTWeight = 0, CNTBMI = 0, CNTFat = 0, CNTCaloriesIn = 0;


            //Diary Data Counters
            int CNTWakeUpFreshness = 0, CNTMood = 0, CNTStress = 0, CNTTiredness = 0,
                CNTDream = 0, CNTBodyTemp = 0, CNTHormone = 0,
                CNTSchoolStress = 0,
                CNTCoffeeAmt = 0, CNTCoffeeTime = 0, CNTAlcoholAmt = 0, CNTAlcoholTime = 0,
                CNTNapTime = 0, CNTNapDuration = 0,
                CNTDigDeviceDuration = 0, CNTGamesDuration = 0, CNTSocialActivites = 0, CNTSocialActivity = 0, CNTSocialMediaActivity = 0, CNTMusicDuration = 0, CNTTVDuration = 0,
                CNTWorkTime = 0, CNTWorkDuration = 0, CNTExerciseDuration = 0, CNTExerciseIntensity = 0,
                CNTDinnerTime = 0, CNTSnackTime = 0,
                CNTAmbientTemp = 0, CNTAmbientHumd = 0, CNTLight = 0, CNTSunRiseTime = 0, CNTSunSetTime = 0;

            foreach (Userdata userData in userDatas)
            {
                //Fitbit Data Counter
                if (Convert.ToDouble(userData.FitbitData.Steps) > 0) CNTSteps++;
                if (Convert.ToDouble(userData.FitbitData.Distance) >= 0) CNTDistance++;
                if (Convert.ToDouble(userData.FitbitData.MinutesSedentary) > 0) CNTMinutesSedentary++;
                if (Convert.ToDouble(userData.FitbitData.MinutesLightlyActive) > 0) CNTMinutesLightlyActive++;
                if (Convert.ToDouble(userData.FitbitData.MinutesFairlyActive) > 0) CNTMinutesFairlyActive++;
                if (Convert.ToDouble(userData.FitbitData.MinutesVeryActive) > 0) CNTMinutesVeryActive++;
                if (Convert.ToDouble(userData.FitbitData.Water) > 0) CNTWater++;
                if (Convert.ToDouble(userData.FitbitData.CaloriesIn) >= 0) CNTCaloriesIn++;
                if (Convert.ToDouble(userData.FitbitData.CaloriesOut) > 0) CNTCaloriesOut++;
                if (Convert.ToDouble(userData.FitbitData.ActivityCalories) > 0) CNTActivityCalories++;
                if (Convert.ToDouble(userData.FitbitData.Weight) > 0) CNTWeight++;
                if (Convert.ToDouble(userData.FitbitData.BMI) > 0) CNTBMI++;
                if (Convert.ToDouble(userData.FitbitData.Fat) > 0) CNTFat++;

                //Diary Data Counter
                if (Convert.ToDouble(userData.DiaryData.WakeUpFreshness) > 0) CNTWakeUpFreshness++;
                if (Convert.ToDouble(userData.DiaryData.Mood) >= 0) CNTMood++;
                if (Convert.ToDouble(userData.DiaryData.Stress) > 0) CNTStress++;
                if (Convert.ToDouble(userData.DiaryData.Tiredness) > 0) CNTTiredness++;
                if (Convert.ToDouble(userData.DiaryData.Dream) > 0) CNTDream++;
                if (Convert.ToDouble(userData.DiaryData.BodyTemp) > 0) CNTBodyTemp++;
                if (Convert.ToDouble(userData.DiaryData.Hormone) > 0) CNTHormone++;
                if (Convert.ToDouble(userData.DiaryData.SchoolStress) > 0) CNTSchoolStress++;
                if (Convert.ToDouble(userData.DiaryData.CoffeeAmt) >= 0) CNTCoffeeAmt++;
                if (Convert.ToDateTime(userData.DiaryData.CoffeeTime) != null) CNTCoffeeTime++;
                if (Convert.ToDouble(userData.DiaryData.AlcoholAmt) > 0) CNTAlcoholAmt++;
                if (Convert.ToDateTime(userData.DiaryData.AlcoholTime) != null) CNTAlcoholTime++;
                if (Convert.ToDateTime(userData.DiaryData.NapTime) != null) CNTNapTime++;
                if (Convert.ToDouble(userData.DiaryData.NapDuration) > 0) CNTNapDuration++;
                if (Convert.ToDouble(userData.DiaryData.DigDeviceDuration) > 0) CNTDigDeviceDuration++;
                if (Convert.ToDouble(userData.DiaryData.GamesDuration) > 0) CNTGamesDuration++;
                if (Convert.ToDouble(userData.DiaryData.SocialActivites) > 0) CNTSocialActivites++;
                if (Convert.ToDouble(userData.DiaryData.SocialActivity) > 0) CNTSocialActivity++;
                // if (Convert.ToDouble(userData.DiaryData.SocialMediaActivity) > 0) CNTSocialMediaActivity++;  Need to Fix the DB and the view for this one
                if (Convert.ToDouble(userData.DiaryData.MusicDuration) >= 0) CNTMusicDuration++;
                if (Convert.ToDouble(userData.DiaryData.TVDuration) > 0) CNTTVDuration++;
                if (Convert.ToDateTime(userData.DiaryData.WorkTime) != null) CNTWorkTime++;
                if (Convert.ToDouble(userData.DiaryData.ExerciseDuration) > 0) CNTExerciseDuration++;
                if (Convert.ToDouble(userData.DiaryData.ExerciseIntensity) > 0) CNTExerciseIntensity++;
                if (Convert.ToDateTime(userData.DiaryData.DinnerTime) != null) CNTDinnerTime++;
                if (Convert.ToDateTime(userData.DiaryData.SnackTime) != null) CNTSnackTime++;
                if (Convert.ToDouble(userData.DiaryData.AmbientTemp) > 0) CNTAmbientTemp++;
                if (Convert.ToDouble(userData.DiaryData.AmbientHumd) > 0) CNTAmbientHumd++;
                if (Convert.ToDouble(userData.DiaryData.Light) > 0) CNTLight++;
                if (Convert.ToDateTime(userData.DiaryData.SunRiseTime) != null) CNTSunRiseTime++;
                if (Convert.ToDateTime(userData.DiaryData.SunSetTime) != null) CNTSunSetTime++;

            }


            int countOfDaysData = userDatas.Count;

            List<CorrList> CoefficientList = new List<CorrList>();

            double[] MinutesAsleep = new double[countOfDaysData];
            double[] MinutesAwake = new double[countOfDaysData];
            double[] AwakeningsCount = new double[countOfDaysData];
            double[] MinutesToFallAsleep = new double[countOfDaysData];
            double[] SleepEfficiency = new double[countOfDaysData];

            double[] MinutesSedentary = new double[countOfDaysData];
            double[] MinutesLightlyActive = new double[countOfDaysData];
            double[] MinutesFairlyActive = new double[countOfDaysData];
            double[] MinutesVeryActive = new double[countOfDaysData];

            // should correlate to all tracked factors, including the ones tracked using diary  
                
            //No idea what this is ment to do :/ - Sean
            double[] WakeUpFreshnessSteps = new double[CNTSteps];
            double[] WakeUpFreshnessDistance = new double[CNTDistance];
            double[] WakeUpFreshnessMinutesSedentary = new double[CNTMinutesSedentary];
            double[] WakeUpFreshnessMinutesLightlyActive = new double[CNTMinutesLightlyActive];
            double[] WakeUpFreshnessMinutesFairlyActive = new double[CNTMinutesFairlyActive];
            double[] WakeUpFreshnessMinutesVeryActive = new double[CNTMinutesVeryActive];
            double[] WakeUpFreshnessWater = new double[CNTWater];
            double[] WakeUpFreshnessCaloriesIn = new double[CNTCaloriesIn];
            double[] WakeUpFreshnessCaloriesOut = new double[CNTCaloriesOut];
            double[] WakeUpFreshnessActivityCalories = new double[CNTActivityCalories];
            double[] WakeUpFreshnessWeight = new double[CNTWeight];
            double[] WakeUpFreshnessBMI = new double[CNTBMI];
            double[] WakeUpFreshnessFat = new double[CNTFat];

            double[] WakeUpFreshnessMood = new double[CNTMood];
            double[] WakeUpFreshnessStress = new double[CNTStress];
            double[] WakeUpFreshnessTiredness = new double[CNTTiredness];
            double[] WakeUpFreshnessDream = new double[CNTDream];
            double[] WakeUpFreshnessBodyTemp = new double[CNTBodyTemp];
            double[] WakeUpFreshnessHormone = new double[CNTHormone];
            double[] WakeUpFreshnessSchoolStress = new double[CNTHormone];
            double[] WakeUpFreshnessCoffeeAmt = new double[CNTCoffeeAmt];
            double[] WakeUpFreshnessCoffeeTime = new double[CNTCoffeeTime];
            double[] WakeUpFreshnessAlcoholAmt = new double[CNTAlcoholAmt];
            double[] WakeUpFreshnessAlcoholTime = new double[CNTAlcoholTime];
            double[] WakeUpFreshnessNapTime = new double[CNTNapTime];
            double[] WakeUpFreshnessNapDuration = new double[CNTNapDuration];
            double[] WakeUpFreshnessDigDeviceDuration = new double[CNTDigDeviceDuration];
            double[] WakeUpFreshnessGamesDuration = new double[CNTGamesDuration];
            double[] WakeUpFreshnessSocialActivites = new double[CNTSocialActivites];
            double[] WakeUpFreshnessSocialActivity = new double[CNTSocialActivity];
            double[] WakeUpFreshnessMusicDuration = new double[CNTMusicDuration];
            double[] WakeUpFreshnessTVDuration = new double[CNTTVDuration];
            double[] WakeUpFreshnessWorkTime = new double[CNTWorkTime];
            double[] WakeUpFreshnessWorkDuration = new double[CNTWorkDuration];
            double[] WakeUpFreshnessExerciseDuration = new double[CNTExerciseDuration];
            double[] WakeUpFreshnessExerciseIntensity = new double[CNTExerciseIntensity];
            double[] WakeUpFreshnessDinnerTime = new double[CNTDinnerTime];
            double[] WakeUpFreshnessSnackTime = new double[CNTSnackTime];
            double[] WakeUpFreshnessAmbientTemp = new double[CNTAmbientTemp];
            double[] WakeUpFreshnessAmbientHumd = new double[CNTAmbientHumd];
            double[] WakeUpFreshnessLight = new double[CNTLight];
            double[] WakeUpFreshnessSunRiseTime = new double[CNTSunRiseTime];
            double[] WakeUpFreshnessSunSetTime = new double[CNTSunSetTime];


            //Temp Values
            //Fitbit
            double[] tmpSteps = new double[CNTSteps];
            double[] tmpDistance = new double[CNTDistance];
            double[] tmpMinutesSedentary = new double[CNTMinutesSedentary];
            double[] tmpMinutesLightlyActive = new double[CNTMinutesLightlyActive];
            double[] tmpMinutesFairlyActive = new double[CNTMinutesFairlyActive];
            double[] tmpMinutesVeryActive = new double[CNTMinutesVeryActive];
            double[] tmpWater = new double[CNTWater];
            double[] tmpCaloriesIn = new double[CNTCaloriesIn];
            double[] tmpCaloriesOut = new double[CNTCaloriesOut];
            double[] tmpActivityCalories = new double[CNTActivityCalories];
            double[] tmpWeight = new double[CNTWeight];
            double[] tmpBMI = new double[CNTBMI];
            double[] tmpFat = new double[CNTFat];

            //Diary 
            double[] tmpMood = new double[CNTMood];
            double[] tmpStress = new double[CNTStress];
            double[] tmpTiredness = new double[CNTTiredness];
            double[] tmpDream = new double[CNTDream];
            double[] tmpBodyTemp = new double[CNTBodyTemp];
            double[] tmpHormone = new double[CNTHormone];
            double[] tmpSchoolStress = new double[CNTSchoolStress];
            double[] tmpCoffeeAmt = new double[CNTCoffeeAmt];
            double[] tmpCoffeeTime = new double[CNTCoffeeTime];
            double[] tmpAlcoholAmt = new double[CNTAlcoholAmt];
            double[] tmpAlcoholTime = new double[CNTAlcoholTime];
            double[] tmpNapTime = new double[CNTNapTime];
            double[] tmpNapDuration = new double[CNTNapDuration];
            double[] tmpDigDeviceDuration = new double[CNTDigDeviceDuration];
            double[] tmpGamesDuration = new double[CNTGamesDuration];
            double[] tmpSocialActivites = new double[CNTSocialActivites];
            double[] tmpSocialActivity = new double[CNTSocialActivity];
            double[] tmpMusicDuration = new double[CNTMusicDuration];
            double[] tmpTVDuration = new double[CNTTVDuration];
            double[] tmpWorkTime = new double[CNTWorkTime];
            double[] tmpWorkDuration = new double[CNTWorkDuration];
            double[] tmpExerciseDuration = new double[CNTExerciseDuration];
            double[] tmpExerciseIntensity = new double[CNTExerciseIntensity];
            double[] tmpDinnerTime = new double[CNTDinnerTime];
            double[] tmpSnackTime = new double[CNTSnackTime];
            double[] tmpAmbientTemp = new double[CNTAmbientTemp];
            double[] tmpAmbientHumd = new double[CNTAmbientHumd];
            double[] tmpLight = new double[CNTLight];
            double[] tmpSunRiseTime = new double[CNTSunRiseTime];
            double[] tmpSunSetTime = new double[CNTSunSetTime];



            //Fitbit Data incruments 
            int iMinutesAsleep = 0, iMinutesAwake = 0,
            iAwakeningsCount = 0, iMinutesToFallAsleep = 0, iSleepEfficiency = 0;

            int iSteps = 0, iDistance = 0, iMinutesSedentary = 0, iMinutesLightlyActive = 0,
                iMinutesFairlyActive = 0, iMinutesVeryActive = 0, iWater = 0,
                iCaloriesOut = 0, iActivityCalories = 0, iWeight = 0, iBMI = 0, iFat = 0, iCaloriesIn = 0;

            //Diary Data incruments
            int iWakeUpFreshness = 0, iMood = 0, iStress = 0, iTiredness = 0,
                iDream = 0, iBodyTemp = 0, iHormone = 0,
                iSchoolStress = 0,
                iCoffeeAmt = 0, iCoffeeTime = 0, iAlcoholAmt = 0, iAlcoholTime = 0,
                iNapTime = 0, iNapDuration = 0,
                iDigDeviceDuration = 0, iGamesDuration = 0, iSocialActivites = 0, iSocialActivity = 0, iSocialMediaActivity = 0, iMusicDuration = 0, iTVDuration = 0,
                iWorkTime = 0, iWorkDuration = 0, iExerciseDuration = 0, iExerciseIntensity = 0,
                iDinnerTime = 0, iSnackTime = 0,
                iAmbientTemp = 0, iAmbientHumd = 0, iLight = 0, iSunRiseTime = 0, iSunSetTime = 0;

            //int iFloors = 0;
            //int iTimeEnteredBed = 0;

            int iWakeUpFreshnessMinutesAsleep = 0, iWakeUpFreshnessMinutesAwake = 0,
                iWakeUpFreshnessAwakeningsCount = 0, iWakeUpFreshnessMinutesToFallAsleep = 0, iWakeUpFreshnessSleepEfficiency = 0;

            int iWakeUpFreshnessSteps = 0, iWakeUpFreshnessDistance = 0, iWakeUpFreshnessMinutesSedentary = 0, iWakeUpFreshnessMinutesLightlyActive = 0,
                iWakeUpFreshnessMinutesFairlyActive = 0, iWakeUpFreshnessMinutesVeryActive = 0, iWakeUpFreshnessWater = 0,
                iWakeUpFreshnessCaloriesOut = 0, iWakeUpFreshnessActivityCalories = 0, iWakeUpFreshnessWeight = 0, iWakeUpFreshnessBMI = 0, iWakeUpFreshnessFat = 0, iWakeUpFreshnessCaloriesIn = 0;

            //Diary Data incruments
            int iWakeUpFreshnessMood = 0, iWakeUpFreshnessStress = 0, iWakeUpFreshnessTiredness = 0,
                iWakeUpFreshnessDream = 0, iWakeUpFreshnessBodyTemp = 0, iWakeUpFreshnessHormone = 0,
                iWakeUpFreshnessSchoolStress = 0,
                iWakeUpFreshnessCoffeeAmt = 0, iWakeUpFreshnessCoffeeTime = 0, iWakeUpFreshnessAlcoholAmt = 0, iWakeUpFreshnessAlcoholTime = 0,
                iWakeUpFreshnessNapTime = 0, iWakeUpFreshnessNapDuration = 0,
                iWakeUpFreshnessDigDeviceDuration = 0, iWakeUpFreshnessGamesDuration = 0, iWakeUpFreshnessSocialActivites = 0, iWakeUpFreshnessSocialActivity = 0, iWakeUpFreshnessSocialMediaActivity = 0, iWakeUpFreshnessMusicDuration = 0, iWakeUpFreshnessTVDuration = 0,
                iWakeUpFreshnessWorkTime = 0, iWakeUpFreshnessWorkDuration = 0, iWakeUpFreshnessExerciseDuration = 0, iWakeUpFreshnessExerciseIntensity = 0,
                iWakeUpFreshnessDinnerTime = 0, iWakeUpFreshnessSnackTime = 0,
                iWakeUpFreshnessAmbientTemp = 0, iWakeUpFreshnessAmbientHumd = 0, iWakeUpFreshnessLight = 0, iWakeUpFreshnessSunRiseTime = 0, iWakeUpFreshnessSunSetTime = 0;



            foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
            {

                //Console.Write(item); //didnt work!!!
                // System.Diagnostics.Debug.Write(item.MinutesAsleep); // didnt work!!!!
                //System.Diagnostics.Trace.Write(item); // didnt work!!!!

                // ******** Add entry to DB !!! *************         

                // 20161105 Pandita: Not necessary here? 
                //No - Think it was left from Old code
                //Db.Userdatas.Add(item);

                MinutesAsleep[iMinutesAsleep++] = Convert.ToDouble(daysData.FitbitData.MinutesAsleep);
                MinutesAwake[iMinutesAwake++] = Convert.ToDouble(daysData.FitbitData.MinutesAwake);
                AwakeningsCount[iAwakeningsCount++] = Convert.ToDouble(daysData.FitbitData.AwakeningsCount);
                MinutesToFallAsleep[iMinutesToFallAsleep++] = Convert.ToDouble(daysData.FitbitData.MinutesToFallAsleep);
                SleepEfficiency[iSleepEfficiency++] = Convert.ToDouble(daysData.FitbitData.SleepEfficiency);

                MinutesSedentary[iMinutesSedentary++] = Convert.ToDouble(daysData.FitbitData.MinutesSedentary);
                MinutesLightlyActive[iMinutesLightlyActive++] = Convert.ToDouble(daysData.FitbitData.MinutesLightlyActive);
                MinutesFairlyActive[iMinutesFairlyActive++] = Convert.ToDouble(daysData.FitbitData.MinutesFairlyActive);
                MinutesVeryActive[iMinutesVeryActive++] = Convert.ToDouble(daysData.FitbitData.MinutesVeryActive);

                if (Convert.ToDouble(daysData.DiaryData.WakeUpFreshness ) > 0)
                {
                    //Fitbit Data
                    if (Convert.ToDouble(daysData.FitbitData.Steps) > 0)
                    {
                        WakeUpFreshnessSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.FitbitData.Steps);
                        iWakeUpFreshnessSteps++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.Distance) > 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpDistance[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.FitbitData.Distance);
                        iWakeUpFreshnessDistance++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.MinutesSedentary) > 0)
                    {
                        WakeUpFreshnessMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.FitbitData.MinutesSedentary);
                        iWakeUpFreshnessMinutesSedentary++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.MinutesLightlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesLightlyActive[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMinutesLightlyActive[iWakeUpFreshnessMinutesLightlyActive] = Convert.ToDouble(daysData.FitbitData.MinutesLightlyActive);
                        iWakeUpFreshnessMinutesLightlyActive++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.MinutesFairlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.FitbitData.MinutesFairlyActive);
                        iWakeUpFreshnessMinutesFairlyActive++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.MinutesVeryActive) >= 0)
                    {
                        WakeUpFreshnessMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.FitbitData.MinutesVeryActive);
                        iWakeUpFreshnessMinutesVeryActive++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.Water) >= 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.FitbitData.Water);
                        iWakeUpFreshnessWater++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.CaloriesIn) >= 0)
                    {
                        WakeUpFreshnessCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.FitbitData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.CaloriesOut) >= 0)
                    {
                        WakeUpFreshnessCaloriesOut[iWakeUpFreshnessCaloriesOut] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpCaloriesOut[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.FitbitData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.ActivityCalories) >= 0)
                    {
                        WakeUpFreshnessActivityCalories[iWakeUpFreshnessActivityCalories] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpActivityCalories[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.FitbitData.ActivityCalories);
                        iWakeUpFreshnessActivityCalories++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.Weight) > 0)
                    {
                        WakeUpFreshnessWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.FitbitData.Weight);
                        iWakeUpFreshnessWeight++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.Fat) > 0)
                    {
                        WakeUpFreshnessFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.FitbitData.Fat);
                        iWakeUpFreshnessFat++;
                    }
                    if (Convert.ToDouble(daysData.FitbitData.Fat) > 0)
                    {
                        WakeUpFreshnessBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.FitbitData.BMI);
                        iWakeUpFreshnessBMI++;
                    }
                    //Diary data
                    if (Convert.ToDouble(daysData.DiaryData.Mood) >= 0)
                    {
                        WakeUpFreshnessMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.DiaryData.Mood);
                        iWakeUpFreshnessMood++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.Stress) > 0)
                    {
                        WakeUpFreshnessStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.DiaryData.Stress);
                        iWakeUpFreshnessStress++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.Tiredness) >= 0)
                    {
                        WakeUpFreshnessTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.DiaryData.Tiredness);
                        iWakeUpFreshnessTiredness++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.Dream) >= 0)
                    {
                        WakeUpFreshnessDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.DiaryData.Dream);
                        iWakeUpFreshnessDream++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.BodyTemp) >= 0)
                    {
                        WakeUpFreshnessBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.DiaryData.BodyTemp);
                        iWakeUpFreshnessBodyTemp++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.Hormone) >= 0)
                    {
                        WakeUpFreshnessHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.DiaryData.Hormone);
                        iWakeUpFreshnessHormone++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.CoffeeAmt) >= 0)
                    {
                        WakeUpFreshnessCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.DiaryData.CoffeeAmt);
                        iWakeUpFreshnessCoffeeAmt++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.CoffeeTime) >= 0)
                    {
                        WakeUpFreshnessCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.DiaryData.CoffeeTime);
                        iWakeUpFreshnessCoffeeTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.AlcoholAmt) >= 0)
                    {
                        WakeUpFreshnessAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.DiaryData.AlcoholAmt);
                        iWakeUpFreshnessAlcoholAmt++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.AlcoholTime) >= 0)
                    {
                        WakeUpFreshnessAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.DiaryData.AlcoholTime);
                        iWakeUpFreshnessAlcoholTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.NapTime) > 0)
                    {
                        WakeUpFreshnessNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.DiaryData.NapTime);
                        iWakeUpFreshnessNapTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.NapDuration) >= 0)
                    {
                        WakeUpFreshnessNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.DiaryData.NapDuration);
                        iWakeUpFreshnessNapDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.DigDeviceDuration) > 0)
                    {
                        WakeUpFreshnessDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.DiaryData.DigDeviceDuration);
                        iWakeUpFreshnessDigDeviceDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.GamesDuration) > 0)
                    {
                        WakeUpFreshnessGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.DiaryData.GamesDuration);
                        iWakeUpFreshnessGamesDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.SocialActivites) > 0)
                    {
                        WakeUpFreshnessSocialActivites[iWakeUpFreshnessSocialActivites] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSocialActivites[iWakeUpFreshnessSocialActivites] = Convert.ToDouble(daysData.DiaryData.SocialActivites);
                        iWakeUpFreshnessSocialActivites++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.SocialActivity) > 0)
                    {
                        WakeUpFreshnessSocialActivity[iWakeUpFreshnessSocialActivity] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSocialActivity[iWakeUpFreshnessSocialActivity] = Convert.ToDouble(daysData.DiaryData.SocialActivity);
                        iWakeUpFreshnessSocialActivity++;
                    }



                    if (Convert.ToDouble(daysData.DiaryData.MusicDuration) > 0)
                    {
                        WakeUpFreshnessMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.DiaryData.MusicDuration);
                        iWakeUpFreshnessMusicDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.TVDuration) > 0)
                    {
                        WakeUpFreshnessTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.DiaryData.TVDuration);
                        iWakeUpFreshnessTVDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.WorkTime) > 0)
                    {
                        WakeUpFreshnessWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.DiaryData.WorkTime);
                        iWakeUpFreshnessWorkTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.WorkDuration) > 0)
                    {
                        WakeUpFreshnessWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.DiaryData.WorkDuration);
                        iWakeUpFreshnessWorkDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.ExerciseDuration) > 0)
                    {
                        WakeUpFreshnessExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.DiaryData.ExerciseDuration);
                        iWakeUpFreshnessExerciseDuration++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.ExerciseIntensity) > 0)
                    {
                        WakeUpFreshnessExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.DiaryData.ExerciseIntensity);
                        iWakeUpFreshnessExerciseIntensity++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.DinnerTime) > 0)
                    {
                        WakeUpFreshnessDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.DiaryData.DinnerTime);
                        iWakeUpFreshnessDinnerTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.SnackTime) > 0)
                    {
                        WakeUpFreshnessSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.DiaryData.SnackTime);
                        iWakeUpFreshnessSnackTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.AmbientTemp) > 0)
                    {
                        WakeUpFreshnessAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.DiaryData.AmbientTemp);
                        iWakeUpFreshnessAmbientTemp++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.AmbientHumd) > 0)
                    {
                        WakeUpFreshnessAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.DiaryData.AmbientHumd);
                        iWakeUpFreshnessAmbientHumd++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.Light) > 0)
                    {
                        WakeUpFreshnessLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.DiaryData.Light);
                        iWakeUpFreshnessLight++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.SunRiseTime) > 0)
                    {
                        WakeUpFreshnessSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.DiaryData.SunRiseTime);
                        iWakeUpFreshnessSunRiseTime++;
                    }
                    if (Convert.ToDouble(daysData.DiaryData.SunSetTime) > 0)
                    {
                        WakeUpFreshnessSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.DiaryData.WakeUpFreshness);
                        tmpSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.DiaryData.SunSetTime);
                        iWakeUpFreshnessSunSetTime++;
                    }
                }

            }

            // WakeUpFreshness
            double rWakeUpFreshness = 0;

            if (iWakeUpFreshnessSteps > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSteps, tmpSteps);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Wake Up Freshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "The more steps you walked, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "The more steps you walked, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesSedentary > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesSedentary, tmpMinutesSedentary);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "The more time you spent stationary, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "The more time you spent stationary, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesLightlyActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesLightlyActive, tmpMinutesLightlyActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "The more light exersise that you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "The more light exersise that you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesFairlyActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesFairlyActive, tmpMinutesFairlyActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "The more moderate exersise that you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "The more moderate exersise that you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesVeryActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesVeryActive, tmpMinutesVeryActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "The more intense exercise you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "The more intense exercise you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessWater > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessWater, tmpWater);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "The more water you had in the day, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "The more water you had in the day, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessCaloriesIn > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCaloriesIn, tmpCaloriesIn);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "The more you ate, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "The more you ate, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessCaloriesOut > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCaloriesOut, tmpCaloriesOut);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessActivityCalories > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessActivityCalories, tmpActivityCalories);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day from exercise, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day from exercise, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessWeight > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessWeight, tmpWeight);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "The more you weighted, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "The more you weighted, the more alert you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessBMI > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessBMI, tmpBMI);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "The higher your BMI was, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "The higher your BMI was, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessFat > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessFat, tmpFat);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "The more fat you had, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "The more fat you had, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            //Diary data
            if (iWakeUpFreshnessMood > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMood, tmpMood);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "The better your mood before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "The better your mood before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessStress > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessStress, tmpStress);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "The more Stressed you felt before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "The more Stressed you felt before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }

            if (iWakeUpFreshnessTiredness > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessTiredness, tmpTiredness);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "The more tired you felt before bed time, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "The more tired you felt before bed time, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessDream > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessDream, tmpDream);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "Dreaming makes you feel dizzy when woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "Dreaming makes you feel alert when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessBodyTemp > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessBodyTemp, tmpBodyTemp);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "The higher your body temperature was before bed time, the more alert you felt when you woke up in the morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "The higher your body temperature was before bed time, the less alert you felt when you woke up in the morning." });
                    }
                }
            }
            if (iWakeUpFreshnessHormone > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessHormone, tmpHormone);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "As the next period approaches, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "As the next period approaches, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessCoffeeAmt > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCoffeeAmt, tmpCoffeeAmt);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "The more coffee you had, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "The more coffee you had, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessCoffeeTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCoffeeTime, tmpCoffeeTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "The later you had coffee, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "The later you had coffee, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessAlcoholAmt > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessAlcoholAmt, tmpAlcoholAmt);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "The more Alcohol you had, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "The more Alcohol you had, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessAlcoholTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessAlcoholTime, tmpAlcoholTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "The later you had Alcohol, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "The later you had Alcohol, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessNapTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessNapTime, tmpNapTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "The later you had a nap, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "The later you had a nap, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessNapDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessNapDuration, tmpNapDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "The longer you had a nap, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "The longer you had a nap, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessDigDeviceDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessDigDeviceDuration, tmpDigDeviceDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "The heavier you used digital devices before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "The heavier you used digital devices before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessGamesDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessGamesDuration, tmpGamesDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "The heavier you played games before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "The heavier you played games before bed time, the more dizzy you felt when you woke up.." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialActivites > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialActivites, tmpSocialActivites);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "The more social activites you do before bed, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "The more social activites you do before bed, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialActivity > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialActivity, tmpSocialActivity);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "The heavier you were on social media before bed time, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "The heavier you were on social media before bed time, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessMusicDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMusicDuration, tmpMusicDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "The longer you had listened to Music, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "The longer you had listened to Music, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessTVDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessTVDuration, tmpTVDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "The longer you had watched TV, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "The longer you had watched TV, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessExerciseDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessExerciseDuration, tmpExerciseDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "The longer you Exercised, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "The longer you Exercised, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessExerciseIntensity > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessExerciseIntensity, tmpExerciseIntensity);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "The more intense you Exercised, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "The more intense you Exercised, you tend to feel more dizzy when you woke up." });
                    }
                }
            }

            // MinutesAsleep
            double rMinutesSedentary = Correlation.Pearson(MinutesAsleep, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Note = "The more sedentary your were, the longer you were asleep during night." });
                }
                else if (rMinutesSedentary < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Note = "The more sedentary your were, the shorter you were asleep during night." });
                }
            }

            double rMinutesLightlyActive = Correlation.Pearson(MinutesAsleep, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                { 
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Note = "The more light exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Note = "The more light exercise your did, the shorter you were asleep during night." });
                }
            }

            double rMinutesFairlyActive = Correlation.Pearson(MinutesAsleep, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise your did, the shorter you were asleep during night." });
                }
            }

            double rMinutesVeryActive = Correlation.Pearson(MinutesAsleep, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Note = "The more intense exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Note = "The more intense exercise your did, the shorter you were asleep during night." });
                }
            }

            // AwakeningsCount
            rMinutesSedentary = Correlation.Pearson(AwakeningsCount, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Note = "The more sedentary you were, the more often you were awake during night." });
                }
                else if (rMinutesSedentary < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Note = "The more sedentary you were, the less often you were awake during night." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(AwakeningsCount, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Note = "The more light exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Note = "The more light exercise you did, the less often you were awake during night." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(AwakeningsCount, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise you did, the less often you were awake during night." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(AwakeningsCount, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Note = "The more intense exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Note = "The more intense exercise you did, the less often you were awake during night." });
                }
            }

            // SleepEfficiency
            rMinutesSedentary = Correlation.Pearson(SleepEfficiency, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Note = "The more sedentary you were, the better you sleep efficiency was." });
                }
                else if (rMinutesSedentary < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Note = "The less sedentary you were, the better you sleep efficiency was." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(SleepEfficiency, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Note = "The more light exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Note = "The more light exercise you did, the worse you sleep efficiency was." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(SleepEfficiency, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Note = "The more moderate exercise you did, the worse you sleep efficiency was." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(SleepEfficiency, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Note = "The more intense exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Note = "The more intense exercise you did, the worse you sleep efficiency was." });
                }
            }



            // CaloriesIn - DONE!!! YEAH!!!
            int temp = 0, identifier = 0;
            double pearson = 0, tempValue = 0;
            if (CNTCaloriesIn > 4)
            {
                double[] CaloriesIn = new double[CNTCaloriesIn];
                double[] tempMinutesAsleepCalariesIn = new double[CNTCaloriesIn];
                double[] tempAwakeningsCountCalariesIn = new double[CNTCaloriesIn];
                double[] tempSleepEfficiencyCalariesIn = new double[CNTCaloriesIn];

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    
                       tempValue = Convert.ToDouble(daysData.FitbitData.CaloriesIn);
                    if (tempValue > 0)
                    {
                        CaloriesIn[temp] = tempValue;
                        tempMinutesAsleepCalariesIn[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountCalariesIn[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyCalariesIn[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the more often were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the less often were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CaloriesIn", Coefficient = pearson, Note = "The more calories you intook, the worse your sleep efficiency was." });
                    }
                }

            }

            // CaloriesOut -- DONE !!! YEAH !!!

            if (CNTCaloriesOut > 4)
            {
                double[] CaloriesOut = new double[CNTCaloriesOut];
                double[] tempMinutesAsleepCalariesOut = new double[CNTCaloriesOut];
                double[] tempAwakeningsCountCalariesOut = new double[CNTCaloriesOut];
                double[] tempSleepEfficiencyCalariesOut = new double[CNTCaloriesOut];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.FitbitData.CaloriesOut);
                    if (tempValue > 0)
                    {
                        CaloriesOut[temp] = tempValue;
                        tempMinutesAsleepCalariesOut[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountCalariesOut[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyCalariesOut[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the better you sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CaloriesOut", Coefficient = pearson, Note = "The more calories you output, the worse you sleep efficiency was." });
                    }
                }

            }

            // Water -- DONE YEAH!!

            if (CNTWater > 4)
            {
                double[] Water = new double[CNTWater];
                double[] tempMinutesAsleepWater = new double[CNTWater];
                double[] tempAwakeningsCountWater = new double[CNTWater];
                double[] tempSleepEfficiencyWater = new double[CNTWater];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.FitbitData.Water);
                    if (tempValue > 0)
                    {
                        Water[temp] = tempValue;
                        tempMinutesAsleepWater[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountWater[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyWater[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Water", Coefficient = pearson, Note = "The more water you drunk, the worse your sleep efficiency was." });
                    }
                }

            }

            // Steps -- DONE YEAH!!

            if (CNTSteps > 4)
            {
                double[] Steps = new double[CNTSteps];
                double[] tempMinutesAsleepSteps = new double[CNTSteps];
                double[] tempAwakeningsCountSteps = new double[CNTSteps];;
                double[] tempSleepEfficiencySteps = new double[CNTSteps];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.FitbitData.Steps);
                    if (tempValue > 0)
                    {
                        Steps[temp] = tempValue;
                        tempMinutesAsleepSteps[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountSteps[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencySteps[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencySteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Steps", Coefficient = pearson, Note = "The more steps you walked, the worse your sleep efficiency was." });
                    }
                }

            }

            // weight -- DONE YEAH!!

            if (CNTWeight > 4)
            {
                double[] Weight = new double[CNTWeight];
                double[] tempMinutesAsleepWeight = new double[CNTWeight];
                double[] tempAwakeningsCountWeight = new double[CNTWeight];
                double[] tempSleepEfficiencyWeight = new double[CNTWeight];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.FitbitData.Weight);
                    if (tempValue > 0)
                    {
                        Weight[temp] = tempValue;
                        tempMinutesAsleepWeight[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountWeight[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyWeight[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the less often you were awake during night." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Weight", Coefficient = pearson, Note = "The heavier your weight was, the worse your sleep efficiency was." });
                    }
                }

            }

            // Fat -- DONE YEAH!!

            if (CNTFat > 4)
            {
                double[] Fat = new double[CNTFat];
                double[] tempMinutesAsleepFat = new double[CNTFat];
                double[] tempAwakeningsCountFat = new double[CNTFat];
                double[] tempSleepEfficiencyFat = new double[CNTFat];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.FitbitData.Fat);
                    if (tempValue > 0)
                    {
                        Fat[temp] = tempValue;
                        tempMinutesAsleepFat[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountFat[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyFat[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Fat", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Fat", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Fat", Coefficient = pearson });
                }

            }



            // Coffee -- DONE YEAH!!

            if (CNTCoffeeAmt > 4)
            {
                double[] Coffee = new double[CNTCoffeeAmt];
                double[] tempMinutesAsleepCoffee = new double[CNTCoffeeAmt];
                double[] tempAwakeningsCountCoffee = new double[CNTCoffeeAmt];
                double[] tempSleepEfficiencyCoffee = new double[CNTCoffeeAmt];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.CoffeeAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.CoffeeAmt);
                        if (tempValue >= 0)
                        {
                            Coffee[temp] = tempValue;
                            tempMinutesAsleepCoffee[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountCoffee[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyCoffee[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Coffee", Coefficient = pearson, Note = "The more coffee you consumed during the day, the worse your sleep efficiency was." });
                    }
                }

            }



            // CoffeeTime -- DONE YEAH!!

            if (CNTCoffeeTime > 4)
            {
                double[] CoffeeTime = new double[CNTCoffeeTime];
                double[] tempMinutesAsleepCoffeeTime = new double[CNTCoffeeTime];
                double[] tempAwakeningsCountCoffeeTime = new double[CNTCoffeeTime];
                double[] tempSleepEfficiencyCoffeeTime = new double[CNTCoffeeTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.CoffeeTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.CoffeeTime);
                        if (tempValue > 0)
                        {
                            CoffeeTime[temp] = tempValue;
                            tempMinutesAsleepCoffeeTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountCoffeeTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyCoffeeTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the shorter time you were asleep during night." });
                        }
                        else if (pearson < 0)
                        {
                            CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the longer time you were asleep during night." });
                        }
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the less often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the more often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the worse your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "CoffeeTime", Coefficient = pearson, Note = "The earlier you drunk coffee, the better your sleep efficiency was." });
                    }
                }

            }

            // Alcohol -- DONE YEAH!!

            if (CNTAlcoholAmt > 4)
            {
                double[] Alcohol = new double[CNTAlcoholAmt];
                double[] tempMinutesAsleepAlcohol = new double[CNTAlcoholAmt];
                double[] tempAwakeningsCountAlcohol = new double[CNTAlcoholAmt];
                double[] tempSleepEfficiencyAlcohol = new double[CNTAlcoholAmt];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.AlcoholAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.AlcoholAmt);
                        if (tempValue >= 0)
                        {
                            Alcohol[temp] = tempValue;
                            tempMinutesAsleepAlcohol[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAlcohol[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAlcohol[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }

                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the less often you were awake during night." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Alcohol", Coefficient = pearson, Note = "The more alcohol you consumed, the worse your sleep efficiency was." });
                    }
                }

            }


            // Mood -- DONE YEAH!!

            if (CNTMood > 4)
            {
                double[] Mood = new double[CNTMood];
                double[] tempMinutesAsleepMood = new double[CNTMood];
                double[] tempAwakeningsCountMood = new double[CNTMood];
                double[] tempSleepEfficiencyMood = new double[CNTMood];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.Mood != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.Mood);
                        if (tempValue >= 0)
                        {
                            Mood[temp] = tempValue;
                            tempMinutesAsleepMood[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountMood[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyMood[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Mood", Coefficient = pearson, Note = "The happier you felt before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Mood", Coefficient = pearson, Note = "The happier you felt before bed time, the less minutes you were asleep." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Mood", Coefficient = pearson, Note = "The happier you felt before bed time, the more often you were awake during sleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Mood", Coefficient = pearson, Note = "The happier you felt before bed time, the less often you were awake during sleep." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Mood", Coefficient = pearson, Note = "The happier you felt before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Mood", Coefficient = pearson, Note = "Oops! The happier you felt before bed time, the worse your sleep efficiency was." });
                    }
                }

            }


            // Stress -- DONE YEAH!!

            if (CNTStress > 4)
            {
                double[] Stress = new double[CNTStress];
                double[] tempMinutesAsleepStress = new double[CNTStress];
                double[] tempAwakeningsCountStress = new double[CNTStress];
                double[] tempSleepEfficiencyStress = new double[CNTStress];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.Stress != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.Stress);
                        if (tempValue >= 0)
                        {
                            Stress[temp] = tempValue;
                            tempMinutesAsleepStress[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountStress[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyStress[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Stress", Coefficient = pearson, Note = "The more stressed you were, the more minutes you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Stress", Coefficient = pearson, Note = "The more stressed you were, the less minutes you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Stress", Coefficient = pearson, Note = "The more stressed you were, the more awakenings you had." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Stress", Coefficient = pearson, Note = "The more stressed you were, the less awakenings you had." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Stress", Coefficient = pearson, Note = "The more stressed you were, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Stress", Coefficient = pearson, Note = "The less stressed you were, the better your sleep efficiency was." });
                    }
                }

            }

            // Tiredness -- DONE YEAH!!

            if (CNTTiredness > 4)
            {
                double[] Tiredness = new double[CNTTiredness];
                double[] tempMinutesAsleepTiredness = new double[CNTTiredness];
                double[] tempAwakeningsCountTiredness = new double[CNTTiredness];
                double[] tempSleepEfficiencyTiredness = new double[CNTTiredness];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.Tiredness != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.Tiredness);
                        if (tempValue >= 0)
                        {
                            Tiredness[temp] = tempValue;
                            tempMinutesAsleepTiredness[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountTiredness[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyTiredness[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the less minutes you were asleep." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the more often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the less often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Tiredness", Coefficient = pearson, Note = "The more tired you were before bed time, the worse your sleep efficiency was." });
                    }
                }

            }



            // Dream -- DONE YEAH!!

            if (CNTDream > 4)
            {
                double[] Dream = new double[CNTDream];
                double[] tempMinutesAsleepDream = new double[CNTDream];
                double[] tempAwakeningsCountDream = new double[CNTDream];
                double[] tempSleepEfficiencyDream = new double[CNTDream];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.Dream != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.Dream);
                        if (tempValue >= 0)
                        {
                            Dream[temp] = tempValue;
                            tempMinutesAsleepDream[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDream[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDream[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the less minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the more minutes you were asleep." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the less often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the more often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the worse your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Dream", Coefficient = pearson, Note = "The more you dreamed, the better your sleep efficiency was." });
                    }
                }

            }

            // DigitalDev -- DONE YEAH!!

            if (CNTDigDeviceDuration > 4)
            {
                double[] DigitalDev = new double[CNTDigDeviceDuration];
                double[] tempMinutesAsleepDigitalDev = new double[CNTDigDeviceDuration];
                double[] tempAwakeningsCountDigitalDev = new double[CNTDigDeviceDuration];
                double[] tempSleepEfficiencyDigitalDev = new double[CNTDigDeviceDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.DigDeviceDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.DigDeviceDuration);
                        if (tempValue >= 0)
                        {
                            DigitalDev[temp] = tempValue;
                            tempMinutesAsleepDigitalDev[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDigitalDev[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDigitalDev[temp] = SleepEfficiency[identifier];
                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the less minutes you were asleep." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the more often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the less often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "DigitalDevices", Coefficient = pearson, Note = "The heavier you used digital devices before bed time, the worse your sleep efficiency was." });
                    }
                }

            }


            // NapDuration -- DONE YEAH!!

            if (CNTNapDuration > 4)
            {
                double[] NapDuration = new double[CNTNapDuration];
                double[] tempMinutesAsleepNapDuration = new double[CNTNapDuration];
                double[] tempAwakeningsCountNapDuration = new double[CNTNapDuration];
                double[] tempSleepEfficiencyNapDuration = new double[CNTNapDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.NapDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.NapDuration);
                        if (tempValue >= 0)
                        {
                            NapDuration[temp] = tempValue;
                            tempMinutesAsleepNapDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountNapDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyNapDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "NapDuration", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "NapDuration", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "NapDuration", Coefficient = pearson });
                }

            }


            // NapTime -- DONE YEAH!!

            if (CNTNapTime > 4)
            {
                double[] NapTime = new double[CNTNapTime];
                double[] tempMinutesAsleepNapTime = new double[CNTNapTime];
                double[] tempAwakeningsCountNapTime = new double[CNTNapTime];
                double[] tempSleepEfficiencyNapTime = new double[CNTNapTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.NapTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.NapTime);
                        if (tempValue > 0)
                        {
                            NapTime[temp] = tempValue;
                            tempMinutesAsleepNapTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountNapTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyNapTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "NapTime", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "NapTime", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "NapTime", Coefficient = pearson });
                }

            }

            // SocialActivity -- DONE YEAH!!

            if (CNTSocialActivity > 4)
            {
                double[] SocialActivity = new double[CNTSocialActivity];
                double[] tempMinutesAsleepSocialActivity = new double[CNTSocialActivity];
                double[] tempAwakeningsCountSocialActivity = new double[CNTSocialActivity];
                double[] tempSleepEfficiencySocialActivity = new double[CNTSocialActivity];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.SocialActivity != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.SocialActivity);
                        if (tempValue >= 0)
                        {
                            SocialActivity[temp] = tempValue;
                            tempMinutesAsleepSocialActivity[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialActivity[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialActivity[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialActivity, SocialActivity);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "SocialActivity", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialActivity, SocialActivity);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "SocialActivity", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialActivity, SocialActivity);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "SocialActivity", Coefficient = pearson });
                }

            }

            // DinnerTime -- DONE YEAH!!

            if (CNTDinnerTime > 4)
            {
                double[] DinnerTime = new double[CNTDinnerTime];
                double[] tempMinutesAsleepDinnerTime = new double[CNTDinnerTime];
                double[] tempAwakeningsCountDinnerTime = new double[CNTDinnerTime];
                double[] tempSleepEfficiencyDinnerTime = new double[CNTDinnerTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.DinnerTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.DinnerTime);
                        if (tempValue > 0)
                        {
                            DinnerTime[temp] = tempValue;
                            tempMinutesAsleepDinnerTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDinnerTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDinnerTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "DinnerTime", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "DinnerTime", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "DinnerTime", Coefficient = pearson });
                }

            }

            // ExerciseTime -- DONE YEAH!!

            if (CNTExerciseDuration > 4)
            {
                double[] ExerciseTime = new double[CNTExerciseDuration];
                double[] tempMinutesAsleepExerciseTime = new double[CNTExerciseDuration];
                double[] tempAwakeningsCountExerciseTime = new double[CNTExerciseDuration];
                double[] tempSleepEfficiencyExerciseTime = new double[CNTExerciseDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.ExerciseDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.ExerciseDuration);
                        if (tempValue > 0)
                        {
                            ExerciseTime[temp] = tempValue;
                            tempMinutesAsleepExerciseTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountExerciseTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyExerciseTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "ExerciseTime", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "ExerciseTime", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "ExerciseTime", Coefficient = pearson });
                }

            }


            // AmbientTemp -- DONE YEAH!!

            if (CNTAmbientTemp > 4)
            {
                double[] AmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesAsleepAmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesAwakeAmbientTemp = new double[CNTAmbientTemp];
                double[] tempAwakeningsCountAmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesToFallAsleepAmbientTemp = new double[CNTAmbientTemp];
                double[] tempSleepEfficiencyAmbientTemp = new double[CNTAmbientTemp];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.AmbientTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.AmbientTemp);
                        if (tempValue > 0)
                        {
                            AmbientTemp[temp] = tempValue;
                            tempMinutesAsleepAmbientTemp[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAmbientTemp[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAmbientTemp[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "AmbientTemp", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "AmbientTemp", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "AmbientTemp", Coefficient = pearson });
                }

            }


            // AmbientHumd -- DONE YEAH!!

            if (CNTAmbientHumd > 4)
            {
                double[] AmbientHumd = new double[CNTAmbientHumd];
                double[] tempMinutesAsleepAmbientHumd = new double[CNTAmbientHumd];
                double[] tempAwakeningsCountAmbientHumd = new double[CNTAmbientHumd];
                double[] tempSleepEfficiencyAmbientHumd = new double[CNTAmbientHumd];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.AmbientHumd != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.AmbientHumd);
                        if (tempValue > 0)
                        {
                            AmbientHumd[temp] = tempValue;
                            tempMinutesAsleepAmbientHumd[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAmbientHumd[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAmbientHumd[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "AmbientHumd", Coefficient = pearson });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "AmbientHumd", Coefficient = pearson });
                }



                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "AmbientHumd", Coefficient = pearson });
                }

            }


            // BodyTemp -- DONE YEAH!!

            if (CNTBodyTemp > 4)
            {
                double[] BodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesAsleepBodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesAwakeBodyTemp = new double[CNTBodyTemp];
                double[] tempAwakeningsCountBodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesToFallAsleepBodyTemp = new double[CNTBodyTemp];
                double[] tempSleepEfficiencyBodyTemp = new double[CNTBodyTemp];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.BodyTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.BodyTemp);
                        if (tempValue > 0)
                        {
                            BodyTemp[temp] = tempValue;
                            tempMinutesAsleepBodyTemp[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeBodyTemp[temp] = MinutesAwake[identifier];
                            tempAwakeningsCountBodyTemp[temp] = AwakeningsCount[identifier];
                            tempMinutesToFallAsleepBodyTemp[temp] = MinutesToFallAsleep[identifier];
                            tempSleepEfficiencyBodyTemp[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Body Temp", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Body Temp", Coefficient = pearson });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Body Temp", Coefficient = pearson });
                }

            }


            // Hormone -- DONE YEAH!!

            if (CNTHormone > 4)
            {
                double[] Hormone = new double[CNTHormone];
                double[] tempMinutesAsleepHormone = new double[CNTHormone];
                double[] tempMinutesAwakeHormone = new double[CNTHormone];
                double[] tempAwakeningsCountHormone = new double[CNTHormone];
                double[] tempMinutesToFallAsleepHormone = new double[CNTHormone];
                double[] tempSleepEfficiencyHormone = new double[CNTHormone];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.Hormone != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.Hormone);
                        if (tempValue > 0)
                        {
                            Hormone[temp] = tempValue;
                            tempMinutesAsleepHormone[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeHormone[temp] = MinutesAwake[identifier];
                            tempAwakeningsCountHormone[temp] = AwakeningsCount[identifier];
                            tempMinutesToFallAsleepHormone[temp] = MinutesToFallAsleep[identifier];
                            tempSleepEfficiencyHormone[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Hormone", Coefficient = pearson, Note = "As the next period approaches, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // WatchTV -- DONE YEAH!!

            if (CNTTVDuration > 4)
            {
                double[] WatchTV = new double[CNTTVDuration];
                double[] tempMinutesAsleepWatchTV = new double[CNTTVDuration];
                double[] tempAwakeningsCountWatchTV = new double[CNTTVDuration];
                double[] tempSleepEfficiencyWatchTV = new double[CNTTVDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.TVDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.TVDuration);
                        if (tempValue > 0)
                        {
                            WatchTV[temp] = tempValue;
                            tempMinutesAsleepWatchTV[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWatchTV[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWatchTV[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "WatchTV", Coefficient = pearson, Note = "As you watch more TV, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // ExerciseDuration -- DONE YEAH!!

            if (CNTExerciseIntensity > 4)
            {
                double[] ExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempMinutesAsleepExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempAwakeningsCountExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempSleepEfficiencyExerciseDuration = new double[CNTExerciseIntensity];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.ExerciseIntensity != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.ExerciseIntensity);
                        if (tempValue > 0)
                        {
                            ExerciseDuration[temp] = tempValue;
                            tempMinutesAsleepExerciseDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountExerciseDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyExerciseDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Exercise Duration", Coefficient = pearson, Note = "If your workout is longer, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // SnackTime -- DONE YEAH!!

            if (CNTSnackTime > 4)
            {
                double[] SnackTime = new double[CNTSnackTime];
                double[] tempMinutesAsleepSnackTime = new double[CNTSnackTime];
                double[] tempAwakeningsCountSnackTime = new double[CNTSnackTime];
                double[] tempSleepEfficiencySnackTime = new double[CNTSnackTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.SnackTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.SnackTime);
                        if (tempValue > 0)
                        {
                            SnackTime[temp] = tempValue;
                            tempMinutesAsleepSnackTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSnackTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySnackTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson});
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson});
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson});
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson});
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Snack Time", Name = "Exercise Duration", Coefficient = pearson });
                    }
                }

            }
            // WorkTime -- DONE YEAH!!

            if (CNTWorkTime > 4)
            {
                double[] WorkTime = new double[CNTWorkTime];
                double[] tempMinutesAsleepWorkTime = new double[CNTWorkTime];
                double[] tempAwakeningsCountWorkTime = new double[CNTWorkTime];
                double[] tempSleepEfficiencyWorkTime = new double[CNTWorkTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.WorkTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.WorkTime);
                        if (tempValue > 0)
                        {
                            WorkTime[temp] = tempValue;
                            tempMinutesAsleepWorkTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWorkTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWorkTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Work Time", Coefficient = pearson, Note = "When your work is later, your sleep efficiency tends to become worse." });
                    }
                }

            }
            // Work Duration -- DONE YEAH!!

            if (CNTWorkDuration > 4)
            {
                double[] WorkDuration = new double[CNTWorkDuration];
                double[] tempMinutesAsleepWorkDuration = new double[CNTWorkDuration];
                double[] tempAwakeningsCountWorkDuration = new double[CNTWorkDuration];
                double[] tempSleepEfficiencyWorkDuration = new double[CNTWorkDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.WorkDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.WorkDuration);
                        if (tempValue > 0)
                        {
                            WorkDuration[temp] = tempValue;
                            tempMinutesAsleepWorkDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWorkDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWorkDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Work Duration", Coefficient = pearson, Note = "Working longer, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // Music -- DONE YEAH!!

            if (CNTMusicDuration > 4)
            {
                double[] Music = new double[CNTMusicDuration];
                double[] tempMinutesAsleepMusic = new double[CNTMusicDuration];
                double[] tempAwakeningsCountMusic = new double[CNTMusicDuration];
                double[] tempSleepEfficiencyMusic = new double[CNTMusicDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.MusicDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.MusicDuration);
                        if (tempValue > 0)
                        {
                            Music[temp] = tempValue;
                            tempMinutesAsleepMusic[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountMusic[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyMusic[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Music", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Music", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Music", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Music", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Music", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Music", Coefficient = pearson });
                    }
                }

            }
            // Social Media-- DONE YEAH!!

            if (CNTSocialActivites > 4)
            {
                double[] SocialMedia = new double[CNTSocialActivites];
                double[] tempMinutesAsleepSocialMedia = new double[CNTSocialActivites];
                double[] tempAwakeningsCountSocialMedia = new double[CNTSocialActivites];
                double[] tempSleepEfficiencySocialMedia = new double[CNTSocialActivites];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.SocialActivites != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.SocialActivites);
                        if (tempValue > 0)
                        {
                            SocialMedia [temp] = tempValue;
                            tempMinutesAsleepSocialMedia[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialMedia[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialMedia[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Social Media", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Social Media", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Social Media", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Social Media", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Social Media", Name = "Social Media", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Social Media", Coefficient = pearson });
                    }
                }

            }


            // Social Media-- DONE YEAH!!

            if (CNTGamesDuration > 4)
            {
                double[] VideoGames = new double[CNTGamesDuration];
                double[] tempMinutesAsleepVideoGames = new double[CNTGamesDuration];
                double[] tempAwakeningsCountVideoGames = new double[CNTGamesDuration];
                double[] tempSleepEfficiencyVideoGames = new double[CNTGamesDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.GamesDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.GamesDuration);
                        if (tempValue > 0)
                        {
                            VideoGames[temp] = tempValue;
                            tempMinutesAsleepVideoGames[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountVideoGames[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyVideoGames[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Video Games", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Video Games", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Video Games", Coefficient = pearson });
                        }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Video Games", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Social Media", Name = "Video Games", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "SleepEfficiency", Name = "Video Games", Coefficient = pearson });
                    }
                }

            }

            // Social Media-- DONE YEAH!!

            if (CNTSchoolStress > 4)
            {
                double[] Assignments = new double[CNTSchoolStress];
                double[] tempMinutesAsleepAssignments = new double[CNTSchoolStress];
                double[] tempAwakeningsCountAssignments = new double[CNTSchoolStress];
                double[] tempSleepEfficiencyAssignments = new double[CNTSchoolStress];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DiaryData.SchoolStress != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DiaryData.SchoolStress);
                        if (tempValue > 0)
                        {
                            Assignments[temp] = tempValue;
                            tempMinutesAsleepAssignments[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAssignments[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAssignments[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "MinutesAsleep", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "AwakeningsCount", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Sleep Efficiency", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                    else if (pearson < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Sleep Efficiency", Name = "Assignments & Exams", Coefficient = pearson });
                    }
                }
            }


            foreach (var entry in CoefficientList)
            {
                entry.Coefficient = (entry.Coefficient + 1) / 2;

            }

            viewModel.Userdata = userDatas;
            viewModel.CorrCoefficient = CoefficientList;

            return viewModel;

        }   
    }    
}

