namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExtendedDataSet
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        public Guid? LinkID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(260)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid ItemID { get; set; }
    }
}
