using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data.Model;
using AutoMapper;

namespace AcademicMarketplace.App_Start
{
    public class AutoMapperConfig
    {
        public void InitializeMappings()
        {
            Mapper.Initialize(x => x.CreateMap<AspNetUser, UserModel>());
            Mapper.Initialize(x => x.CreateMap<UserModel, AspNetUser>());
        }
    }
}