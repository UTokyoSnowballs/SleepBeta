namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        [Key]
        [Column(Order = 0)]
        public Guid RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(260)]
        public string RoleName { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string TaskMask { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte RoleFlags { get; set; }
    }
}
