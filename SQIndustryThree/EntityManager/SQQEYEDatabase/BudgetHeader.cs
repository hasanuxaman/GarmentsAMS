namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BudgetHeader")]
    public partial class BudgetHeader
    {
        [Key]
        [Column(Order = 0)]
        public int BudgetHeaderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string BudgetHeaderName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
