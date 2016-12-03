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
        public int Id { get; set; }
        //User Details

        public DateTime DateStamp { get; set; }

        public FitbitData FitbitData { get; set; }

        public DiaryData DiaryData { get; set; } 

    }
}
