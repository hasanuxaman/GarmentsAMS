namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionRequestMaster")]
    public partial class ExceptionRequestMaster
    {
        [Key]
        public int ExceptionMasterId { get; set; }

        public int? ExceptionTypeId { get; set; }

        public string ExceptionTypeName { get; set; }

        public int? BusinessUnitId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? IsApproved { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? RivisionNo { get; set; }

        public int? NoApprover { get; set; }

        public string Reasons { get; set; }

        public int? BuyerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Odd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Rdd { get; set; }

        public string ResponsiblePerson { get; set; }

        public int? UserID { get; set; }

        public string NecessaryAction { get; set; }

        public int? IsHrInteraction { get; set; }

        public string HrActionRemarks { get; set; }

        public int? LastApproverId { get; set; }

        public int? ExceptionReasonID { get; set; }
    }
}
