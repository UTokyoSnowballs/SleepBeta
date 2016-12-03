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
        //0
        public string SleepEfficiency { get; set; }
        //1
        public string TimeEnteredBed { get; set; }
        //2
        public string MinutesAsleep { get; set; }
        //3
        public string MinutesAwake { get; set; }
        //4
        public string TimeInBed { get; set; }
        //5
        public string AwakeningsCount { get; set; }
        //6
        public string MinutesToFallAsleep { get; set; }
        //7
        public string MinutesAfterWakeup { get; set; }


        //Exersise Details
        //8
        public string Steps { get; set; }
        //9
        public string Distance { get; set; }
        //10
        public string MinutesSedentary { get; set; }
        //11
        public string MinutesLightlyActive { get; set; }
        //12
        public string MinutesFairlyActive { get; set; }
        //13
        public string MinutesVeryActive { get; set; }

        //Diet Details
        //14
        public string Water { get; set; }
        //15
        public string CaloriesIn { get; set; }
        //16
        public string CaloriesOut { get; set; }
        //17
        public string ActivityCalories { get; set; }

        //Health Details
        //18
        public string Weight { get; set; }
        //19
        public string BMI { get; set; }
        //20
        public string Fat { get; set; }

    }
}