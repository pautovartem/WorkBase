using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class CareerServiceTest
    {
        [TestMethod]
        public void CareerTestCreate()
        {
            CareerDTO careerDTO = new CareerDTO()
            {
                Id = 789, ContactName = "Menedger",
                RubricId = 000, User = 111
            };
            CareerService cs = new CareerService();
           

        }
    }
}
