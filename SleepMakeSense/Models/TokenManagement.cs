namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TokenManagement
    {
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string TokenType { get; set; }

        [Required]
        public int ExpiresIn { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        [Required]
        public DateTime DateChanged { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
