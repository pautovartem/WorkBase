using DAL.Interfaces;
using Data.Entities;
using System;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Career> Careers { get; }
        IRepository<Offer> Offers { get; }
        IRepository<Resume> Resumes { get; }
        IRepository<ResumesExperience> ResumesExperiences { get; }
        IRepository<Rubric> Rubrics { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
