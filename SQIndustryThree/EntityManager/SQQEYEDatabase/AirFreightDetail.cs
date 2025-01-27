namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AirFreightDetail
    {
        [Key]
        public int AirFreightDetailsId { get; set; }

        public int? AirFreightMasterId { get; set; }

        public int? ExceptionGenralId { get; set; }

        public string PO { get; set; }

        public int? ParentPO { get; set; }

        public int? ModeOfShipmentId { get; set; }

        public string PortOfDestination { get; set; }

        public int? CountryOfDestinationId { get; set; }

        public int? IncotermId { get; set; }

        public string InvoiceNo { get; set; }

        public decimal? InvoiceValueInUSD { get; set; }

        public int? QTYInPack { get; set; }

        public int? QTYInPcERApproved { get; set; }

        public int? QtyInPc { get; set; }

        public int? QtyInCtn { get; set; }

        public decimal? GrossWeightInKg { get; set; }

        public string HAWBLNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HAWBLDate { get; set; }

        public decimal? ChargeableWeightInKgERApproved { get; set; }

        public decimal? FreightAmountInUSDErApproved { get; set; }

        public decimal? ChargeableWeightInKg { get; set; }

        public decimal? FreightAmountInUSD { get; set; }

        public decimal? FrieghtRatePerKgERApproved { get; set; }

        public decimal? FreightRatePerKg { get; set; }

        public decimal? FreightAmountInBDT { get; set; }

        public string FreightInvoiceNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExFactoryDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FreightInvoiceReceivedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BillSubDateForPayment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CHQPOSubmitDateToForwarder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AWABReleaseDate { get; set; }

        public string Remarks { get; set; }
    }
}
