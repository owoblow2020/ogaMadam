using AutoMapper;
using Newtonsoft.Json;
using ogaMadamProject.Dtos;
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
    [Authorize]
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
                if (userList.Count() == 0)
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

        [HttpGet]
        public async Task<IHttpActionResult> ListCategory()
        {
            try
            {
                var CategoryList = await util.ListCategory();
                if (CategoryList.Count() == 0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, ErrorResponse(404, "No Category found")));
                }

                return Ok(SuccessResponse(200, "successful", CategoryList));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorResponse(500, ex.Message.ToString())));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SendEmailSms(EmailSmsRequest dataRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));

                    var error = new ErorrMessage()
                    {
                        ResponseCode = 403,
                        ResponseStatus = false,
                        Message = message
                    };

                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden, error));
                }

                var SmsResponse = await util.SendEmailSms(dataRequest);
                if (SmsResponse == null)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, ErrorResponse(404, "Unable to send")));
                }

                return Ok(SuccessResponse(200, "successful", SmsResponse));
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

        public static void log(string obj)
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
