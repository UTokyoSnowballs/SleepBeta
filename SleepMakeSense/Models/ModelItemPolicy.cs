namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelItemPolicy")]
    public partial class ModelItemPolicy
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CatalogItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(425)]
        public string ModelItemID { get; set; }

        [Key]
        [Column(Order = 3)]
        public Guid PolicyID { get; set; }
    }
}
