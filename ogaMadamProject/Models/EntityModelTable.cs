using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        [ForeignKey("AspNetUser")]
        public string EmployeeId { get; set; }
        public string BVN { get; set; }
        public string NIMC { get; set; }
        public string ImageId { get; set; }
        public DateTime? CreatedAt { get; set; }

        
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Employer Employer { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<Training> Training { get; set; }
        public ICollection<Report> Report { get; set; }
    }

    public class Employer
    {
        [Key]
        [ForeignKey("AspNetUser")]
        public string EmployerId { get; set; }
        public string ImageId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }

    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentCategory { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentChannelType PaymentChannel { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employer Employer { get; set; }
    }

    public class Review
    {
        [Key]
        public string ReviewId { get; set; }
        public string Details { get; set; }
        public int? Star { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee Employee { get; set; }
    }

    public class Training
    {
        [Key]
        public string TrainingId { get; set; }
        public string TrainingType { get; set; }
        public DateTime? TrainingDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee Employee { get; set; }
    }

    public class Report
    {
        [Key]
        public string ReportId { get; set; }
        public string ReportType { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee Employee { get; set; }
    }
}