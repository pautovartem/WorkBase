using System;
using LogicLayer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Controllers;

namespace WorkBase.Tests.ControllersTest
{
    [TestClass]
    public class RubricsControllerTest
    {
        [TestMethod]
        public void RubricControllerGetTest()
        {
            Mocks.MockRepositoryRubric mockRepository = new Mocks.MockRepositoryRubric();
            RubricsController rubricsController = new RubricsController(mockRepository);
            RubricDTO d = null;
            try
            {
                d = rubricsController.Get(0);//человек проверь
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(d);
        }
    }
}
