using AutoMapper;
using Data.Entities;
using Data.Identity.Entities;
using LogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBase.Tests.Mocks
{
    class MockAutoMapper
    {
        public static void MockInitialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Career, CareerDTO>();
                cfg.CreateMap<Offer, OfferDTO>();
                cfg.CreateMap<Resume, ResumeDTO>();
                cfg.CreateMap<ResumesExperience, ResumesExperienceDTO>();
                cfg.CreateMap<Rubric, RubricDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<ApplicationUser, UserDTO>();
            });
        }
    }
}
