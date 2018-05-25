using AutoMapper;
using LogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkBase.Models;

namespace WorkBase.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<RubricViewModel, RubricDTO>()
                .ForMember(x => x.Careers, opt => opt.Ignore())
                .ForMember(x => x.Resumes, opt => opt.Ignore());
        }
    }
}