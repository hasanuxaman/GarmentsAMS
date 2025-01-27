namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ImportConsignmentDetail
    {
        [Key]
        public int ImportConsignmentDetailsId { get; set; }

        public int? ImportConsginmentMasterId { get; set; }

        public int? AccountLeadId { get; set; }

        public string PortOfLoading { get; set; }

        public string GoodsDescription { get; set; }

        public int? ModeOfShipmentId { get; set; }

        public int? ForwarderOrCarrierId { get; set; }

        public string HBLorHAWBNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BLorAWABDt { get; set; }

        public string LCNo { get; set; }

        public string InvoiceNo { get; set; }

        public decimal? ValueInUSD { get; set; }

        public decimal? GrWeightInKg { get; set; }

        public decimal? Quantity { get; set; }

        public int? UnitId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ETD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ETA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BerthingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CBM { get; set; }

        public int? AssesmentStatusId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OTTDt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PCD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TentativeDeliveryDate { get; set; }

        public decimal? Balance { get; set; }

        public string Remarks { get; set; }

        public int? ContainerTypeId { get; set; }

        public int? ContainerSizeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
