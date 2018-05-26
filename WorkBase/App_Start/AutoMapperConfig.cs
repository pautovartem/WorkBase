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

            cfg.CreateMap<ResumeViewModel, ResumeDTO>()
                .ForMember(x => x.Offers, opt => opt.Ignore())
                .ForMember(x => x.ResumesExperiences, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Rubric, opt => opt.Ignore());

            cfg.CreateMap<ExperienceViewModel, ResumesExperienceDTO>()
                .ForMember(x => x.Resume, opt => opt.Ignore());
        }
    }
}