using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class ResumeService : IResumeService
    {
        IUnitOfWork Database { get; set; }

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

        public IEnumerable<ResumeDTO> GetAllResumes()
        {
            return Mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.GetAll());
        }
    }
}
