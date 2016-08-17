namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PolicyUserRole")]
    public partial class PolicyUserRole
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid RoleID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid UserID { get; set; }

        [Key]
        [Column(Order = 3)]
        public Guid PolicyID { get; set; }
    }
}
