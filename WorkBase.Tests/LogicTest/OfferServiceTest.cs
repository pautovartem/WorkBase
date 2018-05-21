using System;
using System.Collections.Generic;
using LogicLayer.DTO;
using LogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Tests.Mocks;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class OfferServiceTest
    {
        [TestMethod]
        public void OfferTestGetAll()
        {
            MockUoW mockUoW = new MockUoW();
            OfferService of = new OfferService(mockUoW);

            IEnumerable<OfferDTO> ofs = of.GetAllOffers();

            Assert.IsNotNull(ofs);

        }

        [TestMethod]
        public void OfferTestCreate()
        {
            MockUoW mockUoW = new MockUoW();
            OfferService of = new OfferService(mockUoW);

            of.CreateOffer(new OfferDTO() { Id = 1 });

           OfferDTO ca = of.GetOfferById(1);
            Assert.IsNotNull(ca);

        }
        [TestMethod]
        public void OfferTestRemove()
        {
            MockUoW mockUoW = new MockUoW();
            OfferService of = new OfferService(mockUoW);

            of.RemoveOffer(new OfferDTO() { Id = 1 });

            OfferDTO ca = of.GetOfferById(1);
            Assert.IsNull(ca);

        }
        [TestMethod]
        public void OfferTestEdit()
        {
            MockUoW mockUoW = new MockUoW();
            OfferService of = new OfferService(mockUoW);

            of.EditOffer(new OfferDTO() { Id = 1 });

            OfferDTO ca = of.GetOfferById(1);
            Assert.IsNotNull(ca);

        }
    }
}
