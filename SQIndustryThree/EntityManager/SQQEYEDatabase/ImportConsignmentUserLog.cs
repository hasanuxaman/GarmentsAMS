namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportConsignmentUserLog")]
    public partial class ImportConsignmentUserLog
    {
        [Key]
        public int ImportaConsignmentUserLogId { get; set; }

        public int? ImportConsignmentMasterId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedOn { get; set; }
    }
}
