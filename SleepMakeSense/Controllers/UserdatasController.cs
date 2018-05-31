using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
//using System.Net;
//using System.Web;
using System.Web.Mvc;
//using System.Data.Sql;

//using Excel = Microsoft.Office.Interop.Excel;

//Refer to Fitbit Library
using Fitbit.Models;
using SleepMakeSense.Models;
using SleepMakeSense.DataAccessLayer;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

//Refer to MathNet.Numerics Library for statistical analysis
using MathNet.Numerics.Statistics;
using SleepMakeSense.Alglib;


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
        public ActionResult Create([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, MinutesAwake, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialFamily,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
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
        public ActionResult Edit([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, MinutesAwake, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialFamily,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
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

            var userdata = Db.Userdatas.Find(id);
            Db.Userdatas.Remove(userdata);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
         */

        // For releasing "unmanaged" resources(for example, sockets, file handles, Bitmap handles, etc), 
        // and if it's being called outside a finalizer (that's what the disposing flag signifies, BTW), 
        // for disposing other IDisposable objects it holds that are no longer useful. 
        // can be found throughout the .net framework
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
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
                //throw new Exception("Session Fitbit Client ID is empty")};
                return (FitbitClient)Session["FitbitClient"];
            }
        }

        private DateTime FindingDateStop(string userId)
        {
            // Pandita 20170824: going back too many days cause Gateway Timeout error? Then let's just go back 40 days
            // DateTime dateStop = DateTime.UtcNow.Date.AddDays(-365);
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-40);


            IEnumerable<FitbitData> lastSyncedData = from table in Db.FitbitData
                                                     where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                                                     select table;

            foreach (FitbitData daysData in lastSyncedData)
            {
                if (daysData.DateStamp >= dateStop) dateStop = daysData.DateStamp.AddDays(1);
            }
            return dateStop;
        }


        private async Task<ActionResult> FitbitDataSync(string userId)
        {

            FitbitClient client = GetFitbitClient();
            DateTime dateStop = FindingDateStop(userId);

            // 20170302 Pandita: use local time
            DateTime baseTime = DateTime.UtcNow;
            baseTime = DateTime.SpecifyKind(baseTime, DateTimeKind.Unspecified);

            TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time").GetUtcOffset(baseTime); // offset value is between -14.0 (towards easthemisphere) ~ 14.0 (towards westhemisphere)
            DateTimeOffset sourceTime = new DateTimeOffset(baseTime, -offset);
            DateTime dateNow = sourceTime.LocalDateTime;

            bool syncRequired = false;

            if (dateStop < dateNow)
            {
                syncRequired = true;
            }

            if (syncRequired)
            {
                List<FitbitData> fitbitInputDatas = new List<FitbitData>();

                //Each set is 1 call - calling 40 or 60 only increase the size by a small amount
                //21 calls
                var minutesAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAsleep, dateStop, dateNow);
                var minutesAwake = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAwake, dateStop, dateNow);
                var awakeningsCount = await client.GetTimeSeriesAsync(TimeSeriesResourceType.AwakeningsCount, dateStop, dateNow);
                var timeInBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeInBed, dateStop, dateNow);
                var minutesToFallAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesToFallAsleep, dateStop, dateNow);
                var minutesAfterWakeup = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAfterWakeup, dateStop, dateNow);
                var sleepEfficiency = await client.GetTimeSeriesAsync(TimeSeriesResourceType.SleepEfficiency, dateStop, dateNow);
                var caloriesIn = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesIn, dateStop, dateNow);
                var water = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Water, dateStop, dateNow);
                var caloriesOut = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesOut, dateStop, dateNow);
                var steps = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Steps, dateStop, dateNow);
                var distance = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Distance, dateStop, dateNow);
                var minutesSedentary = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesSedentary, dateStop, dateNow);
                var minutesLightlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesLightlyActive, dateStop, dateNow);
                var minutesFairlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesFairlyActive, dateStop, dateNow);
                var minutesVeryActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesVeryActive, dateStop, dateNow);
                var activityCalories = await client.GetTimeSeriesAsync(TimeSeriesResourceType.ActivityCalories, dateStop, dateNow);
                var timeEnteredBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeEnteredBed, dateStop, dateNow);
                var weight = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Weight, dateStop, dateNow);
                var bmi = await client.GetTimeSeriesAsync(TimeSeriesResourceType.BMI, dateStop, dateNow);
                //var fat = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Fat, dateStop, dateNow);

                foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAsleep.DataList)
                {

                    if (Convert.ToDouble(data.Value) > 0)  // Remove entries with no sleep log (e.g. due to battery issue)
                    {
                        fitbitInputDatas.Add(new FitbitData()
                        {
                            //Id = Guid.NewGuid(),
                            // DateStamp = data.DateTime.Date.AddDays(-1),
                            DateStamp = data.DateTime.Date, // In QUT study, participants will fill in the diary in the morning, not before going to bed. 
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
                            //Fat = null,
                            AspNetUserId = userId
                        });
                    }
                }


                foreach (FitbitData fitbitInputData in fitbitInputDatas)
                {
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAwake.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesAwake = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in awakeningsCount.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.AwakeningsCount = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in timeInBed.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.TimeInBed = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesToFallAsleep.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesToFallAsleep = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAfterWakeup.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesAfterWakeup = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in sleepEfficiency.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
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

                    /*foreach (Fitbit.Models.TimeSeriesDataList.Data data in fat.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Fat = data.Value;
                    }*/
                }
                //Comparing Saved data with new data

                foreach (FitbitData data in fitbitInputDatas)
                {
                    //Db.FitbitData.InsertOnSubmit(data);
                    Db.FitbitData.Add(data);
                }

                //Db.SubmitChanges();
                Db.SaveChanges();
            }
            ViewBag.FitbitSynced = true;

            return View();
        }

        public async Task<ActionResult> Sync()
        {

            // Get numofDays data entries to correlation analysis
            // 20170214 Pandita: I feel this is parameter can be tweeked, but 40 sounds like a good value for the time being
            int numOfDays = 40;

            // 20170302 Pandita: use local time
            DateTime baseTime = DateTime.UtcNow;
            baseTime = DateTime.SpecifyKind(baseTime, DateTimeKind.Unspecified);

            TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time").GetUtcOffset(baseTime); // offset value is between -14.0 (towards easthemisphere) ~ 14.0 (towards westhemisphere)
            DateTimeOffset sourceTime = new DateTimeOffset(baseTime, -offset);
            DateTime dateNow = sourceTime.LocalDateTime;

            //Comment out the bellow line to disable getting the current logged in user data
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //UnComment the bellow line to select a specific use to show the users sync page screen
            //string userId = "862a567a-a845-4d48-a2c2-91b2e7627924";

            List<Userdata> userDatas = UserDatas(userId, numOfDays);
            // bool todaySync = true;
            bool todaySync = false;
            ViewBag.todaySync = true;

            foreach (Userdata userData in userDatas)
            {
                if (userData.DateStamp >= dateNow)
                {
                    todaySync = true;
                }
            }

            // 20170213 Pandita: If today not synced, sync data; if today already synced, not sync data??? 
            // But, it kept on syncing the latest day!!! Also, need to check if an entry for a certain day already exists to avoid writing multiple entries for a same day.
            if (!todaySync)
            {
                await FitbitDataSync(userId);
            }

            SyncViewModel model = DataModelCreation(userDatas);
            return View(model);

        }



        /// <summary>
        /// Handels all data retrieval and outputs the user data
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        // 20170213 Pandita: merge Fitbit data and diary data for correlation analysis
        private List<Userdata> UserDatas(string userId, int numOfDays)
        {
            //Item Stup
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-numOfDays);
            List<Userdata> userDatas = new List<Userdata>();

            //Data retieval
            var diaryDatas = from table in Db.DiaryData
                             where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                             orderby table.DateStamp
                             select table;

            var fitbitDatas = from table in Db.FitbitData
                              where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                              orderby table.DateStamp
                              select table;

            foreach (FitbitData fitbitData in fitbitDatas)
            {
                userDatas.Add(new Userdata()
                {
                    Id = fitbitData.Id,
                    DateStamp = fitbitData.DateStamp,
                    MinutesAsleep = Convert.ToDouble(fitbitData.MinutesAsleep),
                    MinutesAwake = Convert.ToDouble(fitbitData.MinutesAwake),
                    AwakeningsCount = Convert.ToDouble(fitbitData.AwakeningsCount),
                    TimeInBed = Convert.ToDouble(fitbitData.TimeInBed),
                    MinutesToFallAsleep = Convert.ToDouble(fitbitData.MinutesToFallAsleep),
                    MinutesAfterWakeup = Convert.ToDouble(fitbitData.MinutesAfterWakeup),
                    SleepEfficiency = Convert.ToDouble(fitbitData.SleepEfficiency),
                    CaloriesIn = Convert.ToDouble(fitbitData.CaloriesIn),
                    CaloriesOut = Convert.ToDouble(fitbitData.CaloriesOut),
                    Water = Convert.ToDouble(fitbitData.Water),
                    Steps = Convert.ToDouble(fitbitData.Steps),
                    Distance = Convert.ToDouble(fitbitData.Distance),
                    MinutesSedentary = Convert.ToDouble(fitbitData.MinutesSedentary),
                    MinutesLightlyActive = Convert.ToDouble(fitbitData.MinutesLightlyActive),
                    MinutesFairlyActive = Convert.ToDouble(fitbitData.MinutesFairlyActive),
                    MinutesVeryActive = Convert.ToDouble(fitbitData.MinutesVeryActive),
                    ActivityCalories = Convert.ToDouble(fitbitData.ActivityCalories),
                    // userdata.TimeEnteredBed = TimeSpan.Parse(fitbitData.TimeEnteredBed); //Was getting Null Exception error

                    Weight = Convert.ToDouble(fitbitData.Weight),
                    BMI = Convert.ToDouble(fitbitData.BMI),
                    //Fat = Convert.ToDouble(fitbitData.Fat)
                });
            }
            foreach (Userdata userdata in userDatas)
            {
                foreach (DiaryData diaryData in diaryDatas.Where(diaryData => DbFunctions.TruncateTime(diaryData.DateStamp) == DbFunctions.TruncateTime(userdata.DateStamp)))
                {
                    // 31 questions in total
                    userdata.WakeUpFreshness = Convert.ToDouble(diaryData.WakeUpFreshness);
                    userdata.Mood = Convert.ToDouble(diaryData.Mood);
                    userdata.Stress = Convert.ToDouble(diaryData.Stress);
                    userdata.Tiredness = Convert.ToDouble(diaryData.Tiredness);
                    userdata.Dream = Convert.ToDouble(diaryData.Dream);
                    userdata.BodyTemp = Convert.ToDouble(diaryData.BodyTemp);
                    userdata.Hormone = Convert.ToDouble(diaryData.Hormone);
                    userdata.SchoolStress = Convert.ToDouble(diaryData.SchoolStress);
                    userdata.CoffeeAmt = Convert.ToDouble(diaryData.CoffeeAmt);
                    userdata.CoffeeTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.CoffeeTime));
                    userdata.AlcoholAmt = Convert.ToDouble(diaryData.AlcoholAmt);
                    userdata.AlcoholTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.AlcoholTime));
                    userdata.NapTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.NapTime));
                    userdata.NapDuration = Convert.ToDouble(diaryData.NapDuration);
                    userdata.DigDeviceDuration = Convert.ToDouble(diaryData.DigDeviceDuration);
                    userdata.GamesDuration = Convert.ToDouble(diaryData.GamesDuration);
                    // 20170214 Pandita: added SocialFamily, SocialFriend, and SocialMedia
                    userdata.SocialFamily = Convert.ToDouble(diaryData.SocialFamily);
                    userdata.SocialFriend = Convert.ToDouble(diaryData.SocialFriend);
                    userdata.SocialMedia = Convert.ToDouble(diaryData.SocialMedia);

                    userdata.MusicDuration = Convert.ToDouble(diaryData.MusicDuration);
                    userdata.TVDuration = Convert.ToDouble(diaryData.TVDuration);
                    userdata.WorkTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.WorkTime));
                    userdata.WorkDuration = Convert.ToDouble(diaryData.WorkDuration);
                    userdata.ExerciseDuration = Convert.ToDouble(diaryData.ExerciseDuration);
                    userdata.ExerciseIntensity = Convert.ToDouble(diaryData.ExerciseIntensity);
                    userdata.DinnerTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.DinnerTime));
                    userdata.SnackTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.SnackTime));
                    userdata.AmbientTemp = Convert.ToDouble(diaryData.AmbientTemp);
                    userdata.AmbientHumd = Convert.ToDouble(diaryData.AmbientHumd);
                    userdata.Light = Convert.ToDouble(diaryData.Light);
                    userdata.SunRiseTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.SunRiseTime));
                    userdata.SunSetTime = diaryData.DateStamp.AddHours(Convert.ToInt32(diaryData.SunSetTime));
                }
            }
            Console.Write(userDatas);
            return userDatas;
        }

        // 20170213 Pandita: Prepare data to be passed to front end
        private SyncViewModel DataModelCreation(List<Userdata> userDatas)
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

            SyncViewModel syncViewModel = new SyncViewModel();
            syncViewModel.UserData = new List<Userdata>();
            List<CorrList> minutesAsleepCorrList = new List<CorrList>();
            List<CorrList> awakeCountCorrList = new List<CorrList>();
            List<CorrList> sleepEffiencyCorrList = new List<CorrList>();
            List<CorrList> minutesAwakeCorrList = new List<CorrList>();
            ViewBag.FitbitSynced = true;


            //Fitbit Data Counters
            int CNTSteps = 0, CNTDistance = 0, CNTMinutesSedentary = 0, CNTMinutesLightlyActive = 0,
                CNTMinutesFairlyActive = 0, CNTMinutesVeryActive = 0, CNTWater = 0,
                CNTCaloriesOut = 0, CNTActivityCalories = 0, CNTWeight = 0, CNTBMI = 0, /*CNTFat = 0,*/ CNTCaloriesIn = 0;


            //Diary Data Counters
            int CNTWakeUpFreshness = 0, CNTMood = 0, CNTStress = 0, CNTTiredness = 0,
                CNTDream = 0, CNTBodyTemp = 0, CNTHormone = 0,
                CNTSchoolStress = 0,
                CNTCoffeeAmt = 0, CNTCoffeeTime = 0, CNTAlcoholAmt = 0, CNTAlcoholTime = 0,
                CNTNapTime = 0, CNTNapDuration = 0,
                CNTDigDeviceDuration = 0, CNTGamesDuration = 0, CNTSocialFriend = 0, CNTSocialFamily = 0, CNTSocialMedia = 0, CNTMusicDuration = 0, CNTTVDuration = 0,
                CNTWorkTime = 0, CNTWorkDuration = 0, CNTExerciseDuration = 0, CNTExerciseIntensity = 0,
                CNTDinnerTime = 0, CNTSnackTime = 0,
                CNTAmbientTemp = 0, CNTAmbientHumd = 0, CNTLight = 0, CNTSunRiseTime = 0, CNTSunSetTime = 0;

            foreach (Userdata userData in userDatas)
            {
                //Fitbit Data Counter
                if (userData.Steps > 0) CNTSteps++;
                if (userData.Distance >= 0) CNTDistance++;
                if (userData.MinutesSedentary > 0) CNTMinutesSedentary++;
                if (userData.MinutesLightlyActive > 0) CNTMinutesLightlyActive++;
                if (userData.MinutesFairlyActive > 0) CNTMinutesFairlyActive++;
                if (userData.MinutesVeryActive > 0) CNTMinutesVeryActive++;
                if (userData.Water > 0) CNTWater++;
                if (userData.CaloriesIn > 0) CNTCaloriesIn++;
                if (userData.CaloriesOut > 0) CNTCaloriesOut++;
                if (userData.ActivityCalories > 0) CNTActivityCalories++;
                if (userData.Weight > 0) CNTWeight++;
                if (userData.BMI > 0) CNTBMI++;
                //if (userData.Fat > 0) CNTFat++;

                //Diary Data Counter
                if (userData.WakeUpFreshness > 0) CNTWakeUpFreshness++;
                if (userData.Mood > 0) CNTMood++;
                if (userData.Stress > 0) CNTStress++;
                if (userData.Tiredness > 0) CNTTiredness++;
                if (userData.Dream > 0) CNTDream++;
                if (userData.BodyTemp > 0) CNTBodyTemp++;
                if (userData.Hormone > 0) CNTHormone++;
                if (userData.SchoolStress > 0) CNTSchoolStress++;
                if (userData.CoffeeAmt >= 0) CNTCoffeeAmt++;
                if (userData.CoffeeTime != null) CNTCoffeeTime++;
                if (userData.AlcoholAmt > 0) CNTAlcoholAmt++;
                if (userData.AlcoholTime != null) CNTAlcoholTime++;
                if (userData.NapTime != null) CNTNapTime++;
                if (userData.NapDuration > 0) CNTNapDuration++;
                if (userData.DigDeviceDuration > 0) CNTDigDeviceDuration++;
                if (userData.GamesDuration > 0) CNTGamesDuration++;
                if (userData.SocialFriend > 0) CNTSocialFriend++;
                if (userData.SocialFamily > 0) CNTSocialFamily++;
                if (userData.SocialMedia > 0) CNTSocialMedia++;
                if (userData.MusicDuration >= 0) CNTMusicDuration++;
                if (userData.TVDuration > 0) CNTTVDuration++;
                if (userData.WorkTime != null) CNTWorkTime++;
                if (userData.ExerciseDuration > 0) CNTExerciseDuration++;
                if (userData.ExerciseIntensity > 0) CNTExerciseIntensity++;
                if (userData.DinnerTime != null) CNTDinnerTime++;
                if (userData.SnackTime != null) CNTSnackTime++;
                if (userData.AmbientTemp > 0) CNTAmbientTemp++;
                if (userData.AmbientHumd > 0) CNTAmbientHumd++;
                if (userData.Light > 0) CNTLight++;
                if (userData.SunRiseTime != null) CNTSunRiseTime++;
                if (userData.SunSetTime != null) CNTSunSetTime++;

                //To Ignore anything with 0

                if (userData.MinutesAsleep > 0)
                {
                    syncViewModel.UserData.Add(userData);
                }

                //All - I like the idea of seeing when data is not present


            }


            int countOfDaysData = userDatas.Count;

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
            // Pandita 2018/05/31: fixed the array range
            double[] WakeUpFreshnessSteps = new double[countOfDaysData];
            double[] WakeUpFreshnessDistance = new double[countOfDaysData];
            double[] WakeUpFreshnessMinutesSedentary = new double[countOfDaysData];
            double[] WakeUpFreshnessMinutesLightlyActive = new double[countOfDaysData];
            double[] WakeUpFreshnessMinutesFairlyActive = new double[countOfDaysData];
            double[] WakeUpFreshnessMinutesVeryActive = new double[countOfDaysData];
            double[] WakeUpFreshnessWater = new double[countOfDaysData];
            double[] WakeUpFreshnessCaloriesIn = new double[countOfDaysData];
            double[] WakeUpFreshnessCaloriesOut = new double[countOfDaysData];
            double[] WakeUpFreshnessActivityCalories = new double[countOfDaysData];
            double[] WakeUpFreshnessWeight = new double[countOfDaysData];
            double[] WakeUpFreshnessBMI = new double[countOfDaysData];
            double[] WakeUpFreshnessFat = new double[countOfDaysData];

            double[] WakeUpFreshnessMood = new double[countOfDaysData];
            double[] WakeUpFreshnessStress = new double[countOfDaysData];
            double[] WakeUpFreshnessTiredness = new double[countOfDaysData];
            double[] WakeUpFreshnessDream = new double[countOfDaysData];
            double[] WakeUpFreshnessBodyTemp = new double[countOfDaysData];
            double[] WakeUpFreshnessHormone = new double[countOfDaysData];
            double[] WakeUpFreshnessSchoolStress = new double[countOfDaysData];
            double[] WakeUpFreshnessCoffeeAmt = new double[countOfDaysData];
            double[] WakeUpFreshnessCoffeeTime = new double[countOfDaysData];
            double[] WakeUpFreshnessAlcoholAmt = new double[countOfDaysData];
            double[] WakeUpFreshnessAlcoholTime = new double[countOfDaysData];
            double[] WakeUpFreshnessNapTime = new double[countOfDaysData];
            double[] WakeUpFreshnessNapDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessDigDeviceDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessGamesDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessSocialFriend = new double[countOfDaysData];
            double[] WakeUpFreshnessSocialFamily = new double[countOfDaysData];
            double[] WakeUpFreshnessSocialMedia = new double[countOfDaysData];
            double[] WakeUpFreshnessMusicDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessTVDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessWorkTime = new double[countOfDaysData];
            double[] WakeUpFreshnessWorkDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessExerciseDuration = new double[countOfDaysData];
            double[] WakeUpFreshnessExerciseIntensity = new double[countOfDaysData];
            double[] WakeUpFreshnessDinnerTime = new double[countOfDaysData];
            double[] WakeUpFreshnessSnackTime = new double[countOfDaysData];
            double[] WakeUpFreshnessAmbientTemp = new double[countOfDaysData];
            double[] WakeUpFreshnessAmbientHumd = new double[countOfDaysData];
            double[] WakeUpFreshnessLight = new double[countOfDaysData];
            double[] WakeUpFreshnessSunRiseTime = new double[countOfDaysData];
            double[] WakeUpFreshnessSunSetTime = new double[countOfDaysData];


            //Temp Values
            //Fitbit
            double[] tmpSteps = new double[countOfDaysData];
            double[] tmpDistance = new double[countOfDaysData];
            double[] tmpMinutesSedentary = new double[countOfDaysData];
            double[] tmpMinutesLightlyActive = new double[countOfDaysData];
            double[] tmpMinutesFairlyActive = new double[countOfDaysData];
            double[] tmpMinutesVeryActive = new double[countOfDaysData];
            double[] tmpWater = new double[countOfDaysData];
            double[] tmpCaloriesIn = new double[countOfDaysData];
            double[] tmpCaloriesOut = new double[countOfDaysData];
            double[] tmpActivityCalories = new double[countOfDaysData];
            double[] tmpWeight = new double[countOfDaysData];
            double[] tmpBMI = new double[countOfDaysData];
            double[] tmpFat = new double[countOfDaysData];

            //Diary 
            double[] tmpMood = new double[countOfDaysData];
            double[] tmpStress = new double[countOfDaysData];
            double[] tmpTiredness = new double[countOfDaysData];
            double[] tmpDream = new double[countOfDaysData];
            double[] tmpBodyTemp = new double[countOfDaysData];
            double[] tmpHormone = new double[countOfDaysData];
            double[] tmpSchoolStress = new double[countOfDaysData];
            double[] tmpCoffeeAmt = new double[countOfDaysData];
            double[] tmpCoffeeTime = new double[countOfDaysData];
            double[] tmpAlcoholAmt = new double[countOfDaysData];
            double[] tmpAlcoholTime = new double[countOfDaysData];
            double[] tmpNapTime = new double[countOfDaysData];
            double[] tmpNapDuration = new double[countOfDaysData];
            double[] tmpDigDeviceDuration = new double[countOfDaysData];
            double[] tmpGamesDuration = new double[countOfDaysData];
            double[] tmpSocialFriend = new double[countOfDaysData];
            double[] tmpSocialFamily = new double[countOfDaysData];
            double[] tmpSocialMedia = new double[countOfDaysData];
            double[] tmpMusicDuration = new double[countOfDaysData];
            double[] tmpTVDuration = new double[countOfDaysData];
            double[] tmpWorkTime = new double[countOfDaysData];
            double[] tmpWorkDuration = new double[countOfDaysData];
            double[] tmpExerciseDuration = new double[countOfDaysData];
            double[] tmpExerciseIntensity = new double[countOfDaysData];
            double[] tmpDinnerTime = new double[countOfDaysData];
            double[] tmpSnackTime = new double[countOfDaysData];
            double[] tmpAmbientTemp = new double[countOfDaysData];
            double[] tmpAmbientHumd = new double[countOfDaysData];
            double[] tmpLight = new double[countOfDaysData];
            double[] tmpSunRiseTime = new double[countOfDaysData];
            double[] tmpSunSetTime = new double[countOfDaysData];



            //Fitbit Data incruments 
            int iMinutesAsleep = 0, iMinutesAwake = 0,
            iAwakeningsCount = 0, iMinutesToFallAsleep = 0, iSleepEfficiency = 0;


            int iMinutesSedentary = 0, iMinutesLightlyActive = 0,
                iMinutesFairlyActive = 0, iMinutesVeryActive = 0; /*iSteps = 0, iDistance = 0, iWater = 0,
                iCaloriesOut = 0, iActivityCalories = 0, iWeight = 0, iBMI = 0, iFat = 0, iCaloriesIn = 0;

            
            //Diary Data incruments
            int iWakeUpFreshness = 0, iMood = 0, iStress = 0, iTiredness = 0,
                iDream = 0, iBodyTemp = 0, iHormone = 0,
                iSchoolStress = 0,
                iCoffeeAmt = 0, iCoffeeTime = 0, iAlcoholAmt = 0, iAlcoholTime = 0,
                iNapTime = 0, iNapDuration = 0,
                iDigDeviceDuration = 0, iGamesDuration = 0, iSocialFriend = 0, iSocialFamily = 0, iSocialMedia = 0, iMusicDuration = 0, iTVDuration = 0,
                iWorkTime = 0, iWorkDuration = 0, iExerciseDuration = 0, iExerciseIntensity = 0,
                iDinnerTime = 0, iSnackTime = 0,
                iAmbientTemp = 0, iAmbientHumd = 0, iLight = 0, iSunRiseTime = 0, iSunSetTime = 0;

            //int iFloors = 0;
            //int iTimeEnteredBed = 0;

            int iWakeUpFreshnessMinutesAsleep = 0, iWakeUpFreshnessMinutesAwake = 0,
                iWakeUpFreshnessAwakeningsCount = 0, iWakeUpFreshnessMinutesToFallAsleep = 0, iWakeUpFreshnessSleepEfficiency = 0;*/

            int iWakeUpFreshnessSteps = 0, iWakeUpFreshnessDistance = 0, iWakeUpFreshnessMinutesSedentary = 0, iWakeUpFreshnessMinutesLightlyActive = 0,
                iWakeUpFreshnessMinutesFairlyActive = 0, iWakeUpFreshnessMinutesVeryActive = 0, iWakeUpFreshnessWater = 0,
                iWakeUpFreshnessCaloriesOut = 0, iWakeUpFreshnessActivityCalories = 0, iWakeUpFreshnessWeight = 0, iWakeUpFreshnessBMI = 0,iWakeUpFreshnessFat = 0,iWakeUpFreshnessCaloriesIn = 0;

            //Diary Data incruments
            int iWakeUpFreshnessMood = 0, iWakeUpFreshnessStress = 0, iWakeUpFreshnessTiredness = 0,
                iWakeUpFreshnessDream = 0, iWakeUpFreshnessBodyTemp = 0, iWakeUpFreshnessHormone = 0,
                //iWakeUpFreshnessSchoolStress = 0,
                iWakeUpFreshnessCoffeeAmt = 0, iWakeUpFreshnessCoffeeTime = 0, iWakeUpFreshnessAlcoholAmt = 0, iWakeUpFreshnessAlcoholTime = 0,
                iWakeUpFreshnessNapTime = 0, iWakeUpFreshnessNapDuration = 0,
                iWakeUpFreshnessDigDeviceDuration = 0, iWakeUpFreshnessGamesDuration = 0, iWakeUpFreshnessSocialFriend = 0, iWakeUpFreshnessSocialFamily = 0, iWakeUpFreshnessSocialMedia = 0, iWakeUpFreshnessMusicDuration = 0, iWakeUpFreshnessTVDuration = 0,
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

                MinutesAsleep[iMinutesAsleep++] = Convert.ToDouble(daysData.MinutesAsleep);
                MinutesAwake[iMinutesAwake++] = Convert.ToDouble(daysData.MinutesAwake);
                AwakeningsCount[iAwakeningsCount++] = Convert.ToDouble(daysData.AwakeningsCount);
                MinutesToFallAsleep[iMinutesToFallAsleep++] = Convert.ToDouble(daysData.MinutesToFallAsleep);
                SleepEfficiency[iSleepEfficiency++] = Convert.ToDouble(daysData.SleepEfficiency);

                MinutesSedentary[iMinutesSedentary++] = Convert.ToDouble(daysData.MinutesSedentary);
                MinutesLightlyActive[iMinutesLightlyActive++] = Convert.ToDouble(daysData.MinutesLightlyActive);
                MinutesFairlyActive[iMinutesFairlyActive++] = Convert.ToDouble(daysData.MinutesFairlyActive);
                MinutesVeryActive[iMinutesVeryActive++] = Convert.ToDouble(daysData.MinutesVeryActive);

                if (Convert.ToDouble(daysData.WakeUpFreshness) > 0)
                {
                    //Fitbit Data
                    if (Convert.ToDouble(daysData.Steps) > 0)
                    {
                        WakeUpFreshnessSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.Steps);
                        iWakeUpFreshnessSteps++;
                    }
                    if (Convert.ToDouble(daysData.Distance) > 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDistance[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.Distance);
                        iWakeUpFreshnessDistance++;
                    }

                    if (Convert.ToDouble(daysData.MinutesSedentary) > 0)
                    {
                        WakeUpFreshnessMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.MinutesSedentary);
                        iWakeUpFreshnessMinutesSedentary++;
                    }
                    if (Convert.ToDouble(daysData.MinutesLightlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesLightlyActive[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesLightlyActive[iWakeUpFreshnessMinutesLightlyActive] = Convert.ToDouble(daysData.MinutesLightlyActive);
                        iWakeUpFreshnessMinutesLightlyActive++;
                    }
                    if (Convert.ToDouble(daysData.MinutesFairlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.MinutesFairlyActive);
                        iWakeUpFreshnessMinutesFairlyActive++;
                    }
                    if (Convert.ToDouble(daysData.MinutesVeryActive) >= 0)
                    {
                        WakeUpFreshnessMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.MinutesVeryActive);
                        iWakeUpFreshnessMinutesVeryActive++;
                    }
                    if (Convert.ToDouble(daysData.Water) >= 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.Water);
                        iWakeUpFreshnessWater++;
                    }
                    if (Convert.ToDouble(daysData.CaloriesIn) >= 0)
                    {
                        WakeUpFreshnessCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }
                    /* Pandita 2018/05/31 this array was not declared ! 
                    if (Convert.ToDouble(daysData.CaloriesOut) >= 0)
                    {
                        WakeUpFreshnessCaloriesOut[iWakeUpFreshnessCaloriesOut] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCaloriesOut[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }*/
                    if (Convert.ToDouble(daysData.ActivityCalories) >= 0)
                    {
                        WakeUpFreshnessActivityCalories[iWakeUpFreshnessActivityCalories] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpActivityCalories[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.ActivityCalories);
                        iWakeUpFreshnessActivityCalories++;
                    }
                    if (Convert.ToDouble(daysData.Weight) > 0)
                    {
                        WakeUpFreshnessWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.Weight);
                        iWakeUpFreshnessWeight++;
                    }
                    if (Convert.ToDouble(daysData.Fat) > 0)
                    {
                        WakeUpFreshnessFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.Fat);
                        iWakeUpFreshnessFat++;
                    }

                    if (Convert.ToDouble(daysData.Fat) > 0)
                    {
                        WakeUpFreshnessBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.BMI);
                        iWakeUpFreshnessBMI++;
                    }
                    //Diary data
                    if (Convert.ToDouble(daysData.Mood) >= 0)
                    {
                        WakeUpFreshnessMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.Mood);
                        iWakeUpFreshnessMood++;
                    }
                    if (Convert.ToDouble(daysData.Stress) > 0)
                    {
                        WakeUpFreshnessStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.Stress);
                        iWakeUpFreshnessStress++;
                    }
                    if (Convert.ToDouble(daysData.Tiredness) >= 0)
                    {
                        WakeUpFreshnessTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.Tiredness);
                        iWakeUpFreshnessTiredness++;
                    }
                    if (Convert.ToDouble(daysData.Dream) >= 0)
                    {
                        WakeUpFreshnessDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.Dream);
                        iWakeUpFreshnessDream++;
                    }
                    if (Convert.ToDouble(daysData.BodyTemp) >= 0)
                    {
                        WakeUpFreshnessBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.BodyTemp);
                        iWakeUpFreshnessBodyTemp++;
                    }
                    if (Convert.ToDouble(daysData.Hormone) >= 0)
                    {
                        WakeUpFreshnessHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.Hormone);
                        iWakeUpFreshnessHormone++;
                    }
                    if (Convert.ToDouble(daysData.CoffeeAmt) >= 0)
                    {
                        WakeUpFreshnessCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.CoffeeAmt);
                        iWakeUpFreshnessCoffeeAmt++;
                    }
                    /* Pandita: 2018/05/31 Not able to convert DateTime to double
                    if (Convert.ToDouble(daysData.CoffeeTime) >= 0)
                    {
                        WakeUpFreshnessCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.CoffeeTime);
                        iWakeUpFreshnessCoffeeTime++;
                    }*/
                    if (Convert.ToDouble(daysData.AlcoholAmt) >= 0)
                    {
                        WakeUpFreshnessAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.AlcoholAmt);
                        iWakeUpFreshnessAlcoholAmt++;
                    }

                    /* Pandita: 2018/05/31 Not able to convert DateTime to double
                    if (Convert.ToDouble(daysData.AlcoholTime) >= 0)
                    {
                        WakeUpFreshnessAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.AlcoholTime);
                        iWakeUpFreshnessAlcoholTime++;
                    }
                    if (Convert.ToDouble(daysData.NapTime) > 0)
                    {
                        WakeUpFreshnessNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.NapTime);
                        iWakeUpFreshnessNapTime++;
                    }
                    */
                    if (Convert.ToDouble(daysData.NapDuration) >= 0)
                    {
                        WakeUpFreshnessNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.NapDuration);
                        iWakeUpFreshnessNapDuration++;
                    }
                    if (Convert.ToDouble(daysData.DigDeviceDuration) > 0)
                    {
                        WakeUpFreshnessDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.DigDeviceDuration);
                        iWakeUpFreshnessDigDeviceDuration++;
                    }
                    if (Convert.ToDouble(daysData.GamesDuration) > 0)
                    {
                        WakeUpFreshnessGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.GamesDuration);
                        iWakeUpFreshnessGamesDuration++;
                    }
                    // 20170214 Pandita: added time spent with family and friend, as well as time spent on social media
                    if (Convert.ToDouble(daysData.SocialFriend) > 0)
                    {
                        WakeUpFreshnessSocialFriend[iWakeUpFreshnessSocialFriend] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialFriend[iWakeUpFreshnessSocialFriend] = Convert.ToDouble(daysData.SocialFriend);
                        iWakeUpFreshnessSocialFriend++;
                    }
                    if (Convert.ToDouble(daysData.SocialFamily) > 0)
                    {
                        WakeUpFreshnessSocialFamily[iWakeUpFreshnessSocialFamily] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialFamily[iWakeUpFreshnessSocialFamily] = Convert.ToDouble(daysData.SocialFamily);
                        iWakeUpFreshnessSocialFamily++;
                    }
                    if (Convert.ToDouble(daysData.SocialMedia) > 0)
                    {
                        WakeUpFreshnessSocialMedia[iWakeUpFreshnessSocialMedia] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialMedia[iWakeUpFreshnessSocialMedia] = Convert.ToDouble(daysData.SocialMedia);
                        iWakeUpFreshnessSocialMedia++;
                    }



                    if (Convert.ToDouble(daysData.MusicDuration) > 0)
                    {
                        WakeUpFreshnessMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.MusicDuration);
                        iWakeUpFreshnessMusicDuration++;
                    }
                    if (Convert.ToDouble(daysData.TVDuration) > 0)
                    {
                        WakeUpFreshnessTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.TVDuration);
                        iWakeUpFreshnessTVDuration++;
                    }
                    /* Pandita: 2018/05/31 Not able to convert DateTime to double
                    if (Convert.ToDouble(daysData.WorkTime) > 0)
                    {
                        WakeUpFreshnessWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.WorkTime);
                        iWakeUpFreshnessWorkTime++;
                    }*/
                    if (Convert.ToDouble(daysData.WorkDuration) > 0)
                    {
                        WakeUpFreshnessWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.WorkDuration);
                        iWakeUpFreshnessWorkDuration++;
                    }
                    if (Convert.ToDouble(daysData.ExerciseDuration) > 0)
                    {
                        WakeUpFreshnessExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.ExerciseDuration);
                        iWakeUpFreshnessExerciseDuration++;
                    }
                    if (Convert.ToDouble(daysData.ExerciseIntensity) > 0)
                    {
                        WakeUpFreshnessExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.ExerciseIntensity);
                        iWakeUpFreshnessExerciseIntensity++;
                    }
                    /* Pandita: 2018/05/31 Not able to convert DateTime to double
                    if (Convert.ToDouble(daysData.DinnerTime) > 0)
                    {
                        WakeUpFreshnessDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.DinnerTime);
                        iWakeUpFreshnessDinnerTime++;
                    }
                    if (Convert.ToDouble(daysData.SnackTime) > 0)
                    {
                        WakeUpFreshnessSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.SnackTime);
                        iWakeUpFreshnessSnackTime++;
                    }
                    */
                    if (Convert.ToDouble(daysData.AmbientTemp) > 0)
                    {
                        WakeUpFreshnessAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.AmbientTemp);
                        iWakeUpFreshnessAmbientTemp++;
                    }
                    if (Convert.ToDouble(daysData.AmbientHumd) > 0)
                    {
                        WakeUpFreshnessAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.AmbientHumd);
                        iWakeUpFreshnessAmbientHumd++;
                    }
                    if (Convert.ToDouble(daysData.Light) > 0)
                    {
                        WakeUpFreshnessLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.Light);
                        iWakeUpFreshnessLight++;
                    }
                    /* Pandita: 2018/05/31 Not able to convert DateTime to double
                    if (Convert.ToDouble(daysData.SunRiseTime) > 0)
                    {
                        WakeUpFreshnessSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.SunRiseTime);
                        iWakeUpFreshnessSunRiseTime++;
                    }
                    if (Convert.ToDouble(daysData.SunSetTime) > 0)
                    {
                        WakeUpFreshnessSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.SunSetTime);
                        iWakeUpFreshnessSunSetTime++;
                    }*/
                }

            }
            /*
            // WakeUpFreshness
            double rWakeUpFreshness = 0;

            if (iWakeUpFreshnessSteps > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSteps, tmpSteps);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Wake Up Freshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you walk more." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you walk more." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are more sedentary in the previous day." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you are more sedentary in the previous day." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you do more light exercise." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you do more light exercise." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you do more moderate exercise." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you do more moderate exercise." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you do more intense exercise." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you do more intense exercise." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you drink more water." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you drink more water." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you eat more." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you eat more." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are more active." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you are more active." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you consume more energy in exercises." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you consume more energy in exercises." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you weigh more." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you weigh less." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you BMI is higher." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you BMI is lower." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have more fat." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have less fat." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are happy." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are groomy." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are stressed." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are relaxed." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you are tired." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you are tired." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have more dreams." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you have more dreams." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have higher body temperature." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have lower body temperature." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert as the next period approaches." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert as the next period approaches." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you consume more coffee." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you take less coffee." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you take coffee late." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you take coffee late." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you drink more alcohol." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you drink more alcohol." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you drink until late." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you drink until late." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert if you take a nap." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert if you take a nap." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert if you take a long nap the day before." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert if you take a long nap the day before." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you use digital device before bed time." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you use digital device before bed time." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you play games before bed time." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you play games before bed time." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialFriend > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialFriend, tmpSocialFriend);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you have more social activities the night before." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you have more social activities the night before." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialFamily > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialFamily, tmpSocialFamily);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you use social media before bed time." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you use social media before bed time." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you listen to music before bed time." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you listen to music before bed time." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you watch TV until late." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you watch TV until late." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you exercise more." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you exercise more." });
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
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "You wake up feeling more alert when you exercise hard." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "You wake up feeling less alert when you exercise hard." });
                    }
                }
            }*/

                    // MinutesAsleep
                    //double rMinutesSedentary = Correlation.Pearson(MinutesAsleep, MinutesSedentary);
                    double rMinutesSedentary = alglib.spearmancorr2(MinutesAsleep, MinutesSedentary);
            //double pMinutesSedentary = alglib.correlationtests.spearmanrankcorrelationsignificance(rMinutesSedentary, MinutesAsleep.Length, ref +0.05, ref 0, ref 0); 

            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your hours asleep are better when you are more sedentary the day before." });
                }
                else if (rMinutesSedentary < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your hours asleep are worse when you are more sedentary the day before." });
                }
            }

            //double rMinutesLightlyActive = Correlation.Pearson(MinutesAsleep, MinutesLightlyActive);
            double rMinutesLightlyActive = alglib.spearmancorr2(MinutesAsleep, MinutesLightlyActive);

            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your hours asleep are better when you do more light exercise." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your hours asleep are worse when you do more light exercise." });
                }
            }

            //double rMinutesFairlyActive = Correlation.Pearson(MinutesAsleep, MinutesFairlyActive);
            double rMinutesFairlyActive = alglib.spearmancorr2(MinutesAsleep, MinutesFairlyActive);
            

            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your hours asleep are better when you do more moderate exercise." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your hours asleep are worse when you do more moderate exercise." });
                }
            }

            //double rMinutesVeryActive = Correlation.Pearson(MinutesAsleep, MinutesVeryActive);
            double rMinutesVeryActive = alglib.spearmancorr2(MinutesAsleep, MinutesVeryActive);

            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your hours asleep are better when you do more intense exercise." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your hours asleep are worse when you do more moderate exercise." });
                }
            }

            // AwakeningsCount
            rMinutesSedentary = Correlation.Pearson(AwakeningsCount, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your sleep is more fragmented when you are more sedentary the day before." });
                }
                else if (rMinutesSedentary < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your sleep is less fragmented when you are more sedentary the day before." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(AwakeningsCount, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your sleep is more fragmented when you do more light exercises." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your sleep is less fragmented when you do more light exercises." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(AwakeningsCount, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your sleep is more fragmented when you do more moderate exercises." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your sleep is less fragmented when you do more moderate exercises." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(AwakeningsCount, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your sleep is more fragmented when you do more intense exercises." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your sleep is less fragmented when you do more intense exercises." });
                }
            }


            // MinutesAwake
            rMinutesSedentary = Correlation.Pearson(MinutesAwake, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "You're more awake when you are sedentary the day before." });
                }
                else if (rMinutesSedentary < 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "You're less awake when you are sedentary the day before." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(MinutesAwake, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "You're more awake when you do more light exercise." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "You're less awake when you do more light exercise." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(MinutesAwake, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "You're more awake when you do more moderate exercise." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "You're less awake when you do more moderate exercise." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(MinutesAwake, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "You're more awake when you do more intense exercise." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "You're less awake when you do more intense exercise." });
                }
            }




            // SleepEfficiency
            rMinutesSedentary = Correlation.Pearson(SleepEfficiency, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your sleep efficiency is better when you are more sedentary the day before." });
                }
                else if (rMinutesSedentary < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "Your sleep efficiency is better when you are less sedentary the day before." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(SleepEfficiency, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your sleep efficiency is better when you do more light exercise." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "Your sleep efficiency is better when you do less light exercise." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(SleepEfficiency, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your sleep efficiency is better when you do more moderate exercise." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "Your sleep efficiency is better when you do less moderate exercise." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(SleepEfficiency, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your sleep efficiency is better when you do more intense exercise." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "Your sleep efficiency is better when you do less intense exercise." });
                }
            }



            // CaloriesIn - DONE!!! YEAH!!!
            int temp = 0, identifier = 0;
            double pearson = 0, tempValue = 0;
            if (CNTCaloriesIn > 4)
            {
                // pandita 2018/05/31 fix the array range issue
                double[] CaloriesIn = new double[countOfDaysData];
                double[] tempMinutesAsleepCalariesIn = new double[countOfDaysData];
                double[] tempMinutesAwakeCalariesIn = new double[countOfDaysData];
                double[] tempSleepEfficiencyCalariesIn = new double[countOfDaysData];

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {

                    tempValue = Convert.ToDouble(daysData.CaloriesIn);
                    if (tempValue > 0)
                    {
                        CaloriesIn[temp] = tempValue;
                        tempMinutesAsleepCalariesIn[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeCalariesIn[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your hours asleep are better when you eat more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your hours asleep are worse when you eat more." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "You're more awake when you eat more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "You're less awake when you eat more." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your sleep efficiency is better when you eat more." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your sleep efficiency is better when you eat less." });
                    }
                }

            }

            // CaloriesOut -- DONE !!! YEAH !!!

            if (CNTCaloriesOut > 4)
            {
                double[] CaloriesOut = new double[countOfDaysData];
                double[] tempMinutesAsleepCalariesOut = new double[countOfDaysData];
                double[] tempMinutesAwakeCalariesOut = new double[countOfDaysData];
                double[] tempSleepEfficiencyCalariesOut = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.CaloriesOut);
                    if (tempValue > 0)
                    {
                        CaloriesOut[temp] = tempValue;
                        tempMinutesAsleepCalariesOut[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeCalariesOut[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your hours asleep are better when you are more active." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your hours asleep are worse when you are more active." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "You're more awake when you are more active." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "You're less awake when you are more active." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your sleep efficiency is better when you are more active." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "Your sleep efficiency is worse when you are more active." });
                    }
                }

            }

            // Water -- DONE YEAH!!

            if (CNTWater > 4)
            {
                double[] Water = new double[countOfDaysData];
                double[] tempMinutesAsleepWater = new double[countOfDaysData];
                double[] tempMinutesAwakeWater = new double[countOfDaysData];
                double[] tempSleepEfficiencyWater = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Water);
                    if (tempValue > 0)
                    {
                        Water[temp] = tempValue;
                        tempMinutesAsleepWater[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeWater[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "Your hours asleep are better when you drink more water." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "Your hours asleep are worse when you drink more water." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "You're more awake when you drink more water." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "You're less awake when you drink more water." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "Your sleep efficiency is better when you drink more water." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "Your sleep efficiency is better when you drink less water." });
                    }
                }

            }

            // Steps -- DONE YEAH!!

            if (CNTSteps > 4)
            {
                double[] Steps = new double[countOfDaysData];
                double[] tempMinutesAsleepSteps = new double[countOfDaysData];
                double[] tempMinutesAwakeSteps = new double[countOfDaysData]; ;
                double[] tempSleepEfficiencySteps = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Steps);
                    if (tempValue > 0)
                    {
                        Steps[temp] = tempValue;
                        tempMinutesAsleepSteps[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeSteps[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "Your hours asleep are better when you walk more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "Your hours asleep are worse when you walk more." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeSteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "You're more awake when you walk more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "You're less awake when you walk more." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencySteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "Your sleep efficiency is better when you walk more" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "Your sleep efficiency is worse when you walk more." });
                    }
                }

            }

            // weight -- DONE YEAH!!

            if (CNTWeight > 4)
            {
                double[] Weight = new double[countOfDaysData];
                double[] tempMinutesAsleepWeight = new double[countOfDaysData];
                double[] tempMinutesAwakeWeight = new double[countOfDaysData];
                double[] tempSleepEfficiencyWeight = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Weight);
                    if (tempValue > 0)
                    {
                        Weight[temp] = tempValue;
                        tempMinutesAsleepWeight[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeWeight[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "Your hours asleep are better when you weigh more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "Your hours asleep are better when you weigh less." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "You're more awake when you weigh more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "You're more awake when you weigh less." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "Your sleep efficiency is better when you weigh more." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "Your sleep efficiency is better when you weigh less." });
                    }
                }

            }

            // Fat -- DONE YEAH!!
            /*

            if (CNTFat > 4)
            {
                double[] Fat = new double[CNTFat];
                double[] tempMinutesAsleepFat = new double[CNTFat];
                double[] tempMinutesAwakeFat = new double[CNTFat];
                double[] tempSleepEfficiencyFat = new double[CNTFat];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Fat);
                    if (tempValue > 0)
                    {
                        Fat[temp] = tempValue;
                        tempMinutesAsleepFat[temp] = MinutesAsleep[identifier];
                        tempMinutesAwakeFat[temp] = MinutesAwake[identifier];
                        tempSleepEfficiencyFat[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

            }*/



            // Coffee -- DONE YEAH!!

            if (CNTCoffeeAmt > 4)
            {
                double[] Coffee = new double[countOfDaysData];
                double[] tempMinutesAsleepCoffee = new double[countOfDaysData];
                double[] tempMinutesAwakeCoffee = new double[countOfDaysData];
                double[] tempSleepEfficiencyCoffee = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.CoffeeAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.CoffeeAmt);
                        if (tempValue >= 0)
                        {
                            Coffee[temp] = tempValue;
                            tempMinutesAsleepCoffee[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeCoffee[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your hours asleep are better when you consume more coffee." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your hours asleep are better when you take less coffee." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "You're more awake when you consume more coffee." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "You're more awake when you take less coffee." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your sleep efficiency is better when you consume more coffee." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your sleep efficiency is better when you take less coffee." });
                    }
                }

            }



            // CoffeeTime -- DONE YEAH!!
            /* Pandata 2018/05/31: not able to convert time to numbers 

            if (CNTCoffeeTime > 4)
            {
                double[] CoffeeTime = new double[CNTCoffeeTime];
                double[] tempMinutesAsleepCoffeeTime = new double[CNTCoffeeTime];
                double[] tempMinutesAwakeCoffeeTime = new double[CNTCoffeeTime];
                double[] tempSleepEfficiencyCoffeeTime = new double[CNTCoffeeTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.CoffeeTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.CoffeeTime);
                        if (tempValue > 0)
                        {
                            CoffeeTime[temp] = tempValue;
                            tempMinutesAsleepCoffeeTime[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeCoffeeTime[temp] = MinutesAwake[identifier];
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
                            minutesAsleepCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your hours asleep are better when you take coffee late." });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your hours asleep are worse when you take coffee late." });
                        }
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "You're more awake when you take coffee late." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "You're less awake when you take coffee late." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your sleep efficiency is better when you take coffee late." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "Your sleep efficiency is worse when you take coffee late." });
                    }
                }

            }
            */

            // Alcohol -- DONE YEAH!!

            if (CNTAlcoholAmt > 4)
            {
                double[] Alcohol = new double[countOfDaysData];
                double[] tempMinutesAsleepAlcohol = new double[countOfDaysData];
                double[] tempMinutesAwakeAlcohol = new double[countOfDaysData];
                double[] tempSleepEfficiencyAlcohol = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AlcoholAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AlcoholAmt);
                        if (tempValue >= 0)
                        {
                            Alcohol[temp] = tempValue;
                            tempMinutesAsleepAlcohol[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeAlcohol[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "Your hours asleep are better when you drink more alcohol." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "Your hours asleep are worse when you drink more alcohol." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "You're more awake when you drink more alcohol." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "You're less awake when you drink more alcohol." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "Your sleep efficiency is better when you drink more alcohol." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "Your sleep efficiency is worse when you drink more alcohol." });
                    }
                }

            }


            // Mood -- DONE YEAH!!

            if (CNTMood > 4)
            {
                double[] Mood = new double[countOfDaysData];
                double[] tempMinutesAsleepMood = new double[countOfDaysData];
                double[] tempMinutesAwakeMood = new double[countOfDaysData];
                double[] tempSleepEfficiencyMood = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Mood != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Mood);
                        if (tempValue >= 0)
                        {
                            Mood[temp] = tempValue;
                            tempMinutesAsleepMood[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeMood[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "Your hours asleep are better when you are happy." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "Oops! Your hours asleep are better when you are gloomy." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "You're more awake when you are happy." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "You're more awake when you are gloomy." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "Your sleep efficiency is better when you are happy." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "Oops! Your sleep efficiency is better when you are gloomy." });
                    }
                }

            }


            // Stress -- DONE YEAH!!

            if (CNTStress > 4)
            {
                double[] Stress = new double[countOfDaysData];
                double[] tempMinutesAsleepStress = new double[countOfDaysData];
                double[] tempMinutesAwakeStress = new double[countOfDaysData];
                double[] tempSleepEfficiencyStress = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Stress != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Stress);
                        if (tempValue >= 0)
                        {
                            Stress[temp] = tempValue;
                            tempMinutesAsleepStress[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeStress[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "Your hours asleep are better when you are stressed." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "Your hours asleep are better when you are relaxed." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "You're more awake when you are stressed." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "You're more awake when you are relaxed." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "Your sleep efficiency is better when you are stressed." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "Your sleep efficiency is better when you are relaxed." });
                    }
                }

            }

            // Tiredness -- DONE YEAH!!

            if (CNTTiredness > 4)
            {
                double[] Tiredness = new double[countOfDaysData];
                double[] tempMinutesAsleepTiredness = new double[countOfDaysData];
                double[] tempMinutesAwakeTiredness = new double[countOfDaysData];
                double[] tempSleepEfficiencyTiredness = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Tiredness != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Tiredness);
                        if (tempValue >= 0)
                        {
                            Tiredness[temp] = tempValue;
                            tempMinutesAsleepTiredness[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeTiredness[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "Your hours asleep are better when you are tired." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "Your hours asleep are worse when you are tired." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "You're more awake when you are tired." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "You're less awake when you are tired" });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "Your sleep efficiency is better when you are tired." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "Your sleep efficiency is worse when you are tired." });
                    }
                }

            }



            // Dream -- DONE YEAH!!

            if (CNTDream > 4)
            {
                double[] Dream = new double[countOfDaysData];
                double[] tempMinutesAsleepDream = new double[countOfDaysData];
                double[] tempMinutesAwakeDream = new double[countOfDaysData];
                double[] tempSleepEfficiencyDream = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Dream != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Dream);
                        if (tempValue >= 0)
                        {
                            Dream[temp] = tempValue;
                            tempMinutesAsleepDream[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeDream[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "Your hours asleep are better when you have more dreams." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "Your hours asleep are worse when you have more dreams." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "You're more awake when you have more dreams." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "You're less awake when you have more dreams." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "Your sleep efficiency is better when you have more dreams." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "Your sleep efficiency is better when you have less dreams." });
                    }
                }

            }

            // DigitalDev -- DONE YEAH!!

            if (CNTDigDeviceDuration > 4)
            {
                double[] DigitalDev = new double[countOfDaysData];
                double[] tempMinutesAsleepDigitalDev = new double[countOfDaysData];
                double[] tempMinutesAwakeDigitalDev = new double[countOfDaysData];
                double[] tempSleepEfficiencyDigitalDev = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DigDeviceDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DigDeviceDuration);
                        if (tempValue >= 0)
                        {
                            DigitalDev[temp] = tempValue;
                            tempMinutesAsleepDigitalDev[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeDigitalDev[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "Your hours asleep are better when you use digital device before bed time." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "Your hours asleep are worse when you use digital device before bed time." });
                    }
                }

                pearson = Correlation.Pearson(tempMinutesAwakeDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "You're more awake when you use digital device before bed time." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "You're less awake when you use digital device before bed time." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "Your sleep efficiency is better when you use digital device before bed time." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "Your sleep efficiency is worse when you use digital device before bed time." });
                    }
                }

            }


            // NapDuration -- DONE YEAH!!

            if (CNTNapDuration > 4)
            {
                double[] NapDuration = new double[countOfDaysData];
                double[] tempMinutesAsleepNapDuration = new double[countOfDaysData];
                double[] tempMinutesAwakeNapDuration = new double[countOfDaysData];
                double[] tempSleepEfficiencyNapDuration = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.NapDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.NapDuration);
                        if (tempValue >= 0)
                        {
                            NapDuration[temp] = tempValue;
                            tempMinutesAsleepNapDuration[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeNapDuration[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyNapDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

            }


            // NapTime -- DONE YEAH!!

            /* Pandita 2018/05/31 
            if (CNTNapTime > 4)
            {
                double[] NapTime = new double[CNTNapTime];
                double[] tempMinutesAsleepNapTime = new double[CNTNapTime];
                double[] tempMinutesAwakeNapTime = new double[CNTNapTime];
                double[] tempSleepEfficiencyNapTime = new double[CNTNapTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.NapTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.NapTime);
                        if (tempValue > 0)
                        {
                            NapTime[temp] = tempValue;
                            tempMinutesAsleepNapTime[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeNapTime[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyNapTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

            }*/

            // SocialFamily -- DONE YEAH!!

            if (CNTSocialFamily > 4)
            {
                double[] SocialFamily = new double[countOfDaysData];
                double[] tempMinutesAsleepSocialFamily = new double[countOfDaysData];
                double[] tempMinutesAwakeSocialFamily = new double[countOfDaysData];
                double[] tempSleepEfficiencySocialFamily = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialFamily != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialFamily);
                        if (tempValue >= 0)
                        {
                            SocialFamily[temp] = tempValue;
                            tempMinutesAsleepSocialFamily[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeSocialFamily[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencySocialFamily[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempMinutesAwakeSocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // SocialFriend -- DONE YEAH!!

            if (CNTSocialFriend > 4)
            {
                double[] SocialFriend = new double[countOfDaysData];
                double[] tempMinutesAsleepSocialFriend = new double[countOfDaysData];
                double[] tempMinutesAwakeSocialFriend = new double[countOfDaysData];
                double[] tempSleepEfficiencySocialFriend = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialFriend != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialFriend);
                        if (tempValue >= 0)
                        {
                            SocialFriend[temp] = tempValue;
                            tempMinutesAsleepSocialFriend[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeSocialFriend[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencySocialFriend[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempMinutesAwakeSocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // SocialFriend -- DONE YEAH!!

            if (CNTSocialMedia > 4)
            {
                double[] SocialMedia = new double[countOfDaysData];
                double[] tempMinutesAsleepSocialMedia = new double[countOfDaysData];
                double[] tempMinutesAwakeSocialMedia = new double[countOfDaysData];
                double[] tempSleepEfficiencySocialMedia = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialMedia != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialMedia);
                        if (tempValue >= 0)
                        {
                            SocialMedia[temp] = tempValue;
                            tempMinutesAsleepSocialMedia[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeSocialMedia[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencySocialMedia[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempMinutesAwakeSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // DinnerTime -- DONE YEAH!!
            /* Pandita 2018/05/31
            if (CNTDinnerTime > 4)
            {
                double[] DinnerTime = new double[CNTDinnerTime];
                double[] tempMinutesAsleepDinnerTime = new double[CNTDinnerTime];
                double[] tempMinutesAwakeDinnerTime = new double[CNTDinnerTime];
                double[] tempSleepEfficiencyDinnerTime = new double[CNTDinnerTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DinnerTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DinnerTime);
                        if (tempValue > 0)
                        {
                            DinnerTime[temp] = tempValue;
                            tempMinutesAsleepDinnerTime[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeDinnerTime[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyDinnerTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

            }
            */

            // ExerciseTime -- DONE YEAH!!

            if (CNTExerciseDuration > 4)
            {
                double[] ExerciseTime = new double[countOfDaysData];
                double[] tempMinutesAsleepExerciseTime = new double[countOfDaysData];
                double[] tempMinutesAwakeExerciseTime = new double[countOfDaysData];
                double[] tempSleepEfficiencyExerciseTime = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.ExerciseDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.ExerciseDuration);
                        if (tempValue > 0)
                        {
                            ExerciseTime[temp] = tempValue;
                            tempMinutesAsleepExerciseTime[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeExerciseTime[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyExerciseTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }

            }


            // AmbientTemp -- DONE YEAH!!

            if (CNTAmbientTemp > 4)
            {
                double[] AmbientTemp = new double[countOfDaysData];
                double[] tempMinutesAsleepAmbientTemp = new double[countOfDaysData];
                double[] tempAwakeningsCountAmbientTemp = new double[countOfDaysData];
                double[] tempMinutesAwakeAmbientTemp = new double[countOfDaysData];
                double[] tempMinutesToFallAsleepAmbientTemp = new double[countOfDaysData];
                double[] tempSleepEfficiencyAmbientTemp = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AmbientTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AmbientTemp);
                        if (tempValue > 0)
                        {
                            AmbientTemp[temp] = tempValue;
                            tempMinutesAsleepAmbientTemp[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeAmbientTemp[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyAmbientTemp[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }


                pearson = Correlation.Pearson(tempMinutesAwakeAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

            }


            // AmbientHumd -- DONE YEAH!!

            if (CNTAmbientHumd > 4)
            {
                double[] AmbientHumd = new double[countOfDaysData];
                double[] tempMinutesAsleepAmbientHumd = new double[countOfDaysData];
                double[] tempMinutesAwakeAmbientHumd = new double[countOfDaysData];
                double[] tempSleepEfficiencyAmbientHumd = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AmbientHumd != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AmbientHumd);
                        if (tempValue > 0)
                        {
                            AmbientHumd[temp] = tempValue;
                            tempMinutesAsleepAmbientHumd[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeAmbientHumd[temp] = MinutesAwake[identifier];
                            tempSleepEfficiencyAmbientHumd[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }


                pearson = Correlation.Pearson(tempMinutesAwakeAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }



                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }

            }


            // BodyTemp -- DONE YEAH!!

            if (CNTBodyTemp > 4)
            {
                double[] BodyTemp = new double[countOfDaysData];
                double[] tempMinutesAsleepBodyTemp = new double[countOfDaysData];
                double[] tempMinutesAwakeBodyTemp = new double[countOfDaysData];
                double[] tempAwakeningsCountBodyTemp = new double[countOfDaysData];
                double[] tempMinutesToFallAsleepBodyTemp = new double[countOfDaysData];
                double[] tempSleepEfficiencyBodyTemp = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.BodyTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.BodyTemp);
                        if (tempValue > 0)
                        {
                            BodyTemp[temp] = tempValue;
                            tempMinutesAsleepBodyTemp[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeBodyTemp[temp] = MinutesAwake[identifier];
                            tempMinutesAwakeBodyTemp[temp] = MinutesAwake[identifier];
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
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

                pearson = Correlation.Pearson(tempMinutesAwakeBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAwakeCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

            }


            // Hormone -- DONE YEAH!!

            if (CNTHormone > 4)
            {
                double[] Hormone = new double[countOfDaysData];
                double[] tempMinutesAsleepHormone = new double[countOfDaysData];
                double[] tempMinutesAwakeHormone = new double[countOfDaysData];
                double[] tempAwakeningsCountHormone = new double[countOfDaysData];
                double[] tempMinutesToFallAsleepHormone = new double[countOfDaysData];
                double[] tempSleepEfficiencyHormone = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Hormone != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Hormone);
                        if (tempValue > 0)
                        {
                            Hormone[temp] = tempValue;
                            tempMinutesAsleepHormone[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeHormone[temp] = MinutesAwake[identifier];
                            tempMinutesAwakeHormone[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "Your hours asleep are better as the next period approaches." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "Your hours asleep are worse as the next period approaches." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "You're more awake as the next period approaches." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "You're less awake as the next period approaches." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "Your sleep efficiency is better as the next period approaches." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "Your sleep efficiency is worse as the next period approaches." });
                    }
                }

            }

            // WatchTV -- DONE YEAH!!

            if (CNTTVDuration > 4)
            {
                double[] WatchTV = new double[countOfDaysData];
                double[] tempMinutesAsleepWatchTV = new double[countOfDaysData];
                double[] tempMinutesAwakeWatchTV = new double[countOfDaysData];
                double[] tempSleepEfficiencyWatchTV = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.TVDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.TVDuration);
                        if (tempValue > 0)
                        {
                            WatchTV[temp] = tempValue;
                            tempMinutesAsleepWatchTV[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeWatchTV[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "Your hours asleep are better when you watch TV until late." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "Your hours asleep are worse when you watch TV until late." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "You're more awake when you watch TV until late." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "You're less awake when you watch TV until late." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "Your sleep efficiency is better when you watch TV until late." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "Your sleep efficiency is worse when you watch TV until late." });
                    }
                }

            }

            // ExerciseDuration -- DONE YEAH!!

            if (CNTExerciseIntensity > 4)
            {
                double[] ExerciseDuration = new double[countOfDaysData];
                double[] tempMinutesAsleepExerciseDuration = new double[countOfDaysData];
                double[] tempMinutesAwakeExerciseDuration = new double[countOfDaysData];
                double[] tempSleepEfficiencyExerciseDuration = new double[countOfDaysData];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.ExerciseIntensity != null)
                    {
                        tempValue = Convert.ToDouble(daysData.ExerciseIntensity);
                        if (tempValue > 0)
                        {
                            ExerciseDuration[temp] = tempValue;
                            tempMinutesAsleepExerciseDuration[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeExerciseDuration[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "Your hours asleep are better when you work out more" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "Your hours asleep are worse when you work out more." });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "You're more awake when you work out more." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "You're less awake when you work out more." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "Your sleep efficiency is better when you work out more." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "Oops! Your sleep efficiency is worse when you work out more." });
                    }
                }

            }

            // SnackTime -- DONE YEAH!!
            /* Pandita 2018/05/31 
            if (CNTSnackTime > 4)
            {
                double[] SnackTime = new double[CNTSnackTime];
                double[] tempMinutesAsleepSnackTime = new double[CNTSnackTime];
                double[] tempMinutesAwakeSnackTime = new double[CNTSnackTime];
                double[] tempSleepEfficiencySnackTime = new double[CNTSnackTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SnackTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SnackTime);
                        if (tempValue > 0)
                        {
                            SnackTime[temp] = tempValue;
                            tempMinutesAsleepSnackTime[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeSnackTime[temp] = MinutesAwake[identifier];
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
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempMinutesAwakeSnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAwakeCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }

            }

            
          // WorkTime -- DONE YEAH!!

          if (CNTWorkTime > 4)
          {
              double[] WorkTime = new double[CNTWorkTime];
              double[] tempMinutesAsleepWorkTime = new double[CNTWorkTime];
              double[] tempMinutesAwakeWorkTime = new double[CNTWorkTime];
              double[] tempSleepEfficiencyWorkTime = new double[CNTWorkTime];

              // counters back to zero
              temp = 0;
              identifier = 0;

              foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
              {
                  if (daysData.WorkTime != null)
                  {
                      tempValue = Convert.ToDouble(daysData.WorkTime);
                      if (tempValue > 0)
                      {
                          WorkTime[temp] = tempValue;
                          tempMinutesAsleepWorkTime[temp] = MinutesAsleep[identifier];
                          tempMinutesAwakeWorkTime[temp] = MinutesAwake[identifier];
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
                      minutesAsleepCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have longer time asleep." });
                  }
                  else if (pearson < 0)
                  {
                      minutesAsleepCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have shorter time asleep." });
                  }
              }


              pearson = Correlation.Pearson(tempMinutesAwakeWorkTime, WorkTime);
              if (Math.Abs(pearson) >= 0.3)
              {
                  if (pearson > 0)
                  {
                      minutesAwakeCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have more awakenings." });
                  }
                  else if (pearson < 0)
                  {
                      minutesAwakeCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have less awakenings." });
                  }
              }


              pearson = Correlation.Pearson(tempSleepEfficiencyWorkTime, WorkTime);
              if (Math.Abs(pearson) >= 0.3)
              {
                  if (pearson > 0)
                  {
                      sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, your sleep efficiency tends to become better." });
                  }
                  else if (pearson < 0)
                  {
                      sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, your sleep efficiency tends to become worse." });
                  }
              }

          }*/
          // Work Duration -- DONE YEAH!!

          if (CNTWorkDuration > 4)
          {
              double[] WorkDuration = new double[countOfDaysData];
              double[] tempMinutesAsleepWorkDuration = new double[countOfDaysData];
              double[] tempMinutesAwakeWorkDuration = new double[countOfDaysData];
              double[] tempSleepEfficiencyWorkDuration = new double[countOfDaysData];

              // counters back to zero
              temp = 0;
              identifier = 0;

              foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
              {
                  if (daysData.WorkDuration != null)
                  {
                      tempValue = Convert.ToDouble(daysData.WorkDuration);
                      if (tempValue > 0)
                      {
                          WorkDuration[temp] = tempValue;
                          tempMinutesAsleepWorkDuration[temp] = MinutesAsleep[identifier];
                          tempMinutesAwakeWorkDuration[temp] = MinutesAwake[identifier];
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
                      minutesAsleepCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have longer time asleep." });
                  }
                  else if (pearson < 0)
                  {
                      minutesAsleepCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have shorter time asleep." });
                  }
              }


              pearson = Correlation.Pearson(tempMinutesAwakeWorkDuration, WorkDuration);
              if (Math.Abs(pearson) >= 0.3)
              {
                  if (pearson > 0)
                  {
                      minutesAwakeCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have more awakenings." });
                  }
                  else if (pearson < 0)
                  {
                      minutesAwakeCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have less awakenings." });
                  }
              }


              pearson = Correlation.Pearson(tempSleepEfficiencyWorkDuration, WorkDuration);
              if (Math.Abs(pearson) >= 0.3)
              {
                  if (pearson > 0)
                  {
                      sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, your sleep efficiency tends to become better." });
                  }
                  else if (pearson < 0)
                  {
                      sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, your sleep efficiency tends to become worse." });
                  }
              }

          }
          

            // Music -- DONE YEAH!!

            if (CNTMusicDuration > 4)
                {
                    double[] Music = new double[countOfDaysData];
                    double[] tempMinutesAsleepMusic = new double[countOfDaysData];
                    double[] tempMinutesAwakeMusic = new double[countOfDaysData];
                    double[] tempSleepEfficiencyMusic = new double[countOfDaysData];

                    // counters back to zero
                    temp = 0;
                    identifier = 0;

                    foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                    {
                        if (daysData.MusicDuration != null)
                        {
                            tempValue = Convert.ToDouble(daysData.MusicDuration);
                            if (tempValue > 0)
                            {
                                Music[temp] = tempValue;
                                tempMinutesAsleepMusic[temp] = MinutesAsleep[identifier];
                                tempMinutesAwakeMusic[temp] = MinutesAwake[identifier];
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
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempMinutesAwakeMusic, Music);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempSleepEfficiencyMusic, Music);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                        }
                    }

                }
                // Social Media-- DONE YEAH!!

                if (CNTSocialFriend > 4)
                {
                    double[] SocialMedia = new double[countOfDaysData];
                    double[] tempMinutesAsleepSocialMedia = new double[countOfDaysData];
                    double[] tempMinutesAwakeSocialMedia = new double[countOfDaysData];
                    double[] tempSleepEfficiencySocialMedia = new double[countOfDaysData];

                    // counters back to zero
                    temp = 0;
                    identifier = 0;

                    foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                    {
                        if (daysData.SocialFriend != null)
                        {
                            tempValue = Convert.ToDouble(daysData.SocialFriend);
                            if (tempValue > 0)
                            {
                                SocialMedia[temp] = tempValue;
                                tempMinutesAsleepSocialMedia[temp] = MinutesAsleep[identifier];
                                tempMinutesAwakeSocialMedia[temp] = MinutesAwake[identifier];
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
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempMinutesAwakeSocialMedia, SocialMedia);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempSleepEfficiencySocialMedia, SocialMedia);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                        }
                    }

                }


                // Social Media-- DONE YEAH!!

                if (CNTGamesDuration > 4)
                {
                    double[] VideoGames = new double[countOfDaysData];
                    double[] tempMinutesAsleepVideoGames = new double[countOfDaysData];
                    double[] tempMinutesAwakeVideoGames = new double[countOfDaysData];
                    double[] tempSleepEfficiencyVideoGames = new double[countOfDaysData];

                    // counters back to zero
                    temp = 0;
                    identifier = 0;

                    foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                    {
                        if (daysData.GamesDuration != null)
                        {
                            tempValue = Convert.ToDouble(daysData.GamesDuration);
                            if (tempValue > 0)
                            {
                                VideoGames[temp] = tempValue;
                                tempMinutesAsleepVideoGames[temp] = MinutesAsleep[identifier];
                                tempMinutesAwakeVideoGames[temp] = MinutesAwake[identifier];
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
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempMinutesAwakeVideoGames, VideoGames);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempSleepEfficiencyVideoGames, VideoGames);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                        }
                    }

                }

                // Social Media-- DONE YEAH!!

                if (CNTSchoolStress > 4)
                {
                    double[] Assignments = new double[countOfDaysData];
                    double[] tempMinutesAsleepAssignments = new double[countOfDaysData];
                    double[] tempMinutesAwakeAssignments = new double[countOfDaysData];
                    double[] tempSleepEfficiencyAssignments = new double[countOfDaysData];

                    // counters back to zero
                    temp = 0;
                    identifier = 0;

                    foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                    {
                        if (daysData.SchoolStress != null)
                        {
                            tempValue = Convert.ToDouble(daysData.SchoolStress);
                            if (tempValue > 0)
                            {
                                Assignments[temp] = tempValue;
                                tempMinutesAsleepAssignments[temp] = MinutesAsleep[identifier];
                                tempMinutesAwakeAssignments[temp] = MinutesAwake[identifier];
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
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempMinutesAwakeAssignments, Assignments);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            minutesAwakeCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                    }


                    pearson = Correlation.Pearson(tempSleepEfficiencyAssignments, Assignments);
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                        else if (pearson < 0)
                        {
                            sleepEffiencyCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                        }
                    }
                }

                // 20170216 Pandita: Correlation Coefficients are all positive values!!! "positive" indicates color
                foreach (var entry in minutesAsleepCorrList)
                {
                    if (entry.Coefficient < 0)
                    {
                        //entry.Coefficient = (entry.Coefficient) * -1;
                        entry.Positive = false;
                        // 20170216 Pandita: bad factor, red color
                    }
                    else
                    {
                        entry.Positive = true; // good factor, blue color
                                               // rather than "Positive", maybe "Good" is more expressive?

                    }
                }
                // 20170216 Pandita: red color indicates bad factor, not negative correlation. 
                // So for awakeCount, negatively correlated factor should be blue color, 
                // as it's a good factor for this sleep metric and lower value of this factor is preferred 
                /*
                foreach (var entry in awakeCountCorrList)
                {
                    if (entry.Coefficient < 0)
                    {
                        entry.Coefficient = (entry.Coefficient) * -1;
                        entry.Positive = false;
                    }
                    else
                    {
                        entry.Positive = true;
                    }
                }*/
                foreach (var entry in awakeCountCorrList)
                {
                    if (entry.Coefficient < 0)
                    {
                        //entry.Coefficient = (entry.Coefficient) * -1;
                        entry.Positive = true; // if negatively correlated, then a good factor
                    }
                    else
                    {
                        entry.Positive = false;
                    }
                }
                foreach (var entry in minutesAwakeCorrList)
                {
                    if (entry.Coefficient < 0)
                    {
                        //entry.Coefficient = (entry.Coefficient) * -1;
                        entry.Positive = true; // if negatively correlated, then a good factor
                    }
                    else
                    {
                        entry.Positive = false;
                    }
                }
                foreach (var entry in sleepEffiencyCorrList)
                {
                    if (entry.Coefficient < 0)
                    {
                        //entry.Coefficient = (entry.Coefficient) * -1;
                        entry.Positive = false;
                    }
                    else
                    {
                        entry.Positive = true;
                    }
                }

                syncViewModel.MinutesAsleepCorrList = minutesAsleepCorrList.OrderByDescending(o => o.Coefficient).ToList();
                //syncViewModel.AwakeCountCorrList = awakeCountCorrList.OrderByDescending(o => o.Coefficient).ToList();
                syncViewModel.SleepEffiencyCorrList = sleepEffiencyCorrList.OrderByDescending(o => o.Coefficient).ToList();
                syncViewModel.MinutesAwakeCorrList = minutesAwakeCorrList.OrderByDescending(o => o.Coefficient).ToList();

                return syncViewModel;

            }
        }
    }
