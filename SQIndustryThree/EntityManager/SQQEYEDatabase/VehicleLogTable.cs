namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleLogTable")]
    public partial class VehicleLogTable
    {
        [Key]
        public int VehicleLogId { get; set; }

        public int? VehicleRequestID { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string LogName { get; set; }

        [StringLength(500)]
        public string LogDescrition { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
