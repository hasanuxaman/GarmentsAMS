namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_QualityResult
    {
        [Key]
        public int QualityResultID { get; set; }

        [StringLength(100)]
        public string QualityResultName { get; set; }

        public bool? IsActive { get; set; }
    }
}
