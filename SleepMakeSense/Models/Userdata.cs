using System.ComponentModel.DataAnnotations;
using System.Globalization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using Fitbit;
using Fitbit.Api;
using Fitbit.Models;

namespace SleepMakeSense.Models
{
    public class Userdata
    {
        public int Id { get; set; }
        public DateTime DateStamp { get; set; }


        //Added For Database Upgrade
        public string UserId { get; set;}
        public bool FitbitData { get; set; }
        public bool DiaryData { get; set; }

        // ******* Sleep Structure = 8 attributes ****************
        public string MinutesAsleep { get; set; }
        public string MinutesAwake { get; set; }
        public string AwakeningsCount { get; set; }
        public string TimeInBed { get; set; }
        public string MinutesToFallAsleep { get; set; }
        public string MinutesAfterWakeup { get; set; }
        public string SleepEfficiency { get; set; }
        public string WakeUpFreshness { get; set; }

        // ******** Potential Affecting Factors = 32 attributes *****************
        // -- Food = 5 attributes --
        public string CaloriesIn { get; set; }
        public string Water { get; set; }
        public string Coffee { get; set; }
        public string CoffeeTime { get; set; }
        public string Alcohol { get; set; }

        // -- Psychology = 4 attributes --
        public string Mood { get; set; }
        public string Stress { get; set; }
        public string Tiredness { get; set; }
        public string Dream { get; set; }

        // -- Sleep hygiene = 7 attributes --
        public string TimeEnteredBed { get; set; }
        public string DigitalDev { get; set; }
        public string Light { get; set; }
        public string NapDuration { get; set; }
        public string NapTime { get; set; }
        public string SocialActivity { get; set; }
        public string DinnerTime { get; set; }

        // -- Environment = 2 attributes --
        public string AmbientTemp { get; set; }
        public string AmbientHumd { get; set; }

        // -- Activity = 9 attributes --
        public string CaloriesOut { get; set; }
        public string Steps { get; set; }
        public string Distance { get; set; } // no use cause it's based on steps
        public string MinutesSedentary { get; set; }
        public string MinutesLightlyActive { get; set; }
        public string MinutesFairlyActive { get; set; }
        public string MinutesVeryActive { get; set; }
        public string ActivityCalories { get; set; } // weired
        public string ExerciseTime { get; set; }

        // -- Body = 5 attribute --
        public string Weight { get; set; }
        public string BMI { get; set; } //weired
        public string Fat { get; set; }
        public string BodyTemp { get; set; }
        public string Hormone { get; set; }

    }
}