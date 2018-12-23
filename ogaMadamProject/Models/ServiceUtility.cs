using AutoMapper;
using Microsoft.AspNet.Identity;
using ogaMadamProject.Controllers;
using ogaMadamProject.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace ogaMadamProject.Models
{
    public class ServiceUtility : IDisposable
    {
        bool disposed;
        private ApplicationDbContext _db;
        private OgaMadamAdo _db2;


        public ServiceUtility()
        {
            _db = new ApplicationDbContext();
            _db2 = new OgaMadamAdo();
        }

        public Task<IEnumerable<AspNetUserDto>> ListUsers()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                return _db2.AspNetUsers.ToList().Select(Mapper.Map<AspNetUser, AspNetUserDto>);
            });
        }

        public Task<IEnumerable<CategoryDto>> ListCategory()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                return _db2.Categories.ToList().Select(Mapper.Map<Category, CategoryDto>);
            });
        }

        public bool VerifyBVN(string bvn)
        {
            return false;
        }

        public Task<bool> RegisterEmployee(RegisterModel model, string id)
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                var employeeDetails = new Employee()
                {
                    EmployeeId = id,
                    BVN = model.ExtraData.BVN,
                    NIMC = model.ExtraData.NIMC,
                    CreatedAt = DateTime.Now
                    
                };

                switch (model.ExtraData.QualificationType)
                {
                    case "Bsc":
                        employeeDetails.QualificationType = QualificationType.Bsc;
                        break;
                    case "Hnd":
                        employeeDetails.QualificationType = QualificationType.Hnd;
                        break;
                    case "Msc":
                        employeeDetails.QualificationType = QualificationType.Msc;
                        break;
                    case "Ond":
                        employeeDetails.QualificationType = QualificationType.Ond;
                        break;
                    default:
                        employeeDetails.QualificationType = QualificationType.Ssce;
                        break;
                }

                _db2.Employees.Add(employeeDetails);
                if (_db2.SaveChanges() == 1)
                {
                    var content = new EmailSmsRequest()
                    {
                        From = "Oga Madam",
                        Message = "Email confirmation",
                        RecieptEmail = model.Email,
                        SenderEmail = model.Email,
                        Subject = "Email confirmation"
                    };

                    SendEmailSms(content);

                    //send phone verification

                    return true;
                }
                return false;
            });
        }

        public Task<string> SendEmailSms(EmailSmsRequest dataRequest)
        {
            try
            {
                if (! string.IsNullOrEmpty(dataRequest.RecieptEmail))
                {
                    //send email
                }

                if (!string.IsNullOrEmpty(dataRequest.Phone))
                {
                    //send sms

                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public string RandomNumber()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            string rNum = DateTime.Now.Millisecond + rnd.Next(0, 900000000).ToString();

            return rNum;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _db.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}