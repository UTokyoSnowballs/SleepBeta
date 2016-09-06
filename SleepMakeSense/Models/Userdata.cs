namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Userdata
    {
        public int Id { get; set; }

        public string Steps { get; set; }

        public string MinutesAsleep { get; set; }

        public DateTime DateStamp { get; set; }

        public string Water { get; set; }

        public string Distance { get; set; }

        public string MinutesSedentary { get; set; }

        public string MinutesVeryActive { get; set; }

        public string AwakeningsCount { get; set; }

        public string TimeEnteredBed { get; set; }

        public string Weight { get; set; }

        public string MinutesAwake { get; set; }

        public string TimeInBed { get; set; }

        public string MinutesToFallAsleep { get; set; }

        public string MinutesAfterWakeup { get; set; }

        public string CaloriesIn { get; set; }

        public string CaloriesOut { get; set; }

        public string MinutesLightlyActive { get; set; }

        public string MinutesFairlyActive { get; set; }

        public string ActivityCalories { get; set; }

        public string BMI { get; set; }

        public string Fat { get; set; }

        public string SleepEfficiency { get; set; }

        public string WakeUpFreshness { get; set; }

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

        public string AmbientTemp { get; set; }

        public string AmbientHumd { get; set; }

        public string ExerciseTime { get; set; }

        public string BodyTemp { get; set; }

        public string Hormone { get; set; }

        public bool FitbitData { get; set; }

        public bool DiaryDataNight { get; set; }

        public int WatchTV { get; set; }

        public int ExerciseDuration { get; set; }

        public int ExerciseIntensity { get; set; }

        public int ExerciseType { get; set; }

        public int Snack { get; set; }

        public bool Snack2 { get; set; }

        public int Job { get; set; }

        public int Job2 { get; set; }

        public int Phone { get; set; }

        public bool SleepDiary { get; set; }

        public bool Music { get; set; }

        public int MusicDuration { get; set; }

        public int MusicType { get; set; }

        public int SocialMedia { get; set; }

        public int Games { get; set; }

        public bool Assessment { get; set; }

        public bool DiaryDataMorning { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
