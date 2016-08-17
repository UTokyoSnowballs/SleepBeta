namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SnapshotData")]
    public partial class SnapshotData
    {
        [Key]
        [Column(Order = 0)]
        public Guid SnapshotDataID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime CreatedDate { get; set; }

        public int? ParamsHash { get; set; }

        [Column(TypeName = "ntext")]
        public string QueryParams { get; set; }

        [Column(TypeName = "ntext")]
        public string EffectiveParams { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public bool? DependsOnUser { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PermanentRefcount { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransientRefcount { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime ExpirationDate { get; set; }

        public int? PageCount { get; set; }

        public bool? HasDocMap { get; set; }

        public short? PaginationMode { get; set; }

        public int? ProcessingFlags { get; set; }
    }
}
