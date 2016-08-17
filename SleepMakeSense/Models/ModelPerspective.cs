namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelPerspective")]
    public partial class ModelPerspective
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ModelID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string PerspectiveID { get; set; }

        [Column(TypeName = "ntext")]
        public string PerspectiveName { get; set; }

        [Column(TypeName = "ntext")]
        public string PerspectiveDescription { get; set; }
    }
}
