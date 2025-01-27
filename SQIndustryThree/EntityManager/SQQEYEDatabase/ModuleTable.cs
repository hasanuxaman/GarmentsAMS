namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModuleTable")]
    public partial class ModuleTable
    {
        [Key]
        [Column(Order = 0)]
        public int Modulekey { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ModuleName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ModuleCreate { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ModuleUpdate { get; set; }

        public string ModuleValue { get; set; }

        public string ModuleController { get; set; }

        public int? ProjectID { get; set; }
    }
}
