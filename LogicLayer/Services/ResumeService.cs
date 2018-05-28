using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer.Services
{
    public class ResumeService : IResumeService
    {
        IUnitOfWork Database { get; set; }

        public ResumeService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            Database = unitOfWork;
        }

        public void CreateResume(ResumeDTO resumeDTO)
        {
            if (resumeDTO == null)
                throw new ArgumentNullException(nameof(resumeDTO));

            if (resumeDTO.Id != 0 && Database.Resumes.Get(resumeDTO.Id) != null)
                throw new ArgumentOutOfRangeException("Found duplicate id resume");

            Database.Resumes.Create(Mapper.Map<ResumeDTO, Resume>(resumeDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditResume(ResumeDTO resumeDTO)
        {
            if (resumeDTO == null)
                throw new ArgumentNullException(nameof(resumeDTO));


            Resume resume = Database.Resumes.Get(resumeDTO.Id);

            if (resume == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            try
            {
                Database.Rubrics.Get(resumeDTO.RubricId);
            }
            catch (NullReferenceException)
            {
                throw new ArgumentOutOfRangeException("Invalid argument rubricId");
            }

            resume.Title = resumeDTO.Title;
            resume.Surname = resumeDTO.Surname;
            resume.Name = resumeDTO.Name;
            resume.MiddleName = resumeDTO.MiddleName;
            resume.Birthday = resumeDTO.Birthday;
            resume.Gender = resumeDTO.Gender;
            resume.City = resumeDTO.City;
            resume.Phone = resumeDTO.Phone;
            resume.Email = resumeDTO.Email;
            resume.Skype = resumeDTO.Skype;
            resume.RubricId = resumeDTO.RubricId;
            resume.Portfolio = resumeDTO.Portfolio;
            resume.DesiredPosition = resumeDTO.DesiredPosition;
            resume.Payment = resumeDTO.Payment;
            resume.Skills = resumeDTO.Skills;
            //resume.UserId = resumeDTO.UserId;

            Database.Resumes.Update(resume);
            Database.Save();
        }

        public void RemoveResume(ResumeDTO resumeDTO)
        {
            if (resumeDTO == null)
                throw new ArgumentNullException(nameof(resumeDTO));

            if (Database.Resumes.Get(resumeDTO.Id) == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            Database.Resumes.Delete(resumeDTO.Id);
            Database.Save();
        }

        public ResumeDTO GetResumeById(int id)
        {
            return Mapper.Map<Resume, ResumeDTO>(Database.Resumes.Get(id));
        }

        public IEnumerable<ResumeDTO> GetAllResumes()
        {
            return Mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.GetAll());
        }

        public void RemoveResume(int id)
        {
            if (Database.Resumes.Get(id) == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            Database.Resumes.Delete(id);
            Database.Save();
        }

        public void AddExperience(ResumesExperienceDTO experienceDTO)
        {
            if (experienceDTO == null)
                throw new ArgumentNullException(nameof(experienceDTO));

            Resume resume = Database.Resumes.Get(experienceDTO.ResumeId);

            if (resume == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            resume.ResumesExperiences.Add(Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO));
            Database.Resumes.Update(resume);
            Database.Save();
        }

        public void RemoveExperience(int resumeId, int experienceId)
        {
            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            ResumesExperience experience = resume.ResumesExperiences.Where(x => x.Id == experienceId).First();

            if (experience == null)
                throw new ArgumentOutOfRangeException("Not found experience");

            resume.ResumesExperiences.Remove(experience);
            Database.Resumes.Update(resume);
            Database.Save();
        }

        public IEnumerable<ResumesExperienceDTO> GetExperiences(int resumeId)
        {
            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            return Mapper.Map<IEnumerable<ResumesExperience>, List<ResumesExperienceDTO>>(Database.Resumes.Get(resumeId).ResumesExperiences);
        }

        public IEnumerable<OfferDTO> GetOffers(int resumeId)
        {
            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            return Mapper.Map<IEnumerable<Offer>, List<OfferDTO>>(Database.Resumes.Get(resumeId).Offers);
        }
    }
}
