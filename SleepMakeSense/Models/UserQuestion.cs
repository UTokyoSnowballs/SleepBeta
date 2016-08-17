namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserQuestion
    {
        public bool PresentInStudy { get; set; }

        public bool? Question1 { get; set; }

        public bool? Question2 { get; set; }

        public bool? Question3 { get; set; }

        public bool? Question4 { get; set; }

        public bool? Question5 { get; set; }

        public bool? Question6 { get; set; }

        public bool? Question7 { get; set; }

        public bool? Question8 { get; set; }

        public bool? Question9 { get; set; }

        public bool? Question10 { get; set; }

        public bool? Question11 { get; set; }

        public bool? Question12 { get; set; }

        public bool? Question13 { get; set; }

        public bool? Question14 { get; set; }

        public bool? Question15 { get; set; }

        public bool? Question16 { get; set; }

        public bool? Question17 { get; set; }

        public bool? Question18 { get; set; }

        public bool? Question19 { get; set; }

        public bool? Question20 { get; set; }

        public int Id { get; set; }
    }
}
