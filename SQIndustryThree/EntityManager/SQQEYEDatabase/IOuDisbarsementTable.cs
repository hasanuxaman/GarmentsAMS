namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IOuDisbarsementTable")]
    public partial class IOuDisbarsementTable
    {
        [Key]
        public int IouDisburseId { get; set; }

        public int? IouRequestId { get; set; }

        public int? Amount { get; set; }

        public string Remarks { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
