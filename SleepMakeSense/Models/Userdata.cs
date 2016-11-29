namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Userdata
    {

        //User Details
        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        public DateTime DateStamp { get; set; }

        public FitbitData FitbitData { get; set; }

        public DiaryData DiaryData { get; set; } 

    }
}
