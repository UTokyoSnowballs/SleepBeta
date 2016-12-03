using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public class DiaryData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public DateTime DateStamp { get; set; }

        public string WakeUpFreshness { get; set; }

        public string Mood { get; set; }

        public string Stress { get; set; }

        public string Tiredness { get; set; }

        public string Dream { get; set; }

        public string BodyTemp { get; set; }

        public string Hormone { get; set; }

        public string SchoolStress { get; set; }

        public string CoffeeAmt { get; set; }

        public string CoffeeTime { get; set; }

        public string AlcoholAmt { get; set; }

        public string AlcoholTime { get; set; }

        public string NapTime { get; set; }

        public string NapDuration { get; set; }

        public string DigDeviceDuration { get; set; }

        public string GamesDuration { get; set; }

        public string SocialActivites { get; set; }

        public string SocialActivity { get; set; }

        public string MusicDuration { get; set; }

        public string TVDuration { get; set; }

        public string WorkTime { get; set; }

        public string WorkDuration { get; set; }

        public string ExerciseDuration { get; set; }

        public string ExerciseIntensity { get; set; }

        public string DinnerTime { get; set; }

        public string SnackTime { get; set; }

        public string AmbientTemp { get; set; }

        public string AmbientHumd { get; set; }

        public string Light { get; set; }

        public string SunRiseTime { get; set; }

        public string SunSetTime { get; set; } 
    }
}
