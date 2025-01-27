using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.ImportConsignment
{
    public class ImportConsignmentMaster
    {
        public int ImportConsignmentMasterId { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public DateTime _Date { get; set; }
        public string Date { get; set; }
        public bool IsFinal { get; set; }
        public DateTime _CreateDate { get; set; }
        public string CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public List<ImportConsignmentDetails> ImportConsignmentDetails { get; set; }
    }
}