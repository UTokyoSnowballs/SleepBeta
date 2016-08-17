namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChunkSegmentMapping")]
    public partial class ChunkSegmentMapping
    {
        [Key]
        [Column(Order = 0)]
        public Guid ChunkId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SegmentId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StartByte { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogicalByteCount { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActualByteCount { get; set; }
    }
}
