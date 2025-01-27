namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IouDepartmentHeadTable")]
    public partial class IouDepartmentHeadTable
    {
        [Key]
        public int IouHodId { get; set; }

        public int? DepartmentId { get; set; }

        public int? UserId { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? LocationId { get; set; }
    }
}
