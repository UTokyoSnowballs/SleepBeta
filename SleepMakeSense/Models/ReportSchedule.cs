namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportSchedule")]
    public partial class ReportSchedule
    {
        [Key]
        [Column(Order = 0)]
        public Guid ScheduleID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ReportID { get; set; }

        public Guid? SubscriptionID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReportAction { get; set; }
    }
}
