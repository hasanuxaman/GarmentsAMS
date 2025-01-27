namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierBudgetEntry")]
    public partial class CourierBudgetEntry
    {
        public int CourierBudgetEntryId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DepartmentID { get; set; }

        public string BudgetYear { get; set; }

        public string MonthOfYear { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
