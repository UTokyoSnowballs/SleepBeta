namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UniqueURL
    {
        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        public string URL { get; set; }

        public DateTime VaildTo { get; set; }

        public bool Valid { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntryId { get; set; }
    }
}
