namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_BankDetails
    {
        [Key]
        public int BankDetailsId { get; set; }

        public string BankName { get; set; }

        public string IFSCorSWIFTCode { get; set; }

        public string AccountType { get; set; }

        public string AccountNumber { get; set; }

        public string Branch { get; set; }

        public string BeneficiaryName { get; set; }

        public int? SupplierId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedBy { get; set; }
    }
}
