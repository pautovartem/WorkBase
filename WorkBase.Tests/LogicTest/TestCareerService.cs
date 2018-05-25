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
        public void GetCareer_TryToGetNullValue_ShouldThrow()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            // act & assert
            NUnit.Framework.Assert.IsNull(carService.GetCareerById(It.IsAny<int>()));
        }
        
        [Test]
        public void GetCareer_TryToGetValue_ShouldReturnSomeValue()
        {
            var Career = new Career { Id= It.IsAny<int>()};

            uow.Setup(x => x.Careers.Get(It.IsAny<int>())).Returns(Career);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(carService.GetCareerById(It.IsAny<int>()));
        }
        /*
        [Test]
        public void EditCareer_TryToEditNullElement_ShouldThrow()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>()};
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => carService.EditCareer(Career));
        }
        
        [Test]
        public void EditCareer_TryToEditVerifiedCareer_ShouldThrow()
        {
            var Career = new CareerDTO { Id = It.IsAny<int>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Id= It.IsAny<int>() });

            //act & assert
            NUnit.Framework.Assert.Throws<AuctionException>(() => CareerService.EditCareer(Career));
            Assert.AreEqual(Assert.Throws<AuctionException>(() => CareerService.EditCareer(Career)).Message, "You can`t change the information about the Career after the start of the bidding");
        }
        
        [Test]
        public void EditCareer_EditCareer_ShoudRepositoryEditOnce()
        {
            var Career = new CareerDTO { Name = It.IsAny<string>(), Price = It.IsAny<double>(), TradeDuration = It.IsAny<int>() };
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Name = It.IsAny<string>(), Price = It.IsAny<double>(), TradeDuration = It.IsAny<int>() });

            //act
            CareerService.EditCareer(Career);

            //assert
            careerRepository.Verify(x => x.Update(It.IsAny<Career>()), Times.Once);
        }

        [Test]
        public void DeleteCareer_DeleteNullValue()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            Assert.Throws<ArgumentNullException>(() => CareerService.RemoveCareer(It.IsAny<int>()));
        }

        [Test]
        public void DeleteCareer_DeleteRepositoryShouldCallsOnce()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Name = It.IsAny<string>(), Price = It.IsAny<double>(), TradeDuration = It.IsAny<int>() });

            //act
            CareerService.RemoveCareer(It.IsAny<int>());

            //assert
            careerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }

        [Test]
        public void VarifyCareer_TryToVarifyNullCareer_ShouldThrow()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            Assert.Throws<ArgumentNullException>(() => CareerService.VerifyCareer(It.IsAny<int>()));
        }

        [Test]
        public void VarifyCareer_TryToVirifySomeCareer_ShouldCallOnce()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Name = It.IsAny<string>(), Price = It.IsAny<double>(), TradeDuration = It.IsAny<int>() });

            //act 
            CareerService.VerifyCareer(It.IsAny<int>());

            //assert
            careerRepository.Verify(x => x.Update(It.IsAny<Career>()), Times.Once);
        }

        [Test]
        public void ChangeCareerCategory_TryToChangeWithNullCategory_ShouldThrow()
        {
            uow.Setup(x => x.Categories.Get(It.IsAny<int>())).Returns<Category>(null);

            //act & assert
            Assert.Throws<ArgumentNullException>(() => CareerService.ChangeCareerCategory(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void ChangeCareerCategory_TryToChangeWithNullCareer_ShouldThrow()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Career>(null);

            //act & assert
            Assert.Throws<ArgumentNullException>(() => CareerService.ChangeCareerCategory(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void ChangeCareerCategory_TryToChange_ShouldCallsOnce()
        {
            careerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Career { Name = It.IsAny<string>(), Price = It.IsAny<double>(), TradeDuration = It.IsAny<int>() });

            //act
            CareerService.ChangeCareerCategory(It.IsAny<int>(), It.IsAny<int>());

            //assert
            careerRepository.Verify(x => x.Update(It.IsAny<Career>()), Times.Once);
        }

        [Test]
        public void GetAllCareers_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            careerRepository.Setup(x => x.GetAll()).Returns(new List<Career>() { });

            //act & assert
            Assert.IsNotNull(CareerService.GetAllCareers());
            careerRepository.Verify(x => x.GetAll());
        }*/
    }
}


