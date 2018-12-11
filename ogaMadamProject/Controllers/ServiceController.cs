using Newtonsoft.Json;
using ogaMadamProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ogaMadamProject.Controllers
{
    public class ServiceController : ApiController
    {
        ErorrMessage error;

        public IHttpActionResult UserLogin(UserDTO UserRequest)
        {
            try
            {
                var json = JsonConvert.SerializeObject(UserRequest);
                log(json);
            }
            catch (Exception ex)
            {

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

                ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden,error));
            }

            UserDTO UserResponse = utility.GetPosUser(UserRequest);

            if (UserResponse == null)
            {
                return GetErrorMsg(2, "User Not Found");
            }

            if (UserResponse.MDAStation_ID == null)
            {
                return GetErrorMsg(2, "User Not Assigned to Station");
            }

            return Ok(UserResponse);
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
