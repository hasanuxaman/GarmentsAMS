namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionRequestHRReason")]
    public partial class ExceptionRequestHRReason
    {
        [Key]
        public int ExceptioReasonsId { get; set; }

        [Required]
        public string ExceptionReasonName { get; set; }

        public int? CreateDate { get; set; }

        public int? UpdateDate { get; set; }
    }
}
