using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Models
{
    public class EntityModelTable
    {
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string BVN { get; set; }
        public string NIMC { get; set; }
        public string ImageId { get; set; }
        public DateTime? CreatedAt { get; set; }

        
        public virtual AspNetUser AspNetUserID { get; set; }
    }
}