namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionRequestHRLogTable")]
    public partial class ExceptionRequestHRLogTable
    {
        [Key]
        public int ExceptionRequestHRLogId { get; set; }

        public int? ExpReqMasterId { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string LogName { get; set; }

        [StringLength(500)]
        public string LogDescrition { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
