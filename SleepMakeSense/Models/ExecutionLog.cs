namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExecutionLog")]
    public partial class ExecutionLog
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(38)]
        public string InstanceName { get; set; }

        public Guid? ReportID { get; set; }

        [StringLength(260)]
        public string UserName { get; set; }

        public bool? RequestType { get; set; }

        [StringLength(26)]
        public string Format { get; set; }

        [Column(TypeName = "ntext")]
        public string Parameters { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TimeStart { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime TimeEnd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeDataRetrieval { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeProcessing { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeRendering { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Source { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(40)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ByteCount { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RowCount { get; set; }
    }
}
