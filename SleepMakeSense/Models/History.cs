namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        [Key]
        [Column(Order = 0)]
        public Guid HistoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ReportID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid SnapshotDataID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime SnapshotDate { get; set; }
    }
}
