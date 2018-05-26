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
    [TestFixture]
    public class TestCareerService
    {
        private ICareerService carService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Career>> careerRepository;

        static TestCareerService()
        {
            AutoMapperConfig.Initialize();
        }

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            careerRepository = new Mock<IRepository<Career>>();

            uow.Setup(x => x.Careers).Returns(careerRepository.Object);
            uow.Setup(x => x.Offers.Get(It.IsAny<int>())).Returns(new Offer { Id = It.IsAny<int>() });

            carService = new CareerService(uow.Object);
        }

    


        [Test]
        public void CreateCareer_TryToCreateCareer_ShouldRepositoryCreateOnce()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>() };

            // act
          carService.CreateCareer(Career);

            //assert
            careerRepository.Verify(x => x.Create(It.IsAny<Career>()));
        }

        [Test]
        public void GetCareerById_TryToGetValue_ShouldReturnSomeValue()
        {
            var Career = new Career { Id= It.IsAny<int>()};

            uow.Setup(x => x.Careers.Get(It.IsAny<int>())).Returns(Career);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(carService.GetCareerById(It.IsAny<int>()));
        }
       /* [Test] //нужно реализовать
        public void EditCareer_TryToEditNullElement_ShouldThrow()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>()};
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => carService.EditCareer(Career));
        }
        
      */
        [Test]
        public void EditCareer_EditCareer_ShoudRepositoryEditOnce()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() });

            //act
            carService.EditCareer(Career);

            //assert
            careerRepository.Verify(x => x.Update(It.IsAny<Career>()), Times.Once);
        }

        [Test]
        public void DeleteCareer_DeleteRepositoryShouldCallsOnce()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() });

            //act
            carService.RemoveCareer(It.IsAny<int>());

            //assert
            careerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }

        [Test]
        public void GetAllCareers_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            careerRepository.Setup(x => x.GetAll()).Returns(new List<Career>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(carService.GetAllCareers());
            careerRepository.Verify(x => x.GetAll());
        }
    }
}


