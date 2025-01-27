namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventTable")]
    public partial class EventTable
    {
        [Key]
        public int EventID { get; set; }

        [StringLength(200)]
        public string EventName { get; set; }

        public string Rules { get; set; }

        public byte? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
