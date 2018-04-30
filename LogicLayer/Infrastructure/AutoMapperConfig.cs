﻿using AutoMapper;
using Data.Entities;
using LogicLayer.DTO;

namespace LogicLayer.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Career, CareerDTO>();
                cfg.CreateMap<Offer, OfferDTO>();
                cfg.CreateMap<Resume, ResumeDTO>();
                cfg.CreateMap<ResumesExperience, ResumesExperienceDTO>();
                cfg.CreateMap<Rubric, RubricDTO>();
                cfg.CreateMap<User, UserDTO>();
            });
        }
    }
}
