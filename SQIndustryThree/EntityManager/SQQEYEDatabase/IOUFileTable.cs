namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IOUFileTable")]
    public partial class IOUFileTable
    {
        [Key]
        public int IOUFileId { get; set; }

        public string IOUFileName { get; set; }

        public int? IOURequestId { get; set; }

        public string IOUFilePath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? Settlement { get; set; }
    }
}
