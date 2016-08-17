namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        [Key]
        [Column(Order = 0)]
        public Guid SubscriptionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid OwnerID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid Report_OID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Locale { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InactiveFlags { get; set; }

        [Column(TypeName = "ntext")]
        public string ExtensionSettings { get; set; }

        [Key]
        [Column(Order = 5)]
        public Guid ModifiedByID { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime ModifiedDate { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(260)]
        public string LastStatus { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(260)]
        public string EventType { get; set; }

        [Column(TypeName = "ntext")]
        public string MatchData { get; set; }

        public DateTime? LastRunTime { get; set; }

        [Column(TypeName = "ntext")]
        public string Parameters { get; set; }

        [Column(TypeName = "ntext")]
        public string DataSettings { get; set; }

        [StringLength(260)]
        public string DeliveryExtension { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReportZone { get; set; }
    }
}
