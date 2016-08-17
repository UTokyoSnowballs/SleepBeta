namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServerParametersInstance")]
    public partial class ServerParametersInstance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(32)]
        public string ServerParametersID { get; set; }

        [StringLength(32)]
        public string ParentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(425)]
        public string Path { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ModifiedDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Timeout { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime Expiration { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "image")]
        public byte[] ParametersValues { get; set; }
    }
}
