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
        public void CreateResumesesExperience_TryToCreateResumesesExperience_ShouldRepositoryCreateOnce()
        {
            var ResumesExperience = new ResumesExperienceDTO { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() };

            // act
            expService.CreateExperience(ResumesExperience);

            //assert
            expRepository.Verify(x => x.Create(It.IsAny<ResumesExperience>()));
        }
        [Test]
        public void GetExperiencesExperienceById_TryToGetValue_ShouldReturnSomeValue()
        {
            var ResumesExperience = new ResumesExperience { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() };

            uow.Setup(x => x.ResumesExperiences.Get(It.IsAny<int>())).Returns(ResumesExperience);

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
        public void EditExperience_PutInEditNullElement_ShouldThrowException()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => expService.EditExperience(null));
        }
        [Test]
        public void EditExperience_NullElement_ShouldThrowException()
        {
            //arrange
            var experience = new ResumesExperienceDTO { Id = It.IsAny<int>() };

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => expService.EditExperience(experience));
        }


        [Test]
        public void DeleteExperience_DeleteNullValue()
        {
            //arrange
            expRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Resume>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => expService.RemoveExperience(It.IsAny<int>()));


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
        [Test]
        public void RemoveExperience_Delete()
        {
            var Experience = new ResumesExperienceDTO { Id = It.IsAny<int>(), Company = It.IsAny<string>() };
            expRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ResumesExperience { Id = It.IsAny<int>(), Company = It.IsAny<string>() });

            //act
            expService.RemoveExperience(Experience);

            //assert
            expRepository.Verify(x => x.Delete(It.IsAny<int>()));

        }
    }
}



       
       


