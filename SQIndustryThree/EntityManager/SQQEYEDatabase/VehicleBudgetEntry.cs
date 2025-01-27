namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleBudgetEntry")]
    public partial class VehicleBudgetEntry
    {
        public int VehicleBudgetEntryId { get; set; }

        public int? BudgetHeadrId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DepartmentID { get; set; }

        public string BudgetYear { get; set; }

        public string MonthOfYear { get; set; }

        public decimal? InialAmount { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
