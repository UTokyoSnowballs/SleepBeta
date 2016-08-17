namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UpgradeInfo")]
    public partial class UpgradeInfo
    {
        [Key]
        [StringLength(260)]
        public string Item { get; set; }

        [StringLength(512)]
        public string Status { get; set; }
    }
}
