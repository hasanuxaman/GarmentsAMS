namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AirFreightUserLog")]
    public partial class AirFreightUserLog
    {
        public int AirFreightUserLogId { get; set; }

        public int? AirFreightMasterId { get; set; }

        public int? UserId { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
