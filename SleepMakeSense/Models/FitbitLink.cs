using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public class FitBitLink
    {
        // Adds Username Link between the user logging in and the token from the Fitbit API

        //Username to ref the Auth table
        public string UserName { get; set; }

        // Fitbit tokens, named after token in Fitbit controller.cs
        public string FitbitAuthToken { get; set; }
        public string FitbitAuthTokenSecret { get; set; }
        public string FitbitUserId { get; set; }

    }
}