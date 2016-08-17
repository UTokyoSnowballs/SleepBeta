namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RunningJob
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(32)]
        public string JobID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string ComputerName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(425)]
        public string RequestName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(425)]
        public string RequestPath { get; set; }

        [Key]
        [Column(Order = 5)]
        public Guid UserId { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Timeout { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short JobAction { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short JobType { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short JobStatus { get; set; }
    }
}
