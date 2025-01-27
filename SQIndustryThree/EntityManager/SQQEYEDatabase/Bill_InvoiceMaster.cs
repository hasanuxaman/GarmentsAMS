namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_InvoiceMaster
    {
        [Key]
        public int InvoiceKey { get; set; }

        [StringLength(200)]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? InvoiceTypeID { get; set; }

        public int? SubCategoryId { get; set; }

        public int? SupplierId { get; set; }

        public int? CurrencyId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsFinalInvoice { get; set; }

        public string Remarks { get; set; }

        public string Notes { get; set; }

        public long? POKey { get; set; }

        public decimal? Total_InvoiceQty { get; set; }

        public decimal? Total_InvoiceValue { get; set; }

        public decimal? Total_Discount { get; set; }

        public decimal? Total_Paid { get; set; }

        public int? IsApproved { get; set; }

        public double? Discount_Percent { get; set; }

        public decimal? Total_DiscountAmt { get; set; }

        public decimal? Total_Amount { get; set; }

        public double? Adv_Adjustment_Percent { get; set; }

        public decimal? Adv_Adjustment_Amt { get; set; }

        public double? Retaintion_Percent { get; set; }

        public decimal? Retaintion_Amt { get; set; }

        public decimal? Total_Adjustment_Amt { get; set; }

        public double? VAT_Percent { get; set; }

        public decimal? VAT_Amt { get; set; }

        public double? TAX_Percent { get; set; }

        public decimal? TAX_Amt { get; set; }

        public decimal? Net_Value { get; set; }

        public int? CapexInfoId { get; set; }

        public int? CostCenterId { get; set; }

        public int? GLID { get; set; }
    }
}
