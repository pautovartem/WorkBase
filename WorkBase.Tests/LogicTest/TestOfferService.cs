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
    public class TestOfferService
    {
        private IOfferService offerService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Offer>> offerRepository;
        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            offerRepository = new Mock<IRepository<Offer>>();

            uow.Setup(x => x.Offers).Returns(offerRepository.Object);

            offerService = new OfferService(uow.Object);
        }
        [Test]
        public void CreateOffer_TryToCreateOffer_ShouldRepositoryCreateOnce()
        {
            var Offer = new OfferDTO { Id = It.IsAny<int>() };

            // act
            offerService.CreateOffer(Offer);

            //assert
            offerRepository.Verify(x => x.Create(It.IsAny<Offer>()));
        }
        [Test]
        public void CreateOffer_TryToCreateNullValue_ShouldThrowException()
        {

            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => offerService.CreateOffer(null));
        }
        [Test]
        public void GetOfferById_TryToGetValue_ShouldReturnSomeValue()
        {
            var Offer = new Offer { Id = It.IsAny<int>() };

            uow.Setup(x => x.Offers.Get(It.IsAny<int>())).Returns(Offer);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(offerService.GetOfferById(It.IsAny<int>()));
        }
        [Test]
        public void GetOfferById_GetNullValue_ShouldThrowException()
        {
            //arrange
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Offer>(null);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(offerService.GetOfferById(It.IsAny<int>()));
        }

        [Test]
        public void GetAllOffers_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            offerRepository.Setup(x => x.GetAll()).Returns(new List<Offer>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(offerService.GetAllOffers());
            offerRepository.Verify(x => x.GetAll());
        }

        [Test]
        public void EditOffer_PutInEditNullElement_ShouldThrowException()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => offerService.EditOffer(null));
        }
        [Test]
        public void EditOffer_NullElement_ShouldThrowException()
        {
            //arrange
            var Offer = new OfferDTO { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>(), CareerId = It.IsAny<int>(), Viewed = It.IsAny<bool>() };

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => offerService.EditOffer(Offer));
        }


        [Test]
        public void DeleteOffer_DeleteNullValue()
        {
            //arrange
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Offer>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => offerService.RemoveOffer(It.IsAny<int>()));


        }
        [Test]
        public void DeleteOffer_DeleteRepository_ShouldCallsOnce()
        {
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Offer { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() });

            //act
            offerService.RemoveOffer(It.IsAny<int>());

            //assert
            offerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
        [Test]
        public void RemoveOffer_Delete()
        {
            var Offer = new OfferDTO { Id = It.IsAny<int>(), Viewed = It.IsAny<bool>() };
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Offer { Id = It.IsAny<int>(), Viewed = It.IsAny<bool>() });

            //act
            offerService.RemoveOffer(Offer);

            //assert
            offerRepository.Verify(x => x.Delete(It.IsAny<int>()));

        }
    }
}


       
       


       


