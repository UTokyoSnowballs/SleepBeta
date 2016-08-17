namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentedChunk")]
    public partial class SegmentedChunk
    {
        [Key]
        [Column(Order = 0)]
        public Guid ChunkId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SnapshotDataId { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte ChunkFlags { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(260)]
        public string ChunkName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChunkType { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Version { get; set; }

        [StringLength(260)]
        public string MimeType { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SegmentedChunkId { get; set; }
    }
}
