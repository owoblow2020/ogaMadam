using AutoMapper;
using ogaMadamProject.Dtos;
using ogaMadamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogaMadamProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<AspNetUser, AspNetUserDto>();
            Mapper.CreateMap<AspNetUserDto, AspNetUser>();

            Mapper.CreateMap<Category, CategoryDto>();
        }
    }
}