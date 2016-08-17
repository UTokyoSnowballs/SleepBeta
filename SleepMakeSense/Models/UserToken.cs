namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserToken
    {
        public string Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [StringLength(50)]
        public string TokenType { get; set; }

        public DateTime RequestTime { get; set; }

        public int ExpiresIn { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
    }
}
