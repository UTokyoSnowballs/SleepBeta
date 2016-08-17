namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SecData")]
    public partial class SecData
    {
        [Key]
        [Column(Order = 0)]
        public Guid SecDataID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid PolicyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthType { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "ntext")]
        public string XmlDescription { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "image")]
        public byte[] NtSecDescPrimary { get; set; }

        [Column(TypeName = "ntext")]
        public string NtSecDescSecondary { get; set; }
    }
}
