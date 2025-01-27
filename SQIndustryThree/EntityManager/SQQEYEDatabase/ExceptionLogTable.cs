namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionLogTable")]
    public partial class ExceptionLogTable
    {
        public int ExceptionLogTableId { get; set; }

        public int? ExceptionMasterID { get; set; }

        public string ExceptionUpdate { get; set; }

        public int? ExceptionUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ExceptionRemarks { get; set; }
    }
}
