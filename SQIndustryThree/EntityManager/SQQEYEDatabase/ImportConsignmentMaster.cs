namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportConsignmentMaster")]
    public partial class ImportConsignmentMaster
    {
        public int ImportConsignmentMasterId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? BuyerId { get; set; }

        public int? ShipperId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public bool? IsFinal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
