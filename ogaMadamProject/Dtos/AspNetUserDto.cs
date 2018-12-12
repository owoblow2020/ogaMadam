using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Dtos
{
    public class AspNetUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string StateOfOrigin { get; set; }
        public string UserType { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsUserVerified { get; set; }
        public string CreatedAt { get; set; }
    }
}