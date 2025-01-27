using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class CommonModel
    {
        public string Country { get; set; }
        public string CountryName { get; set; }
        public string ServiceProviderId { get; set; }
        public string ServiceProvider { get; set; }
        public string ServiceProviderName { get; set; }
        public string WeightRange { get; set; }
        public string LeadTimeFrom { get; set; }
        public string LeadTimeTo { get; set; }
        public int BusinessUnitId { get; set; }

        public string BusinessUnitName { get; set; }

        public int LocationId { get; set; }

        public string LocatioName { get; set; }

        public int ApproverId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }

        public string DeartmentName { get; set; }

        public string DepartmentName { get; set; }
        public int SampleTypeId { get; set; }

        public string SampleTypeName { get; set; }
        public int SeasonId { get; set; }

        public string SeasonName { get; set; }
        public int WashTypeId { get; set; }

        public string WashTypeName { get; set; }
        public int SampleStageId { get; set; }

        public string SampleStageName { get; set; }
        public int GaugId { get; set; }

        public string GaugName { get; set; }
    }
}