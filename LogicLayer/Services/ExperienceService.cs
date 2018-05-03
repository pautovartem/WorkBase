using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;

namespace LogicLayer.Services
{
    public class ExperienceService : IExperienceService
    {
        IUnitOfWork Database { get; set; }

        public ExperienceService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void CreateExperience(ResumesExperienceDTO experienceDTO)
        {
            Database.ResumesExperiences.Create(Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditExperience(ResumesExperienceDTO experienceDTO)
        {
            Database.ResumesExperiences.Update(Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO));
            Database.Save();
        }

        public void RemoveExperience(ResumesExperienceDTO experienceDTO)
        {
            ResumesExperience resumesExperience = Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO);
            Database.ResumesExperiences.Delete(resumesExperience.Id);
            Database.Save();
        }
    }
}
