namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionRequestHRDeatilsExtend")]
    public partial class ExceptionRequestHRDeatilsExtend
    {
        [Key]
        public int ExpReqDtlsExtId { get; set; }

        public int? ExpReqMastertId { get; set; }

        public int? ExceptionRequestDetailstId { get; set; }

        public string PositionCode { get; set; }

        public int? UnitId { get; set; }

        public int? SectionId { get; set; }

        public int? SubSectionId { get; set; }

        public int? DesignationId { get; set; }

        public int? CategoryId { get; set; }

        public int? AdditionalManpower { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
