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
            Database.Resumes.Create(Mapper.Map<ResumeDTO, Resume>(resumeDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditResume(ResumeDTO resumeDTO)
        {
            Resume resume = Database.Resumes.Get(resumeDTO.Id);
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
            resume.UserId = resumeDTO.UserId;

            Database.Resumes.Update(resume);
            Database.Save();
        }

        public void RemoveResume(ResumeDTO resumeDTO)
        {
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
            Database.Resumes.Delete(id);
            Database.Save();
        }

        public void AddExperience(ResumesExperienceDTO experienceDTO)
        {
            if (experienceDTO == null)
                throw new ArgumentNullException(nameof(experienceDTO));

            Resume resume = Database.Resumes.Get(experienceDTO.ResumeId);

            if (resume == null)
                throw new Exception("Not find resume");

            experienceDTO.Resume = null;

            resume.ResumesExperiences.Add(Mapper.Map<ResumesExperienceDTO, ResumesExperience>(experienceDTO));
            Database.Save();
        }

        public void RemoveExperience(int resumeId, int experienceId)
        {
            if(resumeId == 0)
                throw new ArgumentNullException(nameof(resumeId));

            if (experienceId == 0)
                throw new ArgumentNullException(nameof(experienceId));

            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new Exception("Not find resume");

            ResumesExperience experience = resume.ResumesExperiences.Where(x => x.Id == experienceId).First();

            if (experience == null)
                throw new Exception("Not find experience");

            resume.ResumesExperiences.Remove(experience);
            Database.Save();
        }

        public IEnumerable<ResumesExperienceDTO> GetExperiences(int resumeId)
        {
            if (resumeId == 0)
                throw new ArgumentNullException(nameof(resumeId));

            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new Exception("Not find resume");

            return Mapper.Map<IEnumerable<ResumesExperience>, List<ResumesExperienceDTO>>(Database.Resumes.Get(resumeId).ResumesExperiences);
        }

        public IEnumerable<OfferDTO> GetOffers(int resumeId)
        {
            if (resumeId == 0)
                throw new ArgumentNullException(nameof(resumeId));

            Resume resume = Database.Resumes.Get(resumeId);

            if (resume == null)
                throw new Exception("Not find resume");

            return Mapper.Map<IEnumerable<Offer>, List<OfferDTO>>(Database.Resumes.Get(resumeId).Offers);
        }
    }
}
