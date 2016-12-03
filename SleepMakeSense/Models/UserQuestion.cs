namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public bool WakeUpFreshness { get; set; }

        public bool Mood { get; set; }

        public bool Stress { get; set; }

        public bool Tiredness { get; set; }
         
        public bool Dream { get; set; }

        public bool SchoolQuestions { get; set; }

        public bool CoffeeQuestions { get; set; }

        public bool AlcoholQuestions { get; set; }

        public bool NapQuestions { get; set; }

        public bool DigDeviceDurationQuestion { get; set; }

        public bool GameDurationQuestion { get; set; }

        public bool SocialMediaDurationQuestion { get; set; }

        public bool SocialActivityDurationQuestion { get; set; }

        public bool MusicDurationQuestion { get; set; }

        public bool TVDurationQuestion { get; set; }

        public bool WorkQuestions { get; set; }

        public bool ExersiseQuestions { get; set; }

        public bool FoodQuestions { get; set; }

        public bool GenderHormoneQuestion { get; set; }

    }
}
