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
           // uow.Setup(x => x.Categories.Get(It.IsAny<int>())).Returns(new Category { Name = It.IsAny<string>() });

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
        public void GetOfferById_TryToGetValue_ShouldReturnSomeValue()
        {
            var Offer = new Offer { Id = It.IsAny<int>() };

            uow.Setup(x => x.Offers.Get(It.IsAny<int>())).Returns(Offer);

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
        public void EditOffer_EditOffer_ShoudRepositoryEditOnce()
        {//
            /*var Offer = new OfferDTO { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>()  };
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Offer { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() });

            //act
            offerService.EditOffer(Offer);

            //assert
            offerRepository.Verify(x => x.Update(It.IsAny<Offer>()), Times.Once);*/
        }

        [Test]
        public void DeleteOffer_DeleteRepositoryShouldCallsOnce()
        {
            offerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Offer { Id = It.IsAny<int>(), ResumeId = It.IsAny<int>() });

            //act
            offerService.RemoveOffer(It.IsAny<int>());

            //assert
            offerRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }

    }
}

