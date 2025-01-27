namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleTableApprover")]
    public partial class VehicleTableApprover
    {
        [Key]
        public int VehicleApproverId { get; set; }

        public int? VehiclerRequestorId { get; set; }

        public int? UserId { get; set; }

        public int? ApproverNo { get; set; }

        public int? IsApproved { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string ReviewComment { get; set; }

        public int? ApproverStatus { get; set; }

        public int? FrontDesk { get; set; }

        public int? FactoryGate { get; set; }
    }
}
