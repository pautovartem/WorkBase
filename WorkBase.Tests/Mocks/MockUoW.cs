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
        public IRepository<ResumesExperience> RExper
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

        public IRepository<ResumesExperience> ResumesExperiences {
            get
            {
                if (_exp == null)
                {
                    var stub = new Mock<IRepository<ResumesExperience>>();
                   _exp = stub.Object;
                }
                return _exp;
            }
        }

        public MockUoW()
        {
            careers.Add(new Career() {Id=1, UserId="1111",RubricId=1111 });
            exp.Add(new ResumesExperience() {Id=0000,ResumeId=0000 });
            offer.Add(new Offer() {Id=2222,CareerId=2222,ResumeId=2222 });
            resume.Add(new Resume() {Id=3333,Name="Vasya" });
            rubric.Add(new Rubric() {Id=4444,Name="Work" });
            users.Add(new User() {Id="5555",Surname="Ooo" });
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
