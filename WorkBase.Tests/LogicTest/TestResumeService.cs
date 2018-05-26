using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using LogicLayer.Infrastructure;
using LogicLayer.Services;
using Data.Entities;
using Data.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class TestResumeService
    {
        private IResumeService resumeService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Resume>> resumeRepository;
        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            resumeRepository = new Mock<IRepository<Resume>>();

            uow.Setup(x => x.Resumes).Returns(resumeRepository.Object);
            // uow.Setup(x => x.Categories.Get(It.IsAny<int>())).Returns(new Category { Name = It.IsAny<string>() });

            resumeService = new ResumeService(uow.Object);
        }

        [Test]
        public void CreateResume_TryToCreateResume_ShouldRepositoryCreateOnce()
        {
            var Resume = new ResumeDTO { Id = It.IsAny<int>() };

            // act
            resumeService.CreateResume(Resume);

            //assert
            resumeRepository.Verify(x => x.Create(It.IsAny<Resume>()));
        }
        [Test]
        public void GetResumeById_TryToGetValue_ShouldReturnSomeValue()
        {
            var Resume = new Resume { Id = It.IsAny<int>() };

            uow.Setup(x => x.Resumes.Get(It.IsAny<int>())).Returns(Resume);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(resumeService.GetResumeById(It.IsAny<int>()));
        }
        [Test]
        public void GetAllResumes_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            resumeRepository.Setup(x => x.GetAll()).Returns(new List<Resume>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(resumeService.GetAllResumes());
            resumeRepository.Verify(x => x.GetAll());
        }
        [Test]
        public void EditResume_EditResume_ShoudRepositoryEditOnce()
        {//
            var Resume = new ResumeDTO { Id = It.IsAny<int>(), Name = It.IsAny<string>()  };
            resumeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Resume { Id = It.IsAny<int>(),Name = It.IsAny<string>() });

            //act
            resumeService.EditResume(Resume);

            //assert
            resumeRepository.Verify(x => x.Update(It.IsAny<Resume>()), Times.Once);
        }

        [Test]
        public void DeleteResume_DeleteRepositoryShouldCallsOnce()
        {
            resumeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Resume { Id = It.IsAny<int>(), Name = It.IsAny<string>() });

            //act
            resumeService.RemoveResume(It.IsAny<int>());

            //assert
            resumeRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
    }
}



