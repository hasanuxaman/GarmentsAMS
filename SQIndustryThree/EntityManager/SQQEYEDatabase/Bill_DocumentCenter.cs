namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_DocumentCenter
    {
        [Key]
        public int DocumentCenterId { get; set; }

        [StringLength(100)]
        public string DocumentName { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
