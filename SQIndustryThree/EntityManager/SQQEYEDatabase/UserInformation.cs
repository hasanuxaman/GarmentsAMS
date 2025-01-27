namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInformation")]
    public partial class UserInformation
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        [Key]
        [Column(Order = 3)]
        public string UserPassword { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserTypeId { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime UpdateDate { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreateBy { get; set; }

        public string SqIDNumber { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DesignationID { get; set; }

        public bool? IsSupplier { get; set; }
    }
}
