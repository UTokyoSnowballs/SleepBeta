using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using SleepMakeSense.Models;
using System.Data.SqlClient;
//Fitbit Portable
using Fitbit.Models;
//UserControll Intergration
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using MathNet.Numerics.Statistics;
using Microsoft.AspNet.Identity;

namespace SleepMakeSense.Controllers
{
    public class FitbitController : Controller
    {



        //
        // GET: /Fitbit/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {
            var appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
            };
            //make sure you've set these up in Web.Config under <appSettings>:

            Session["AppCredentials"] = appCredentials;

            //Provide the App Credentials. You get those by registering your app at dev.fitbit.com
            //Configure Fitbit authenticaiton request to perform a callback to this constructor's Callback method
            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");
            string[] scopes = new string[] { "profile", "activity", "sleep", "weight", "nutrition" };



            string authUrl = authenticator.GenerateAuthUrl(scopes, null);

            


            return Redirect(authUrl);
        }

        //Final step. Take this authorization information and use it in the app
        public async Task<ActionResult> Callback()
        {
            
            FitbitAppCredentials appCredentials = (FitbitAppCredentials)Session["AppCredentials"];

            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");

            string code = Request.Params["code"];

            OAuth2AccessToken accessToken = await authenticator.ExchangeAuthCodeForAccessTokenAsync(code);

            //Store credentials in FitbitClient. The client in its default implementation manages the Refresh process
            FitbitClient fitbitClient = GetFitbitClient(accessToken);

            syncFitbitCred(accessToken);

            return View();

        }

        private void syncFitbitCred(OAuth2AccessToken accessToken)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                Models.Database Db = new Models.Database();

                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                TokenManagement userToken = (from a in Db.TokenManagements
                                             where a.AspNetUserId.Equals(userId)
                                             select a).FirstOrDefault();


                if (userToken == null)
                {
                    userToken = new TokenManagement();
                    userToken.AspNetUserId = userId;
                    Db.TokenManagements.Add(userToken);
                }

                userToken.DateChanged = DateTime.UtcNow;
                userToken.Token = accessToken.Token;
                userToken.TokenType = accessToken.TokenType;
                userToken.ExpiresIn = accessToken.ExpiresIn;
                userToken.RefreshToken = accessToken.RefreshToken;

                Db.SaveChanges();

            }
        }

        public ActionResult ConnectFitbit()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                throw new Exception("You Must be Loged in to sync Fitbit Data");
            }
            Models.Database Db = new Models.Database();
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var userToken = (from a in Db.TokenManagements
                             where a.AspNetUserId.Equals(userId)
                             select a).First();
            if (userToken == null)
            {
                Authorize();
            }
            else
            {
                OAuth2AccessToken accessToken = new OAuth2AccessToken()
                {
                    Token = userToken.Token,
                    TokenType = userToken.TokenType,
                    ExpiresIn = userToken.ExpiresIn,
                    RefreshToken = userToken.RefreshToken,
                    UserId = userToken.UserId,
                    UtcExpirationDate = userToken.DateChanged.AddSeconds(userToken.ExpiresIn)
                };
                GetFitbitClient(accessToken);
                if (!accessToken.IsFresh())
                {
                    await RefreshToken();
                }
            }
            return View("Callback");
        }


        /// <summary>
        /// In this example we show how to explicitly request a token refresh. However, FitbitClient V2 on its default implementation provide an OOB automatic token refresh.
        /// </summary>
        /// <returns>A refreshed token</returns>
        public async Task<ActionResult> RefreshToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = await fitbitClient.RefreshOAuth2TokenAsync();

            return View("Callback");
        }

        public async Task<ActionResult> TestToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = fitbitClient.AccessToken;

            ViewBag.UserProfile = await fitbitClient.GetUserProfileAsync();

            return View("TestToken");
        }

        /*
        public string TestTimeSeries()
        {
            FitbitClient client = GetFitbitClient();

            var results = client.GetTimeSeries(TimeSeriesResourceType.DistanceTracker, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            string sOutput = "";
            foreach (var result in results.DataList)
            {
                sOutput += result.DateTime.ToString() + " - " + result.Value.ToString();
            }

            return sOutput;

        }
        
        public ActionResult LastWeekDistance()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList results = client.GetTimeSeries(TimeSeriesResourceType.Distance, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(results);
        }
        */

        /*
        public async Task<ActionResult> LastWeekSteps()
        {

            FitbitClient client = GetFitbitClient();

            var response = await client.GetTimeSeriesIntAsync(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(response);
        
        }

            */
        /*
        //example using the direct API call getting all the individual logs
        public async Task<string> DayFat(DateTime date)
        {

            FitbitClient client = GetFitbitClient();
             
            var fat = await client.GetFatAsync(date, DateRangePeriod.OneDay);
            String fatString = fat.ToString();

            if (fatString == null || fatString == " ") //succeeded but no records
            {
                return null;
            }
            return fatString;
        }

        public async Task<string> DayWater(DateTime date)
        {
            FitbitClient client = GetFitbitClient();

            var water = await client.GetWaterAsync(date, DateRangePeriod.OneDay);
            String waterString = water.ToString();
            if (waterString == null || waterString == " ")
            {
                return null;
            }

            return waterString;
        }
        
        public async Task<string[]> DaySteps(DateTime date)
        {
            FitbitClient client = GetFitbitClient();
            var steps = await client.GetDayActivityAsync(date, client.ToString());


            if ()

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

        /*

        /// <summary>
        /// This requires the Fitbit staff approval of your app before it can be called
        /// </summary>
        /// <returns></returns>
        public string TestIntraDay()
        {
            FitbitClient client = new FitbitClient(ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ConfigurationManager.AppSettings["FitbitConsumerSecret"],
                Session["FitbitAuthToken"].ToString(),
                Session["FitbitAuthTokenSecret"].ToString());

            IntradayData data = client.GetIntraDayTimeSeries(IntradayResourceType.Steps, new DateTime(2012, 5, 28, 11, 0, 0), new TimeSpan(1, 0, 0));

            string result = "";

            foreach (IntradayDataValues intraData in data.DataSet)
            {
                result += intraData.Time.ToShortTimeString() + " - " + intraData.Value + Environment.NewLine;
            }

            return result;

        }
        */




        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        public FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
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


       
    }
}