namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_GlInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GLID { get; set; }

        [StringLength(200)]
        public string LedgerName { get; set; }

        [StringLength(200)]
        public string ShortName { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string AccountType { get; set; }

        [StringLength(200)]
        public string MappedWithAccountGroup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
