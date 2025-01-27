namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapexApproverTable")]
    public partial class CapexApproverTable
    {
        [Key]
        [Column(Order = 0)]
        public int CapApproverId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexInfoId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsApproved { get; set; }

        public string ReviewComment { get; set; }

        public string ReplyMessComment { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? DesignationID { get; set; }
    }
}
