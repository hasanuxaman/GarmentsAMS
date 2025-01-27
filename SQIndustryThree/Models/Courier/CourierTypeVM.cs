using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.Courier
{
    public class CourierTypeVM
    {
        public int CourierTypeId { get; set; }

        public decimal? WeightRange { get; set; }

        public string Country { get; set; }

        public string CountryShortName { get; set; }

        public string PostCode { get; set; }

        public string ServiceProvider { get; set; }

        public string Currency { get; set; }

        public decimal? Rate { get; set; }

        public int? LeadTimeFrom { get; set; }

        public int? LeadTimeTo { get; set; }

        public string Type { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}