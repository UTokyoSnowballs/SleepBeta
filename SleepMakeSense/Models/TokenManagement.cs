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
        public string ExpiresIn { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
