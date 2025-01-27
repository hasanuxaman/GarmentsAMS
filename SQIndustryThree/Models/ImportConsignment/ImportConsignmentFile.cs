using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.ImportConsignment
{
    public class ImportConsignmentFile
    {
        public int ImportConsignmentFileId { get; set; }
        public int ImportConsignmentDetailsId { get; set; }
        public string FileName { get; set; }
        public string ServerFileName { get; set; }
        public string FilePath { get; set; }
        public string ShortPath { get; set; }
        public DateTime _CreateDate { get; set; }
        public string CreateDate { get; set; }
        public int CreatedBy { get; set; }
    }
}