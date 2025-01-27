namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PositionCodeWiseManpower")]
    public partial class PositionCodeWiseManpower
    {
        [Key]
        public int PWManpowerId { get; set; }

        public int? BusinessUnitId { get; set; }

        public string PositionName { get; set; }

        public int? DepartmentId { get; set; }

        public int? StaffCategoryId { get; set; }

        public int? DesignationId { get; set; }

        public int? Month { get; set; }

        public int? BudgetedHead { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
