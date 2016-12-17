namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Userdata
    {
        [Key]
        public Guid Id { get; set; }
        //User Details

        public DateTime DateStamp { get; set; }


        public double MinutesAsleep { get; set; }

        public double MinutesAwake { get; set; }

        public double AwakeningsCount { get; set; }

        public double TimeInBed { get; set; }

        public double MinutesToFallAsleep { get; set; }

        public double MinutesAfterWakeup { get; set; }

        public double SleepEfficiency { get; set; }

        public double CaloriesIn { get; set; }

        public double Water { get; set; }

        public double CaloriesOut { get; set; }

        public double Steps { get; set; }

        public double Distance { get; set; }

        public double MinutesSedentary { get; set; }

        public double MinutesLightlyActive { get; set; }

        public double MinutesFairlyActive { get; set; }

        public double MinutesVeryActive { get; set; }

        public double ActivityCalories { get; set; }

        public double TimeEnteredBed { get; set; }

        public double Weight { get; set; }

        public double BMI { get; set; }

        public double Fat { get; set; }

        //Diary Data
        public double WakeUpFreshness { get; set; }

        public double Mood { get; set; }

        public double Stress { get; set; }

        public double Tiredness { get; set; }

        public double Dream { get; set; }

        public double BodyTemp { get; set; }

        public double Hormone { get; set; }

        public double SchoolStress { get; set; }

        public double CoffeeAmt { get; set; }

        public DateTime CoffeeTime { get; set; }

        public double AlcoholAmt { get; set; }

        public DateTime AlcoholTime { get; set; }

        public DateTime NapTime { get; set; }

        public Double NapDuration { get; set; }

        public Double DigDeviceDuration { get; set; }

        public Double GamesDuration { get; set; }

        public Double SocialActivites { get; set; }

        public Double SocialActivity { get; set; }
string
        public  MusicDuration { get; set; }

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
