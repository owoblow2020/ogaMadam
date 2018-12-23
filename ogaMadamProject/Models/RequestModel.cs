using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Models
{
    public class RequestModel
    {
    }

    public class UserRegister
    {
        public string FirstName { get; set; }
    }

    public class EmailSmsRequest
    {
       
        public string From { get; set; }
        
        public string RecieptEmail { get; set; }

        public string SenderEmail { get; set; }

        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

        public string Phone { get; set; }
    }
}