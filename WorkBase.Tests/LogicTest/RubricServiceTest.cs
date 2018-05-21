using System;
using System.Collections.Generic;
using LogicLayer.DTO;
using LogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Tests.Mocks;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class RubricServiceTest
    {
        [TestMethod]
        public void RubricTestGetAll()
        {
            MockUoW mockUoW = new MockUoW();
            RubricService r = new RubricService(mockUoW);

            IEnumerable<RubricDTO> res = r.GetAllRubrics();

            Assert.IsNotNull(res);

        }

        [TestMethod]
        public void RubricTestCreate()
        {
            MockUoW mockUoW = new MockUoW();
            RubricService r = new RubricService(mockUoW);

            r.CreateRubric(new RubricDTO() { Id = 1 });

            RubricDTO ru = r.GetRubricById(1);
            Assert.IsNotNull(ru);

        }
        [TestMethod]
        public void RubricTestRemove()
        {
            MockUoW mockUoW = new MockUoW();
            RubricService r = new RubricService(mockUoW);

            r.RemoveRubric(new RubricDTO() { Id = 1 });

            RubricDTO ru = r.GetRubricById(1);
            Assert.IsNull(ru);

        }
        [TestMethod]
        public void RubricTestEdit()
        {
            MockUoW mockUoW = new MockUoW();
            RubricService r = new RubricService(mockUoW);

            r.EditRubric(new RubricDTO() { Id = 1 });

            RubricDTO ru = r.GetRubricById(1);
            Assert.IsNotNull(ru);

        }
    }
}
