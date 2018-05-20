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

        public enum IncludeOptions : byte
        {
            Rubric = 1,
            User,
            Offers,
            Experiences
        };

        public ResumeService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
            Database.Resumes.Update(Mapper.Map<ResumeDTO, Resume>(resumeDTO));
            Database.Save();
        }

        public void RemoveResume(ResumeDTO resumeDTO)
        {
            Resume resume = Mapper.Map<ResumeDTO, Resume>(resumeDTO);
            Database.Resumes.Delete(resume.Id);
            Database.Save();
        }

        public ResumeDTO GetResumeById(int id)
        {
            return Mapper.Map<Resume, ResumeDTO>(Database.Resumes.Get(id));
        }

        public IEnumerable<ResumeDTO> GetAllResumes(int options)
        {
            IEnumerable<ResumeDTO> resumes = Database.Resumes.GetAll().Select(resume => new ResumeDTO()
            {
                Id = resume.Id,
                Title = resume.Title,
                Surname = resume.Surname,
                Name = resume.Name,
                MiddleName = resume.MiddleName,
                Birthday = resume.Birthday,
                Gender = resume.Gender,
                City = resume.City,
                Phone = resume.Phone,
                Email = resume.Email,
                Skype = resume.Skype,
                RubricId = resume.RubricId.Value,
                Portfolio = resume.Portfolio,
                DesiredPosition = resume.DesiredPosition,
                Payment = resume.Payment,
                Skills = resume.Skills,
                UserId = resume.UserId,

                Rubric = ((options & (int) IncludeOptions.Rubric) != 0) ? new RubricDTO()
                {
                    Id = resume.Rubric.Id,
                    Name = resume.Rubric.Name,
                } : null,

                User = ((options & (int)IncludeOptions.Rubric) != 0) ? new UserDTO()
                {
                    Id = resume.User.Id,
                    Surname = resume.User.Surname,
                    Name = resume.User.Name
                } : null,

                Offers = ((options & (int)IncludeOptions.Rubric) != 0) ? resume.Offers.Select(offer => new OfferDTO()
                {
                    Id = offer.Id,
                    CareerId = offer.CareerId,
                    ResumeId = offer.ResumeId,
                    DateSend = offer.DateSend,
                    Viewed = offer.Viewed
                }).ToArray() : null,

                ResumesExperiences = ((options & (int)IncludeOptions.Rubric) != 0) ? resume.ResumesExperiences.Select(experience => new ResumesExperienceDTO()
                {
                    Id = experience.Id,
                    ResumeId = experience.ResumeId,
                    Company = experience.Company,
                    Position = experience.Position,
                    StartDate = experience.StartDate,
                    FinishDate = experience.FinishDate,
                }).ToArray() : null
            });

            return resumes;
        }
    }
}
