namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IouAmmountTable")]
    public partial class IouAmmountTable
    {
        [Key]
        public int IouAmmountId { get; set; }

        public int? IouRequestId { get; set; }

        public int? Ammount { get; set; }

        public string Remarks { get; set; }

        public string ItemName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
