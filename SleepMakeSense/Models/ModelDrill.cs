namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelDrill")]
    public partial class ModelDrill
    {
        [Key]
        [Column(Order = 0)]
        public Guid ModelDrillID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ModelID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid ReportID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(425)]
        public string ModelItemID { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte Type { get; set; }
    }
}
