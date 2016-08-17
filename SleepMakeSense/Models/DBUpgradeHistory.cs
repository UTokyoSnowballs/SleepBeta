namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBUpgradeHistory")]
    public partial class DBUpgradeHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UpgradeID { get; set; }

        [StringLength(25)]
        public string DbVersion { get; set; }

        [StringLength(128)]
        public string User { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
