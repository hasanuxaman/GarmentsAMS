﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class BillApproverModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DesignationName { get; set; }
        public int ApproverNo { get; set; }
        public string ApproverStatusName { get; set; }
        public int ApproverStatus { get; set; }
        public int IsApprove { get; set; }
        public string UpdateDate { get; set; }
        public string Comments { get; set; }
        public int CertifyingCompleted { get; set; }
        public double CompletionPercent { get; set; }
        public string CompletionRemarks { get; set; }



    }
}