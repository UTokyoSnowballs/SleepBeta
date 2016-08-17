namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActiveSubscription
    {
        [Key]
        [Column(Order = 0)]
        public Guid ActiveID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SubscriptionID { get; set; }

        public int? TotalNotifications { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TotalSuccesses { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TotalFailures { get; set; }
    }
}
