using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SQIndustryThree.BillFileUpload
{
    public class BasicUtilities
    {
        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
         lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        //public string GetLoggedUserID()
        //{
        //    string _Created_By = string.Empty;
        //    if (Session[POSxSession.LoggedUser] != null)
        //    {

        //        DataTable dt = (DataTable)Session[POSxSession.LoggedUser];
        //        _Created_By = dt.Rows[0]["emp_id"].ToString();
        //        _Device_ID = _Created_By;
        //    }


        //    return _Created_By;
        //}

        enum Ratio
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6
        }
    }
}