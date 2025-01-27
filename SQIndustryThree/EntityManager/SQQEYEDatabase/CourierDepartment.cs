namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierDepartment")]
    public partial class CourierDepartment
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        public int? Location { get; set; }
    }
}
