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
            if (experienceDTO == null)
                throw new ArgumentNullException(nameof(experienceDTO));

            if (experienceDTO.Id != 0 && Database.ResumesExperiences.Get(experienceDTO.Id) != null)
                throw new ArgumentOutOfRangeException("Found duplicate id experience");

            Database.ResumesExperiences.Create(Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditExperience(ResumesExperienceDTO experienceDTO)
        {
            if (experienceDTO == null)
                throw new ArgumentNullException(nameof(experienceDTO));

            ResumesExperience experience = Database.ResumesExperiences.Get(experienceDTO.Id);

            if (experience == null)
                throw new ArgumentOutOfRangeException("Not found experience");

            Resume resume;
            try
            {
                resume = Database.Resumes.Get(experienceDTO.ResumeId);
            }
            catch (NullReferenceException)
            {
                throw new ArgumentOutOfRangeException("Invalid argument ResumeId");
            }

            experience.ResumeId = experienceDTO.ResumeId;
            experience.Company = experienceDTO.Company;
            experience.Position = experienceDTO.Position;
            experience.StartDate = experienceDTO.StartDate;
            experience.FinishDate = experienceDTO.FinishDate;
            experience.Resume = resume;

            Database.ResumesExperiences.Update(experience);
            Database.Save();
        }

        public void RemoveExperience(ResumesExperienceDTO experienceDTO)
        {
            if (experienceDTO == null)
                throw new ArgumentNullException(nameof(experienceDTO));

            if (Database.ResumesExperiences.Get(experienceDTO.Id) == null)
                throw new ArgumentOutOfRangeException("Not found experience");

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
            if (Database.ResumesExperiences.Get(id) == null)
                throw new ArgumentOutOfRangeException("Not found experience");

            Database.ResumesExperiences.Delete(id);
            Database.Save();
        }
    }
}
