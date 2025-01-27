namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AirFreightFile")]
    public partial class AirFreightFile
    {
        public int AirFreightFileId { get; set; }

        public int? AirFreightDetailsId { get; set; }

        public string FileName { get; set; }

        public string ServerFileName { get; set; }

        public string FilePath { get; set; }

        public string ShortPath { get; set; }
    }
}
