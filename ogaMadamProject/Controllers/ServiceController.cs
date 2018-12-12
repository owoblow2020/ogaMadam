using Newtonsoft.Json;
using ogaMadamProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ogaMadamProject.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {
        ErorrMessage error;
        ServiceUtility util = new ServiceUtility();

        [HttpGet]
        public IHttpActionResult ListUsers()
        {
            return Ok();
        }

        public void log(string obj)
        {

            string sPathName = HttpContext.Current.Server.MapPath("/log.txt");

            using (StreamWriter w = new StreamWriter(sPathName, true))
            {
                w.WriteLine(Environment.NewLine + "New Log Entry: ");
                w.WriteLine(DateTime.Now.ToString());
                w.WriteLine(obj);
                w.WriteLine("__________________________");
                w.WriteLine(" ");
                w.Flush();
            }
        }
    }
}
