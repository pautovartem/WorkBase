﻿using Data.Interfaces;
using System;
using Data.Entities;
using Data.EF;
using DAL.Repositories;
using DAL.Interfaces;

namespace Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WorkBaseContext database;
        private IRepository<Career> careerRepository;
        private IRepository<Offer> offerRepository;
        private IRepository<Resume> resumeRepository;
        private IRepository<ResumesExperience> resumesExperienceRepository;
        private IRepository<Rubric> rubricsRepository;
        private IUserRepository userRepository;

        public EFUnitOfWork(string connectionString)
        {
            database = new WorkBaseContext(connectionString);
        }

        public EFUnitOfWork(WorkBaseContext context)
        {
            database = context;
        }

        public IRepository<Career> Careers
        {
            get
            {
                if (careerRepository == null)
                    careerRepository = new GenericRepository<Career>(database);
                return careerRepository;
            }
        }

        public IRepository<Offer> Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new GenericRepository<Offer>(database);
                return offerRepository;
            }
        }

        public IRepository<Resume> Resumes
        {
            get
            {
                if (resumeRepository == null)
                    resumeRepository = new GenericRepository<Resume>(database);
                return resumeRepository;
            }
        }

        public IRepository<ResumesExperience> ResumesExperiences
        {
            get
            {
                if (resumesExperienceRepository == null)
                    resumesExperienceRepository = new GenericRepository<ResumesExperience>(database);
                return resumesExperienceRepository;
            }
        }

        public IRepository<Rubric> Rubrics
        {
            get
            {
                if (rubricsRepository == null)
                    rubricsRepository = new GenericRepository<Rubric>(database);
                return rubricsRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(database);
                return userRepository;
            }
        }

        public void Save()
        {
            database.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
