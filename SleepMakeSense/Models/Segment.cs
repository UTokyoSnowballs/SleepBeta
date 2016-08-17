namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Segment")]
    public partial class Segment
    {
        public Guid SegmentId { get; set; }

        public byte[] Content { get; set; }
    }
}
