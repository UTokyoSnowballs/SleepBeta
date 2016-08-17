namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        [Key]
        [Column(Order = 0)]
        public Guid ScheduleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(260)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Flags { get; set; }

        public DateTime? NextRunTime { get; set; }

        public DateTime? LastRunTime { get; set; }

        public DateTime? EndDate { get; set; }

        public int? RecurrenceType { get; set; }

        public int? MinutesInterval { get; set; }

        public int? DaysInterval { get; set; }

        public int? WeeksInterval { get; set; }

        public int? DaysOfWeek { get; set; }

        public int? DaysOfMonth { get; set; }

        public int? Month { get; set; }

        public int? MonthlyWeek { get; set; }

        public int? State { get; set; }

        [StringLength(260)]
        public string LastRunStatus { get; set; }

        public int? ScheduledRunTimeout { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid CreatedById { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(260)]
        public string EventType { get; set; }

        [StringLength(260)]
        public string EventData { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        public DateTime? ConsistancyCheck { get; set; }

        [StringLength(260)]
        public string Path { get; set; }
    }
}
