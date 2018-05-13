using System;
using LogicLayer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Controllers;

namespace WorkBase.Tests.ControllersTest
{
    [TestClass]
    public class ResumesControllerTest
    {
        [TestMethod]
        public void ResumeControllerGetTest()
        {
            Mocks.MockRepositoryResume mockRepository = new Mocks.MockRepositoryResume();
            ResumesController resumesController = new ResumesController(mockRepository);
            ResumeDTO d = null;
            try
            {
                d = resumesController.Get(2);//человек проверь
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(d);
        
            }
    }
}
