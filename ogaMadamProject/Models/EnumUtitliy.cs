using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogaMadamProject.Models
{
    public class EnumUtitliy
    {
    }

    public enum SexType
    {
        Male,
        Female
    }

    public enum StatusType
    {
        Pending,
        Active
    }

    public enum UserType
    {
        Employee,
        Employer,
        Admin
    }

    public enum PaymentStatus
    {
        Failed,
        Successful,
        pending
    }

    public enum PaymentChannelType
    {
        Web,
        Pos,
        Cash
    }

    public enum VerificationType
    {
        BVN,
        NIMC
    }

    public enum QualificationType
    {
        Ssce,
        Ond,
        Hnd,
        Bsc,
        Msc
    }

    public enum ReportType
    {
        Medical,
        Police
    }

    public enum TicketStatus
    {
        Open,
        Closed
    }

    public enum ApiMode
    {
        Test,
        Live
    }
}