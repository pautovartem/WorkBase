using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Career> Careers { get; }
        IRepository<Offer> Offers { get; }
        IRepository<Resume> Resumes { get; }
        IRepository<ResumesExperience> ResumesExperiences { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
