namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierDispatchMaster")]
    public partial class CourierDispatchMaster
    {
        public int CourierDispatchMasterId { get; set; }

        public int? CourierDispatchNo { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string Courier { get; set; }

        public string CourierNumber { get; set; }

        public DateTime? DispatchDate { get; set; }

        public decimal? ConsolidateCost { get; set; }

        public string ConsolidateWeight { get; set; }

        public string AirwayBillno { get; set; }

        public string ReferenceNo { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
