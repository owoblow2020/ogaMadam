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
        ServiceUtility util = new ServiceUtility();

        [HttpGet]
        public async Task<IHttpActionResult> ListUsers()
        {
            try
            {
                var userList = await util.ListUsers();
                if (userList == null)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, ErrorResponse(404, "No user found")));
                }

                return Ok(SuccessResponse(200, "successful", userList));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorResponse(500, ex.Message.ToString())));
            }
        }

        private ErorrMessage ErrorResponse(int num, string msg)
        {
            var error = new ErorrMessage()
            {
                ResponseCode = num,
                ResponseStatus = false,
                Message = msg
            };

            return error;
        }

        private ResponseModel SuccessResponse(int num, string msg, object obj)
        {
            var response = new ResponseModel()
            {
                ResponseCode = num,
                ResponseStatus = true,
                Message = msg,
                Data = obj
            };

            return response;
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
