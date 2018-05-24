using System;
using LogicLayer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDTO userDTO = new UserDTO() { Id="1", Name="вапр"};
        }
    }
}
