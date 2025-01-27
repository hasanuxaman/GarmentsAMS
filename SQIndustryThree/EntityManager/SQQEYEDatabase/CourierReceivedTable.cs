namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierReceivedTable")]
    public partial class CourierReceivedTable
    {
        [Key]
        public int CourierReceivedId { get; set; }

        public int? CourierRequestId { get; set; }

        public string CourierNumber { get; set; }

        public string AirwayBillno { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public decimal? ReceivedWeight { get; set; }

        public string HandOverTo { get; set; }

        public string ReferenceNo { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
