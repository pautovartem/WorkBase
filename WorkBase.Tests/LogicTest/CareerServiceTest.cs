using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using System.Configuration;
using Data.Repositories;
using LogicLayer.DTO;
using Data.Entities;
using LogicLayer.Services;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System.Data.Entity;
using LogicLayer.Interfaces;
using Data.Interfaces;
using System.Collections.Generic;
using LogicLayer.Infrastructure;
using AutoMapper;

namespace UnitTestWorkBase
{
    [TestFixture]
    public class careerServiceTest
    {
        private ICareerService careerService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Career>> careerRepository;

        static careerServiceTest()
        {
            Mapper.Initialize(cfg =>
            LogicLayer.Infrastructure.AutoMapperConfig.Initialize()
            );
        }

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            careerRepository = new Mock<IRepository<Career>>();

            uow.Setup(x => x.Careers).Returns(careerRepository.Object);
            uow.Setup(x => x.Resumes.Get(It.IsAny<int>())).Returns(It.IsAny<Resume>());

            careerService = new CareerService(uow.Object);
        }

        [Test]
        public void CreateCareer_TryToCreateNullValue_ShouldThrow()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => careerService.CreateCareer(null));
        }


        [Test]
        public void CreateCareer_TryToCreateCareer_ShouldRepositoryCreateOnce()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>(), Company= It.IsAny<string>(), City = It.IsAny<string>() };

            // act
            careerService.CreateCareer(Career);

            //assert
            careerRepository.Verify(x => x.Create(It.IsAny<Career>()), Times.Once);
        }


        [Test]
        public void GetCareer_TryToGetNullValue_ShouldThrow()
        {
            // act & assert
            NUnit.Framework.Assert.IsNull(careerService.GetCareerById(It.IsAny<int>()));
        }

        [Test]
        public void GetCareer_TryToGetValue_ShouldReturnSomeValue()
        {
            var Career = new Career { Id = It.IsAny<int>(), Company = It.IsAny<string>(), City= It.IsAny<string>() };

            uow.Setup(x => x.Careers.Get(It.IsAny<int>())).Returns(Career);

            NUnit.Framework.Assert.IsNotNull(careerService.GetCareerById(It.IsAny<int>()));
        }


    }
}
