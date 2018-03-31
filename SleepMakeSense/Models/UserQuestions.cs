using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// 20171023 Pandita: reimplement using EF
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SleepMakeSense.Models
{

    public class UserQuestions
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to AspNetUser
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }

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
        public bool TempQuestion { get; set; }
        public bool LightQuestion { get; set; }
        public bool NoiseQuestion { get; set; }
        public bool CleanlinessQuestion { get; set; }
        public bool MedicationQuestion { get; set; }
        public bool PerFactor1Question { get; set; }
        public string PerFactor1Name { get; set; }
        public bool PerFactor2Question { get; set; }
        public string PerFactor2Name { get; set; }
        public bool PerFactor3Question { get; set; }
        public string PerFactor3Name { get; set; }

        public bool PerFactor4Question { get; set; }
        public string PerFactor4Name { get; set; }

        public bool PerFactor5Question { get; set; }
        public string PerFactor5Name { get; set; }

        public bool PerFactor6Question { get; set; }
        public string PerFactor6Name { get; set; }


    }
}