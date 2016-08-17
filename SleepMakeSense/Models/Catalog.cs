namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalog")]
    public partial class Catalog
    {
        [Key]
        [Column(Order = 0)]
        public Guid ItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(425)]
        public string Path { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(425)]
        public string Name { get; set; }

        public Guid? ParentID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        public Guid? Intermediate { get; set; }

        public Guid? SnapshotDataID { get; set; }

        public Guid? LinkSourceID { get; set; }

        [Column(TypeName = "ntext")]
        public string Property { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public bool? Hidden { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid CreatedByID { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 6)]
        public Guid ModifiedByID { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime ModifiedDate { get; set; }

        [StringLength(260)]
        public string MimeType { get; set; }

        public int? SnapshotLimit { get; set; }

        [Column(TypeName = "ntext")]
        public string Parameter { get; set; }

        [Key]
        [Column(Order = 8)]
        public Guid PolicyID { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool PolicyRoot { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExecutionFlag { get; set; }

        public DateTime? ExecutionTime { get; set; }

        [StringLength(128)]
        public string SubType { get; set; }

        public Guid? ComponentID { get; set; }
    }
}
