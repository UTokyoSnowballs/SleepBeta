namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Key
    {
        [StringLength(256)]
        public string MachineName { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid InstallationID { get; set; }

        [StringLength(32)]
        public string InstanceName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client { get; set; }

        [Column(TypeName = "image")]
        public byte[] PublicKey { get; set; }

        [Column(TypeName = "image")]
        public byte[] SymmetricKey { get; set; }
    }
}
