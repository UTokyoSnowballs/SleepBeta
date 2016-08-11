using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Added by Piranita
using Fitbit.Api;
using Fitbit.Models;
using Fitbit.Api.Portable;
using Fitbit.Api.Portable.OAuth2;
using System.Configuration;
using System.Threading.Tasks;


namespace SleepExplorer.Controllers
{
    public class FitbitController : Controller
    {
        // GET: Fitbit
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //Added by Piranita 
        public ActionResult Devices()
        {
            /*
            if (ViewBag.AccessToken == null)
            {
                ViewBag.FitbitConnected = false;

            }
            else
            {
                ViewBag.FitbitConnected = true; // "Welcome Fitbit User " + Session["FitbitUserId"].ToString();
            }*/

            return View("Devices");
        }
        public ActionResult Sync()
        {
            return View("Sync");
        }

        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {
           
            var appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitConsumerSecret"]
            };
            //make sure you've set these up in Web.Config under <appSettings>:

            Session["AppCredentials"] = appCredentials;

            //Provide the App Credentials. You get those by registering your app at dev.fitbit.com
            //Configure Fitbit authenticaiton request to perform a callback to this constructor's Callback method
            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");

            // Added by Piranita: only "profile" doesnt redirect to Fitbit authentication page!! Need to add "activity" etc.
            string[] scopes = new string[] { "profile","activity","heartrate","location","nutrition","settings","sleep","social","weight" };

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
            var fitbitClient = GetFitbitClient(accessToken);

            Session["FitbitClient"] = fitbitClient;
            Session["AccessToken"] = accessToken;

            ViewBag.AccessToken = accessToken;

            //Addede by Piranita
            //return View();
            //return RedirectToAction("Devices", "Fitbit");
            return RedirectToAction("Sync", "Fitbit");
           
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

        /* functions below are not tested 

        /// <summary>
        /// In this example we show how to explicitly request a token refresh. However, FitbitClient V2 on its default implementation provide an OOB automatic token refresh.
        /// </summary>
        /// <returns>A refreshed token</returns>
        public async Task<ActionResult> RefreshToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = await fitbitClient.RefreshOAuth2Token();

            return View("Sync");
        }

        public async Task<ActionResult> TestToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = fitbitClient.AccessToken;

            ViewBag.UserProfile = await fitbitClient.GetUserProfileAsync();

            return View("Sync");
        }
        public async Task<ActionResult> DevicesInfo()
        {
            var fitbitClient = GetFitbitClient();
            var response = await fitbitClient.GetDevicesAsync();
            return View(response);
        }

        public async Task<ActionResult> Friends()
        {
            var fitbitClient = GetFitbitClient();
            var response = await fitbitClient.GetFriendsAsync();
            return View("DeviceInfo", response);
        }

        public async Task<ActionResult> UserProfile()
        {
            var client = GetFitbitClient();
            var response = await client.GetUserProfileAsync();
            return View(response);
        }

        public async Task<ActionResult> LastWeekDistance()
        {
            var client = GetFitbitClient();
            var response = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Distance, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
            return View("TimeSeriesDataList", response);
        }

        public async Task<ActionResult> LastWeekSteps()
        {
            var client = GetFitbitClient();
            var response = await client.GetTimeSeriesIntAsync(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);
            return View("TimeSeriesDataList", response);
        }*/

    }
}