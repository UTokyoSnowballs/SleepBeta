namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [Key]
        [Column(Order = 0)]
        public Guid NotificationID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SubscriptionID { get; set; }

        public Guid? ActivationID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid ReportID { get; set; }

        public DateTime? SnapShotDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "ntext")]
        public string ExtensionSettings { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Locale { get; set; }

        [Column(TypeName = "ntext")]
        public string Parameters { get; set; }

        public DateTime? ProcessStart { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime NotificationEntered { get; set; }

        public DateTime? ProcessAfter { get; set; }

        public int? Attempt { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime SubscriptionLastRunTime { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(260)]
        public string DeliveryExtension { get; set; }

        [Key]
        [Column(Order = 8)]
        public Guid SubscriptionOwnerID { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsDataDriven { get; set; }

        public Guid? BatchID { get; set; }

        public DateTime? ProcessHeartbeat { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReportZone { get; set; }
    }
}
