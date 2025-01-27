using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.DataManager
{
    public class SqlUserAccess
    {
        //Dev Server
        //public static string DataSource = @"SQC-244\SQLEXPRESS";
        //public static string UserName = @"abdullah";
        //public static string PassWord = @"1234";

        //public static string DataSource = @"";
        //public static string UserName = @"sa";
        //public static string PassWord = @"sweater";

        //public static string DataSource = @"10.12.13.163";
        //public static string UserName = @"sa";
        //public static string PassWord = @"sql@sqc2";

        public static string DataSource = @"WIN-IIS";
        public static string UserName = @"sa";
        public static string PassWord = @"Sql123456_";

        //public static string DataSource = @"SQC-1015";
        //public static string UserName = @"sa";
        //public static string PassWord = @"Admin@1234";


        //public static string DataSource = @"10.12.8.152";
        //public static string UserName = @"sa";
        //public static string PassWord = @"capex@1234";

        //public static string DataSource = @"SQM-531";
        //public static string UserName = @"sa";
        //public static string PassWord = @"capex@1234";
    }
}