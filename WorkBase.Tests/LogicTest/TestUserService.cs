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
    public class TestUserService
    {
        private IUserService userService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<User>> userRepository;
        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            userRepository = new Mock<IRepository<User>>();

            uow.Setup(x => x.Users).Returns(userRepository.Object);
            // uow.Setup(x => x.Categories.Get(It.IsAny<int>())).Returns(new Category { Name = It.IsAny<string>() });

            userService = new UserService(uow.Object);
        }
        [Test]
        public void CreateUser_TryToCreateUser_ShouldRepositoryCreateOnce()
        {
            var User = new UserDTO { Id = It.IsAny<string>() };

            // act
            userService.Create(User);

            //assert
            userRepository.Verify(x => x.Create(It.IsAny<User>()));
        }
        [Test]
        public void GetUserById_TryToGetValue_ShouldReturnSomeValue()
        {
            var User = new User { Id = It.IsAny<string>() };

            uow.Setup(x => x.Users.Get(It.IsAny<string>())).Returns(User);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(userService.GetUserById(It.IsAny<string>()));
        }
        [Test]
        public void GetAllUsers_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            userRepository.Setup(x => x.GetAll()).Returns(new List<User>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(userService.GetUsers());
            userRepository.Verify(x => x.GetAll());
        }
    
    }
}




