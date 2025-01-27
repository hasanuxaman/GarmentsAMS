namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionDetailsTable")]
    public partial class ExceptionDetailsTable
    {
        [Key]
        public int ExceptionDetailsId { get; set; }

        public int? ExceptionMasterId { get; set; }

        public int? Recoverable { get; set; }

        public double? GrossWeight { get; set; }

        public double? VolumetricWeight { get; set; }

        public double? AirFreightRate { get; set; }

        public double? AirFreightCost { get; set; }

        public string RecoverableFrom { get; set; }

        public double? RecoverableAmmount { get; set; }

        public string PoInvoiceNo { get; set; }

        public double? ClaimedAmmount { get; set; }

        public double? AmmountCancelation { get; set; }

        public string ExceptionDetails { get; set; }

        public decimal? LossOrLiabilityCompany { get; set; }

        public string ValueOfLoss { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public double? DiscountAmount { get; set; }

        public double? GarmentsLiability { get; set; }
    }
}
