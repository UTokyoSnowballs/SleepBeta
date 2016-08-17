namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CachePolicy")]
    public partial class CachePolicy
    {
        [Key]
        [Column(Order = 0)]
        public Guid CachePolicyID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ReportID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExpirationFlags { get; set; }

        public int? CacheExpiration { get; set; }
    }
}
