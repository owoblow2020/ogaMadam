using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Dtos
{
    public class AspNetUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

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
    }

    public class EmployeeDto
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string MiddleName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string StateOfOrigin { get; set; }


    }

    public class CategoryDto
    {
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class EmployeeRegDto
    {
        public string EmployeeId { get; set; }
        public string EmployerId { get; set; }
        public string CategoryId { get; set; }
        public string BVN { get; set; }
        public string NIMC { get; set; }
        public bool IsAttachedApproved { get; set; }
        public DateTime? AttachedDate { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal SalaryAmount { get; set; }
        public bool IsUserVerified { get; set; }
        public bool IsTrained { get; set; }
        public bool IsInterviewed { get; set; }
        public string QualificationType { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class EmployeeLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Sex { get; set; }

        public string StateOfOrigin { get; set; }

        public string BVN { get; set; }

        public string NIMC { get; set; }

        public IList<UploadDto> Upload { get; set; }
    }

    public class UploadDto
    {
        public string UploadId { get; set; }
    }
}