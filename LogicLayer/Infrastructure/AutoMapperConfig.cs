using AutoMapper;
using Data.Entities;
using Data.Identity.Entities;
using LogicLayer.DTO;

namespace LogicLayer.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Career, CareerDTO>();
            cfg.CreateMap<Offer, OfferDTO>();
            cfg.CreateMap<Resume, ResumeDTO>();
            cfg.CreateMap<ResumesExperience, ResumesExperienceDTO>();
            cfg.CreateMap<Rubric, RubricDTO>();
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<ApplicationUser, UserDTO>();
        }
    }
}
