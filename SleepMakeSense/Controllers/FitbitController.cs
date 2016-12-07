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

        private SleepbetaDataContext Db = new SleepbetaDataContext();

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

             return RedirectToAction("Index", "Home");
            //return RedirectToAction("Sync", "UserDatas");


        }

        private void syncFitbitCred(OAuth2AccessToken accessToken)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                TokenManagement userToken = (from a in Db.TokenManagements
                                             where a.AspNetUserId.Equals(userId)
                                             select a).FirstOrDefault();


                if (userToken == null)
                {
                    userToken = new TokenManagement();
                    userToken.AspNetUserId = userId;
                    Db.SubmitChanges();
                }

                userToken.DateChanged = DateTime.UtcNow;
                userToken.Token = accessToken.Token;
                userToken.TokenType = accessToken.TokenType;
                userToken.ExpiresIn = accessToken.ExpiresIn;
                userToken.RefreshToken = accessToken.RefreshToken;

   

            }
        }


        public ActionResult ConnectFitbit()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                throw new Exception("You Must be Loged in to sync Fitbit Data");
            }
            bool fitbitConnected = false;
            OAuth2AccessToken accessToken = new OAuth2AccessToken();
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            IEnumerable <TokenManagement> userToken = from a in Db.TokenManagements
                             where a.AspNetUserId.Equals(userId)
                             select a;
            foreach (TokenManagement data in userToken)
            {
                if (data.AspNetUserId == userId && data.ExpiresIn == 28800)
                {
                    fitbitConnected = true;
                    accessToken.Token = data.Token;
                    accessToken.TokenType = data.TokenType;
                    accessToken.ExpiresIn = data.ExpiresIn;
                    accessToken.RefreshToken = data.RefreshToken;
                    accessToken.UserId = data.UserId;
                    accessToken.UtcExpirationDate = data.DateChanged.AddSeconds(data.ExpiresIn);

                }
            }

            if (fitbitConnected == true)
            {
                //Loading Session data when the user has does not have Key creds in their session
                var appCredentials = new FitbitAppCredentials()
                {
                    ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                    ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
                };

                GetFitbitClient(accessToken);
                syncFitbitCred(accessToken);

             return View("Callback");
              //  return RedirectToAction("Sync", "UserDatas");
            }

            return Authorize();
        }

        public ActionResult DirectToSync()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                throw new Exception("You Must be Loged in to sync Fitbit Data");
            }
            // 20161108 Pandita
            bool fitbitConnected = false;
            OAuth2AccessToken accessToken = new OAuth2AccessToken();
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            IEnumerable <TokenManagement> userToken = from a in Db.TokenManagements
                            where a.AspNetUserId.Equals(userId)
                            select a;
            foreach (TokenManagement data in userToken)
            {
                if (data.AspNetUserId == userId && data.ExpiresIn == 28800)
                {
                    fitbitConnected = true;
                    accessToken.Token = data.Token;
                    accessToken.TokenType = data.TokenType;
                    accessToken.ExpiresIn = data.ExpiresIn;
                    accessToken.RefreshToken = data.RefreshToken;
                    accessToken.UserId = data.UserId;
                    accessToken.UtcExpirationDate = data.DateChanged.AddSeconds(data.ExpiresIn);

                }
            }

            if (fitbitConnected == true)
            {
                //Loading Session data when the user has does not have Key creds in their session
                var appCredentials = new FitbitAppCredentials()
                {
                    ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                    ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
                };

                GetFitbitClient(accessToken);
                syncFitbitCred(accessToken);
                //     return View("Callback");
                return RedirectToAction("Sync", "UserDatas");
            }

            return Authorize();
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