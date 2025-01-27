namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierRequestDetailsTable")]
    public partial class CourierRequestDetailsTable
    {
        [Key]
        public int CourierRequestId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfRequest { get; set; }

        public int? RequesterId { get; set; }

        public int? LocationId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DepartmentID { get; set; }

        public string CourierType { get; set; }

        public string Customer { get; set; }

        public string Receiver { get; set; }

        public string Title { get; set; }

        public string ContactNo { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public DateTime? DispatchDate { get; set; }

        public DateTime? Deliverydate { get; set; }

        public string ProductDescription { get; set; }

        public string Weight { get; set; }

        public string Volume { get; set; }

        [StringLength(10)]
        public string AirwayBillno { get; set; }

        public string Courier { get; set; }

        public DateTime? ProposedDate { get; set; }

        public decimal? Cost { get; set; }

        public string GenerateCourier { get; set; }

        public DateTime? GenerateProposedDate { get; set; }

        public string GenerateCost { get; set; }

        public string Remarks { get; set; }

        public int? ReceptionistId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }

        public int? ApproverStatus { get; set; }
    }
}
