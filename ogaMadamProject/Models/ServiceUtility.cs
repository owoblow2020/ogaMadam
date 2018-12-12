using AutoMapper;
using Microsoft.AspNet.Identity;
using ogaMadamProject.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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

        public IEnumerable<AspNetUserDto> ListUsers()
        {

            return _db2.AspNetUsers.ToList().Select(Mapper.Map<AspNetUser, AspNetUserDto>);
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