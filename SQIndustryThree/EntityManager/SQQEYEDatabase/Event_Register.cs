namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event_Register
    {
        [Key]
        public int RegisterID { get; set; }

        [StringLength(50)]
        public string GeneratedID { get; set; }

        public int? EventID { get; set; }

        public int? LocationID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EmployeeID { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public string Designation { get; set; }

        [StringLength(200)]
        public string Department { get; set; }

        public int? BusinessUnitID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UserID { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
