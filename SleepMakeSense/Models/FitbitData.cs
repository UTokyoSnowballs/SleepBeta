using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public class FitbitData
    {
        /// <summary>
        /// Class Model of the Data only from the Fitbit API
        /// </summary>
        public int Id { get; set; }
        //User Details
        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

        public DateTime DateStamp { get; set; }

        //Sleep Details
        public string SleepEfficiency { get; set; }

        public string TimeEnteredBed { get; set; }

        public string MinutesAsleep { get; set; }

        public string MinutesAwake { get; set; }

        public string TimeInBed { get; set; }

        public string AwakeningsCount { get; set; }

        public string MinutesToFallAsleep { get; set; }

        public string MinutesAfterWakeup { get; set; }


        //Exersise Details
        public string Steps { get; set; }

        public string Distance { get; set; }

        public string MinutesSedentary { get; set; }

        public string MinutesLightlyActive { get; set; }

        public string MinutesFairlyActive { get; set; }

        public string MinutesVeryActive { get; set; }

        //Diet Details
        public string Water { get; set; }

        public string CaloriesIn { get; set; }

        public string CaloriesOut { get; set; }

        public string ActivityCalories { get; set; }

        //Health Details
        public string Weight { get; set; }

        public string BMI { get; set; }

        public string Fat { get; set; }
    }
}