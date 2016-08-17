namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubscriptionsBeingDeleted")]
    public partial class SubscriptionsBeingDeleted
    {
        [Key]
        [Column(Order = 0)]
        public Guid SubscriptionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime CreationDate { get; set; }
    }
}
