using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using Data.Entities;
using Data.Interfaces;
using Moq;

namespace WorkBase.Tests.Mocks
{
    public class MockUoW:IUnitOfWork
    {
        private IRepository<Career> _career;
        private IRepository<ResumesExperience> _exp;
        private IRepository<Offer> _offer;
        private IRepository<Resume> _resume;
        private IRepository<Rubric> _rubric;
        private IUserRepository userRepository;
        public List<Career> careers = new List<Career>();
        public List<ResumesExperience> exp = new List<ResumesExperience>();
        public List<Offer> offer = new List<Offer>();
        public List<Resume> resume = new List<Resume>();
        public List<Rubric> rubric = new List<Rubric>();
        public List<User> users = new List<User>();
        public IRepository<Career> Careers {
            get {
                if (_career == null) {
                    var stub = new Mock<IRepository<Career>>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(careers);
                    _career = stub.Object;
                   
                }
                return _career;
            }
        }
        public IRepository<ResumesExperience> ResumesExperiences
        {
            get
            {
                if (_exp == null)
                {
                    var stub = new Mock<IRepository<ResumesExperience>>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(exp);
                    _exp = stub.Object;

                }
                return _exp;
            }
        }


        public IRepository<Rubric> Rubrics
        {
            get
            {
                if (_rubric == null)
                {
                    var stub = new Mock<IRepository<Rubric>>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(rubric);
                    _rubric = stub.Object;
                }
                return _rubric;
            }
        }
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    var stub = new Mock<IUserRepository>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(users);
                    userRepository = stub.Object;
                }
                return userRepository;
            }
        }

        public IRepository<Offer> Offers {
            get
            {
                if (_offer == null)
                {
                    var stub = new Mock<IRepository<Offer>>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(offer);
                   _offer = stub.Object;
                }
                return _offer;
            }
        }

        public IRepository<Resume> Resumes {
            get
            {
                if (_resume == null)
                {
                    var stub = new Mock<IRepository<Resume>>();
                    stub.Setup(Ld => Ld.GetAll()).Returns(resume);
                    _resume = stub.Object;
                }
                return _resume;
            }
        }

      
        public MockUoW()
        {
            careers.Add(new Career() {Id=1, UserId="1111",RubricId=2 });
            careers.Add(new Career() { Id = 2, UserId = "2222", RubricId = 2 }); 

            exp.Add(new ResumesExperience() {Id=0,ResumeId=0 });
            exp.Add(new ResumesExperience() { Id = 3, ResumeId = 3});

            offer.Add(new Offer() {Id=4,CareerId=4,ResumeId=4 });
            offer.Add(new Offer() { Id = 5, CareerId = 5, ResumeId = 5 });

            resume.Add(new Resume() {Id=6,Name="Vas" });
            resume.Add(new Resume() { Id = 7, Name = "Vasya" });

            rubric.Add(new Rubric() {Id=8,Name="Work" });
            rubric.Add(new Rubric() { Id = 9, Name = "Wor" });

            users.Add(new User() {Id="10",Surname="Ooo" });
            users.Add(new User() { Id = "11", Surname = "Gi" });
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
