using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public class DiaryData
    {

        public string UserName { get; set; } //used to link the users email with the link. Null if not logged in
        public DateTime DateTime { get; set; }
        public string WakeUpFreshness { get; set; }

        // 18 factors
        public string Coffee { get; set; }
        public string CoffeeTime { get; set; }
        public string Alcohol { get; set; }

        public string Mood { get; set; }
        public string Stress { get; set; }
        public string Tiredness { get; set; }
        public string Dream { get; set; }

        public string DigitalDev { get; set; }
        public string Light { get; set; }
        public string NapDuration { get; set; }
        public string NapTime { get; set; }
        public string SocialActivity { get; set; }
        public string DinnerTime { get; set; }
        public string ExerciseTime { get; set; }

        public string AmbientTemp { get; set; }
        public string AmbientHumd { get; set; }

        public string BodyTemp { get; set; }
        public string Hormone { get; set; }
    }
}