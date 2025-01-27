namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CapexFileUploadDetail
    {
        [Key]
        [Column(Order = 0)]
        public int CapexFileUploadId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CapexFileName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CapexFilePath { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexInfoId { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime UpdateDate { get; set; }

        public int? userId { get; set; }
    }
}
