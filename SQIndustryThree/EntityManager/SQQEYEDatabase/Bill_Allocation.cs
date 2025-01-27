namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Allocation
    {
        [Key]
        public int AllocationID { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [StringLength(50)]
        public string PONo { get; set; }

        public decimal? AllocatedValue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
    }
}
