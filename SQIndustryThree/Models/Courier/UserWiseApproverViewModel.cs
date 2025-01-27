using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.Courier
{
    public class UserWiseApproverViewModel
    {
        public int RequestorApproverId { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public string ApproverSequence { get; set; }
    }
}