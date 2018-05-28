using System;
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
            Mapper.Initialize(cfg =>
           LogicLayer.Infrastructure.AutoMapperConfig.Configure(cfg)
           );
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
        public void CreateCareer_TryToCreateNullValue_ShouldThrowException()
        {

            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => carService.CreateCareer(null));
        }
        [Test]
        public void GetCareerById_GetNullValue_ShouldThrowException()
        {
            //arrange
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            // act & assert
            NUnit.Framework.Assert.IsNull(carService.GetCareerById(It.IsAny<int>()));
        }
        [Test]
        public void GetCareerById_GetValue_ShouldReturnSomeValue()
        {
            var Career = new Career { Id= It.IsAny<int>()};

            uow.Setup(x => x.Careers.Get(It.IsAny<int>())).Returns(Career);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(carService.GetCareerById(It.IsAny<int>()));
        }
        [Test]
        public void GetOffers_TryToGetValue_ShouldReturnSomeValue()
        {
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => carService.GetOffers(0));
        }
        [Test]
        public void GetOffers_GetValue_ShouldReturnSomeValue()
        {
           
        }
        [Test]
        public void EditCareer_EditCareer_ShoudRepositoryEditOnce()
        { //arrange
            var Career = new CareerDTO { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id = It.IsAny<int>(), ContactPhone= It.IsAny<string>() });

            //act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => carService.EditCareer(Career));
           
        }

        [Test]
        public void EditCareer_PutInEditNullElement_ShouldThrowException()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => carService.EditCareer(null));
        }

        [Test]
        public void EditCareer_NullElement_ShouldThrowException()
        {
            //arrange
            var Career = new CareerDTO { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => carService.EditCareer(Career));
        }

        [Test]
        public void RemoveCareerById_RemoveRepositoryById_ShouldCallsOnce()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() });

            //act
            carService.RemoveCareer(It.IsAny<int>());

            //assert
            careerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
        [Test]
        public void RemoveCareer_RemoveRepository_ShouldCallsOnce()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id = It.IsAny<int>(), ContactName = It.IsAny<string>(), ContactPhone = It.IsAny<string>() });

            //act
            carService.RemoveCareer(Career);

            //assert
            careerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
        [Test]
        public void DeleteCareer_DeleteFalseId_ShoudThrowExeption()
        {
            //arrange
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => carService.RemoveCareer(It.IsAny<int>()));
        }
        [Test]
        public void GetAllCareers_GetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            careerRepository.Setup(x => x.GetAll()).Returns(new List<Career>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(carService.GetAllCareers());
            careerRepository.Verify(x => x.GetAll());
        }
    }
}

     

       

       