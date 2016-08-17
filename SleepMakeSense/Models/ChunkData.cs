namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChunkData")]
    public partial class ChunkData
    {
        [Key]
        [Column(Order = 0)]
        public Guid ChunkID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SnapshotDataID { get; set; }

        public byte? ChunkFlags { get; set; }

        [StringLength(260)]
        public string ChunkName { get; set; }

        public int? ChunkType { get; set; }

        public short? Version { get; set; }

        [StringLength(260)]
        public string MimeType { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }
    }
}
