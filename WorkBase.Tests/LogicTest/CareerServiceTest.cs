using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using WorkBase.Tests.Mocks;
using LogicLayer.Services;
using System.Collections.Generic;
using LogicLayer.DTO;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class CareerServiceTest
    {
      
        [TestMethod]
        public void CareerTestGetAll()
        {
            
            MockUoW mockUoW = new MockUoW();
            CareerService career = new CareerService(mockUoW);

            IEnumerable<CareerDTO> careers = career.GetAllCareers();

            Assert.IsNotNull(careers);

        }

        [TestMethod]
        public void CareerTestCreate()
        {
           
            MockUoW mockUoW = new MockUoW();
            CareerService career = new CareerService(mockUoW);

            career.CreateCareer(new CareerDTO() { Id = 1});

            CareerDTO ca= career.GetCareerById(1);
            Assert.IsNotNull(ca);

        }
        [TestMethod]
        public void CareerTestRemove()
        {
           
            MockUoW mockUoW = new MockUoW();
            CareerService career = new CareerService(mockUoW);

            career.RemoveCareer(new CareerDTO() { Id = 1 });

            CareerDTO ca = career.GetCareerById(1);
            Assert.IsNull(ca);

        }
        [TestMethod]
        public void CareerTestEdit()
        {
            MockUoW mockUoW = new MockUoW();
            CareerService career = new CareerService(mockUoW);

            career.EditCareer(new CareerDTO() { Id = 1 });

            CareerDTO ca = career.GetCareerById(1);
            Assert.IsNotNull(ca);

        }
    }
}
