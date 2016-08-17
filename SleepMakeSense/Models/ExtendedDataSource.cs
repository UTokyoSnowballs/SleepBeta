namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExtendedDataSource
    {
        [Key]
        [Column(Order = 0)]
        public Guid DSID { get; set; }

        public Guid? ItemID { get; set; }

        public Guid? SubscriptionID { get; set; }

        [StringLength(260)]
        public string Name { get; set; }

        [StringLength(260)]
        public string Extension { get; set; }

        public Guid? Link { get; set; }

        public int? CredentialRetrieval { get; set; }

        [Column(TypeName = "ntext")]
        public string Prompt { get; set; }

        [Column(TypeName = "image")]
        public byte[] ConnectionString { get; set; }

        [Column(TypeName = "image")]
        public byte[] OriginalConnectionString { get; set; }

        public bool? OriginalConnectStringExpressionBased { get; set; }

        [Column(TypeName = "image")]
        public byte[] UserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] Password { get; set; }

        public int? Flags { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }
    }
}
