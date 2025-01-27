namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportConsignmentFile")]
    public partial class ImportConsignmentFile
    {
        public int ImportConsignmentFileId { get; set; }

        public int? ImportConsignmentDetailsId { get; set; }

        public string FileName { get; set; }

        public string ServerFileName { get; set; }

        public string FilePath { get; set; }

        public string ShortPath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
