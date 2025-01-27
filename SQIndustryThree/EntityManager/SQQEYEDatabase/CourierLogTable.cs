namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierLogTable")]
    public partial class CourierLogTable
    {
        [Key]
        public int CourierLogId { get; set; }

        public int? CourierRequestID { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string LogName { get; set; }

        [StringLength(500)]
        public string LogDescrition { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
