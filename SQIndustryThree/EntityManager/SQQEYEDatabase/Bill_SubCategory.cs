namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        public int? InvoiceType { get; set; }

        [StringLength(100)]
        public string SubCategoryName { get; set; }

        public bool? IsActive { get; set; }

        public int? DepartmentID { get; set; }
    }
}
