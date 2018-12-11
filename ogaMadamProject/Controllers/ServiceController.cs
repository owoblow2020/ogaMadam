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
    public class ServiceController : ApiController
    {
        ErorrMessage error;
        ServiceUtility util = new ServiceUtility();

        public async Task< IHttpActionResult> UserRegister(UserRegister UserRequest)
        {
            try
            {
                var json = JsonConvert.SerializeObject(UserRequest);
                log(json);
            }
            catch (Exception ex)
            {
                error = new ErorrMessage()
                {
                    ResponseCode = 500,
                    ResponseStatus = false,
                    Message = ex.Message.ToString()
                };
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, error));
            }

            

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));

                error = new ErorrMessage()
                {
                    ResponseCode = 403,
                    ResponseStatus = false,
                    Message = message
                };                

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden, error));
            }

            var response = util.UserRegister(UserRequest);

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
