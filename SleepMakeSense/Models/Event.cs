namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [Key]
        [Column(Order = 0)]
        public Guid EventID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(260)]
        public string EventType { get; set; }

        [StringLength(260)]
        public string EventData { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime TimeEntered { get; set; }

        public DateTime? ProcessStart { get; set; }

        public DateTime? ProcessHeartbeat { get; set; }

        public Guid? BatchID { get; set; }
    }
}
