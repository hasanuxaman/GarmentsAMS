namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionRequestHRMaster")]
    public partial class ExceptionRequestHRMaster
    {
        [Key]
        public int ExpReqMastertId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfRequest { get; set; }

        public int? RequestorId { get; set; }

        public int? ExpTypeId { get; set; }

        public int? ExpReasonId { get; set; }

        public int? LocationId { get; set; }

        public int? BusinessUnitId { get; set; }

        public string Month { get; set; }

        public string Comment { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }

        public int? ApproverStatus { get; set; }
    }
}
