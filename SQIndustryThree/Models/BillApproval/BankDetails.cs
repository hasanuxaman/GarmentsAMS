using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.BillApproval
{
    public class BankDetails
    {
        public int BankDetailsId { get; set; }
        public string BankName { get; set; }
        public string IFSCorSWIFTCode { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string BeneficiaryName { get; set; }
        public int SupplierId { get; set; }
    }
}