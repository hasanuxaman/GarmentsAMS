namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestorMasterTable")]
    public partial class RequestorMasterTable
    {
        [Key]
        public int RequestorId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? VisitMode { get; set; }

        public int? LocationId { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int? DepartmentHeadId { get; set; }

        public string RequestorName { get; set; }

        public string RequestorEmail { get; set; }

        public string RequerstorMobile { get; set; }

        public string RequestorDesignation { get; set; }

        public string RequestorDepartment { get; set; }

        [StringLength(20)]
        public string NIDorPassport { get; set; }

        public int? ModeOfVisit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VisitDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public string Image { get; set; }

        public string ImagePath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? IsApproved { get; set; }

        public int? RevisionNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? Created_By { get; set; }
    }
}
