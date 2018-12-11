using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Models
{
    public class ResponseModel
    {
        public int ResponseCode { get; set; }
        public bool ResponseStatus { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ErorrMessage
    {
        public int ResponseCode { get; set; }
        public bool ResponseStatus { get; set; }
        public string Message { get; set; }
    }

    public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool StatusCode { get; set; }
        public string MessageCode { get; set; }
    }
}