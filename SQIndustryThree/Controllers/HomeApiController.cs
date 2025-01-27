using SQIndustryThree.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SQIndustryThree.Controllers
{
    public class HomeApiController : ApiController
    {
        AMSDAL aMSDal = new AMSDAL();

        [HttpGet]
        [Route("api/VisitorReportFactory")]
        public IHttpActionResult VisitorReportFactory()
        {
            return base.Json<DataTable>(this.aMSDal.VisitorReportFactory());
        }
        [HttpGet]
        [Route("api/IOUReportInformation")]
        public IHttpActionResult IOUReportInformation()
        {
            return base.Json<DataTable>(this.aMSDal.IOUReportInformation());
        }
        [HttpGet]
        [Route("api/VisitorReportForCentral")]
        public IHttpActionResult VisitorReportForCentral()
        {
            return base.Json<DataTable>(this.aMSDal.VisitorReportForCentral());
        }


        [Route("api/FileAPI/UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            //Create the Directory.
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Fetch the File Name.
            string fileName = HttpContext.Current.Request.Form["fileName"] + Path.GetExtension(postedFile.FileName);

            //Save the File.
            postedFile.SaveAs(path + fileName);

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }


        [Route("api/GetData")]
        [HttpGet]
        public async Task<IEnumerable<dynamic>> GetData(string query)
        {
            var data = await aMSDal.RetriveDate(query);

            return data;
        }

        [Route("api/GetInsertQuery")]
        [HttpGet]
        public async Task<IEnumerable<dynamic>> GetInsertQuery(string query)
        {
            var data = await aMSDal.RetriveDate(query);

            return data;
        }

        [Route("api/PostInsertQuery")]
        [HttpPost]
        public async Task<IEnumerable<dynamic>> PostInsertQuery([FromBody] string query)
        {
            var data = await aMSDal.RetriveDate(query);

            return data;
        }
    }
}
