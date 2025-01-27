namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_ProcurementTable
    {
        [Key]
        public int ProcurementID { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        public byte? IsActive { get; set; }
    }
}
