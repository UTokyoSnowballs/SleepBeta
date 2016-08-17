namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigurationInfo")]
    public partial class ConfigurationInfo
    {
        [Key]
        [Column(Order = 0)]
        public Guid ConfigInfoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(260)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string Value { get; set; }
    }
}
