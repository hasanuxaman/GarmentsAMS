using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class ExceptionRequestHRDetailsExtend
    {
        public int ExpReqDtlsExtId { get; set; }
        public int ExpReqMastertId { get; set; }
        public string PositionCode { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int SubSectionId { get; set; }
        public string SubSectionName { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int AdditionalManpower { get; set; }
    }
}