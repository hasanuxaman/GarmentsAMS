using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.BillApproval
{
    public class AllocationPODetails
    {
        public int SupplierId { get; set; }
        public int InvoiceKey { get; set; }
        public string InvoiceNo { get; set; }
        public int PONo { get; set; }
        public decimal POQty { get; set; }
        public decimal POValue { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal PaymentValue { get; set; }
        public int CreatedBy { get; set; }
    }
}