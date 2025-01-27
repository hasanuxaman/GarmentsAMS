using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.BillApproval
{
    public class ChequeInfoDetails
    {
        public long TransactionNo { get; set; }
        public string PaymentType { get; set; }
        public decimal PaidAmount { get; set; }
        public string ChequeOrTTNo { get; set; }
        public decimal ChequeOrTTAmount { get; set; }
        public decimal TdsAmount { get; set; }
        public DateTime ChequeOrTTDate { get; set; }
        public string InvoiceNo { get; set; }
        public int InvoiceKey { get; set; }
        public int Status { get; set; }
        public string CheckStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
    }
}