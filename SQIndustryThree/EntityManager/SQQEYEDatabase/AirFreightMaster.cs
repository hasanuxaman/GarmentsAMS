namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AirFreightMaster")]
    public partial class AirFreightMaster
    {
        public int AirFreightMasterId { get; set; }

        public int? ExceptionMasterId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? BuyersNameId { get; set; }

        public int? ForwarderId { get; set; }

        public int? FrieghtCostOnACOf { get; set; }

        public decimal? USDToBDTRate { get; set; }

        public bool? IsFinal { get; set; }

        public int? CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }
    }
}
