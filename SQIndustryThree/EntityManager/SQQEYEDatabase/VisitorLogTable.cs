namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorLogTable")]
    public partial class VisitorLogTable
    {
        [Key]
        public int VisitorLogId { get; set; }

        public int? VisitorRequestID { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string LogName { get; set; }

        [StringLength(500)]
        public string LogDescrition { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
