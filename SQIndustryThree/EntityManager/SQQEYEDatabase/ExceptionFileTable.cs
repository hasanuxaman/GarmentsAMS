namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionFileTable")]
    public partial class ExceptionFileTable
    {
        [Key]
        public int ExceptionFileId { get; set; }

        public string ExceptionFileName { get; set; }

        public int? ExceptionMasterId { get; set; }

        public string ExceptionFilePath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
