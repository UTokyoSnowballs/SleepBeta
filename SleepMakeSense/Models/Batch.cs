namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Batch")]
    public partial class Batch
    {
        [Key]
        [Column(Order = 0)]
        public Guid BatchID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime AddedOn { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string Action { get; set; }

        [StringLength(425)]
        public string Item { get; set; }

        [StringLength(425)]
        public string Parent { get; set; }

        [StringLength(425)]
        public string Param { get; set; }

        public bool? BoolParam { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        [Column(TypeName = "ntext")]
        public string Properties { get; set; }
    }
}
