using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class ExperienceService : IExperienceService
    {
        IUnitOfWork Database { get; set; }

        public ExperienceService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            Database = unitOfWork;
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
            ResumesExperience experience = Database.ResumesExperiences.Get(experienceDTO.Id);
            experience.ResumeId = experienceDTO.ResumeId;
            experience.Company = experienceDTO.Company;
            experience.Position = experienceDTO.Position;
            experience.StartDate = experienceDTO.StartDate;
            experience.FinishDate = experienceDTO.FinishDate;
            experience.Resume = Database.Resumes.Get(experience.ResumeId);

            Database.ResumesExperiences.Update(experience);
            Database.Save();
        }

        public void RemoveExperience(ResumesExperienceDTO experienceDTO)
        {
            Database.ResumesExperiences.Delete(experienceDTO.Id);
            Database.Save();
        }

        public ResumesExperienceDTO GetExperienceById(int id)
        {
            return Mapper.Map<ResumesExperience, ResumesExperienceDTO>(Database.ResumesExperiences.Get(id));
        }

        public IEnumerable<ResumesExperienceDTO> GetAllExperiences()
        {
            return Mapper.Map<IEnumerable<ResumesExperience>, List<ResumesExperienceDTO>>(Database.ResumesExperiences.GetAll());
        }

        public void RemoveExperience(int id)
        {
            Database.ResumesExperiences.Delete(id);
            Database.Save();
        }
    }
}
