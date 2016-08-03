using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Controllers
{
    public class FitbitControllerOld
    {
        /* OLD
using Fitbit;
using Fitbit.Api;
using Fitbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SleepMakeSense.Models;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Net;
*/


        // OLD
        // GET: /Fitbit/
        /*

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Devices()
        {
            // Pandita: check whether user already connected devices
            if (Session["FitbitAuthToken"] == null ||
                Session["FitbitAuthTokenSecret"] == null ||
                Session["FitbitUserId"] == null)
            {
                ViewBag.FitbitConnected = false;

            }
            else
            {
                ViewBag.FitbitConnected = true; // "Welcome Fitbit User " + Session["FitbitUserId"].ToString();
            }

            return View("Devices");
        }

        public ActionResult Tablero()
        {
            return View("Tablero");
        }
        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {

            //make sure you've set these up in Web.Config under <appSettings>:
            string ConsumerKey = ConfigurationManager.AppSettings["FitbitConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["FitbitConsumerSecret"];


            Fitbit.Api.Authenticator authenticator = new Fitbit.Api.Authenticator(ConsumerKey,
                                                                                    ConsumerSecret,
                                                                                    "http://api.fitbit.com/oauth/request_token",
                                                                                    "http://api.fitbit.com/oauth/access_token",
                                                                                    "http://api.fitbit.com/oauth/authorize");
            RequestToken token = authenticator.GetRequestToken();
            Session.Add("FitbitRequestTokenSecret", token.Secret.ToString()); //store this somehow, like in Session as we'll need it after the Callback() action

            //note: at this point the RequestToken object only has the Token and Secret properties supplied. Verifier happens later.

            string authUrl = authenticator.GenerateAuthUrlFromRequestToken(token, true);


            return Redirect(authUrl);
        }

        //Final step. Take this authorization information and use it in the app
        public ActionResult Callback()
        {
            RequestToken token = new RequestToken();
            token.Token = Request.Params["oauth_token"];
            token.Secret = Session["FitbitRequestTokenSecret"].ToString();
            token.Verifier = Request.Params["oauth_verifier"];

            string ConsumerKey = ConfigurationManager.AppSettings["FitbitConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["FitbitConsumerSecret"];

            //this is going to go back to Fitbit one last time (server to server) and get the user's permanent auth credentials

            //create the Authenticator object
            Fitbit.Api.Authenticator authenticator = new Fitbit.Api.Authenticator(ConsumerKey,
                                                                                    ConsumerSecret,
                                                                                    "http://api.fitbit.com/oauth/request_token",
                                                                                    "http://api.fitbit.com/oauth/access_token",
                                                                                    "http://api.fitbit.com/oauth/authorize");


            //execute the Authenticator request to Fitbit
            AuthCredential credential = authenticator.ProcessApprovedAuthCallback(token);

            //here, we now have everything we need for the future to go back to Fitbit's API (STORE THESE):
            //  credential.AuthToken;
            //  credential.AuthTokenSecret;
            //  credential.UserId;

            // For demo, put this in the session managed by ASP.NET
            Session["FitbitAuthToken"] = credential.AuthToken;
            Session["FitbitAuthTokenSecret"] = credential.AuthTokenSecret;
            Session["FitbitUserId"] = credential.UserId;

            return RedirectToAction("Devices", "Fitbit"); 

        }

        public string TestTimeSeries()
        {
            FitbitClient client = GetFitbitClient();

            // This is to take the last seven days of data , how to automatically update it ? Or take over all the data ?
            var results = client.GetTimeSeries(TimeSeriesResourceType.DistanceTracker, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
            // What results is a structure ?

            string sOutput = "";
            foreach (var result in results.DataList)
            {
                sOutput += result.DateTime.ToString() + " - " + result.Value.ToString();
            }

            return sOutput;

        }
        */
        // Pandita: retrieve data, pass it to view and insert data to DB on the view. 
        /* Moved to UserDataAllsController.cs

        public ActionResult Sync()
        {

            FitbitClient client = GetFitbitClient();
            //TimeSeriesDataList results = client.GetTimeSeries(TimeSeriesResourceType.MinutesAsleep, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
           
            List<UserDataDaily> results = new List<UserDataDaily>(); 

            TimeSeriesDataList minutesAsleep = client.GetTimeSeries(TimeSeriesResourceType.MinutesAsleep, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAsleep.DataList) {
                results.Add(new UserDataDaily(data.DateTime,data.Value,null,null));
            }

            TimeSeriesDataList Step = client.GetTimeSeries(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
            TimeSeriesDataList Water = client.GetTimeSeries(TimeSeriesResourceType.Water, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            foreach (SleepMakeSense.Models.UserDataDaily item in results)
            {
                foreach (Fitbit.Models.TimeSeriesDataList.Data data in Step.DataList.Where(data => data.DateTime == item.DateStamp))
                {
                    item.Steps = data.Value;
                }

                foreach (Fitbit.Models.TimeSeriesDataList.Data data in Water.DataList.Where(data => data.DateTime == item.DateStamp))
                {
                    item.Water = data.Value;
                }
                
            }

            return View(results);
        }
        */
        /*
        public ActionResult LastWeekDistance()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList results = client.GetTimeSeries(TimeSeriesResourceType.Distance, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(results);
        }

        public ActionResult LastWeekSteps()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList results = client.GetTimeSeries(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(results);

        }

        //example using the direct API call getting all the individual logs
        public ActionResult MonthFat(string id)
        {
            DateTime dateStart = Convert.ToDateTime(id);

            FitbitClient client = GetFitbitClient();

            Fat fat = client.GetFat(dateStart, DateRangePeriod.OneMonth);

            if (fat == null || fat.FatLogs == null) //succeeded but no records
            {
                fat = new Fat();
                fat.FatLogs = new List<FatLog>();
            }
            return View(fat);
            // Pandita: Phrase mean tap MonthFat data has been taken out and then displayed in the View ? Can I get the data directly to the DB?
            // answer: now the solution is to pass the data to view and then update database from view; seems not a good idea to update database from controller
            // you pollute the code in controller. LOL.  2015/07/10. Fuck, i feel so upset! nothing works.

        }

        //example using the time series, one per day
        public ActionResult LastYearFat()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList fatSeries = client.GetTimeSeries(TimeSeriesResourceType.Fat, DateTime.UtcNow, DateRangePeriod.OneYear);

            return View(fatSeries);

        }

        //example using the direct API call getting all the individual logs
        public ActionResult MonthWeight(string id)
        {
            DateTime dateStart = Convert.ToDateTime(id);

            FitbitClient client = GetFitbitClient();

            Weight weight = client.GetWeight(dateStart, DateRangePeriod.OneMonth);

            if (weight == null || weight.Weights == null) //succeeded but no records
            {
                weight = new Weight();
                weight.Weights = new List<WeightLog>();
            }
            return View(weight);

        }

        //example using the time series, one per day
        public ActionResult LastYearWeight()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList weightSeries = client.GetTimeSeries(TimeSeriesResourceType.Weight, DateTime.UtcNow, DateRangePeriod.OneYear);

            return View(weightSeries);

        }

        /// <summary>
        /// This requires the Fitbit staff approval of your app before it can be called
        /// </summary>
        /// <returns></returns>
//        public string StepIntraDay()
          
        public ActionResult StepIntraDay()
        {
            FitbitClient client = new FitbitClient(ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ConfigurationManager.AppSettings["FitbitConsumerSecret"],
                Session["FitbitAuthToken"].ToString(),
                Session["FitbitAuthTokenSecret"].ToString());

            IntradayData data = client.GetIntraDayTimeSeries(IntradayResourceType.Steps, new DateTime(2015, 8, 4, 8, 0, 0), new TimeSpan(1, 0, 0));
    
            return View(data);

        }

        [HttpPost]
        public ActionResult SleepIntraDay(Date model)
        {
            FitbitClient client = new FitbitClient(ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ConfigurationManager.AppSettings["FitbitConsumerSecret"],
                Session["FitbitAuthToken"].ToString(),
                Session["FitbitAuthTokenSecret"].ToString());

            //SleepData data = client.GetSleep(new DateTime(2015, 8, 15)); 
            SleepData data = client.GetSleep(new DateTime(model.Year, model.Month, model.Day)); 

            return View(data.Sleep);

        }

        //Pandita: change it from private to public. Why defined it as "private" here??? Out of security concern??
        //private FitbitClient GetFitbitClient()
        public FitbitClient GetFitbitClient()
        {
            FitbitClient client = new FitbitClient(ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ConfigurationManager.AppSettings["FitbitConsumerSecret"],
                Session["FitbitAuthToken"].ToString(),
                Session["FitbitAuthTokenSecret"].ToString());

            return client;
            
        }
        */
    }
}