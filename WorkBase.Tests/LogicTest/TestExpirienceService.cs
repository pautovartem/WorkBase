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
    public class TestExpirienceService
    {
        private IExperienceService expService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<ResumesExperience>> expRepository;
        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            expRepository = new Mock<IRepository<ResumesExperience>>();

            uow.Setup(x => x.ResumesExperiences).Returns(expRepository.Object);

            expService = new ExperienceService(uow.Object);
        }
        [Test]
        public void CreateResumesExperience_TryToCreateResumesExperience_ShouldRepositoryCreateOnce()
        {
            var resumesExperience = new ResumesExperienceDTO { Id = It.IsAny<int>(), ResumeId= It.IsAny<int>() };

            // act
            expService.CreateExperience(resumesExperience);

            //assert
            expRepository.Verify(x => x.Create(It.IsAny<ResumesExperience>()));
        }
        [Test]
        public void GetResumesExperienceById_TryToGetValue_ShouldReturnSomeValue()
        {
            var resumesExperience = new ResumesExperience { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() };

            uow.Setup(x => x.ResumesExperiences.Get(It.IsAny<int>())).Returns(resumesExperience);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(expService.GetExperienceById(It.IsAny<int>()));
        }
        [Test]
        public void GetAllExperiences_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            expRepository.Setup(x => x.GetAll()).Returns(new List<ResumesExperience>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(expService.GetAllExperiences());
            expRepository.Verify(x => x.GetAll());
        }
        [Test]
        public void GetExpirienceById_GetNullValue_ShouldThrowException()
        {
            //arrange
            expRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Resume>(null);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(expService.GetExperienceById(It.IsAny<int>()));
        }


        [Test]
        public void EditResume_PutInEditNullElement_ShouldThrowException()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => expService.EditExperience(null));
        }
        [Test]
        public void EditResume_NullElement_ShouldThrowException()
        {
            //arrange
            var experience = new ResumesExperienceDTO { Id = It.IsAny<int>() };

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => expService.EditExperience(experience));
        }


        [Test]
        public void DeleteResume_DeleteNullValue()
        {
            //arrange
            expRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Resume>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => expService.RemoveExperience(It.IsAny<int>()));


        }

        [Test]
        public void DeleteExperience_DeleteRepositoryShouldCallsOnce()
        {
            expRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ResumesExperience { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() });

            //act
            expService.RemoveExperience(It.IsAny<int>());

            //assert
            expRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }

    }
}



       
       


