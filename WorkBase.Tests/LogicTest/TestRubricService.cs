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
    public class TestRubricService
    {
        private IRubricService rubricService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Rubric>> rubricRepository;
        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            rubricRepository = new Mock<IRepository<Rubric>>();

            uow.Setup(x => x.Rubrics).Returns(rubricRepository.Object);

            rubricService = new RubricService(uow.Object);
        }
        [Test]
        public void CreateRubric_TryToCreateRubric_ShouldRepositoryCreateOnce()
        {
            var Rubric = new RubricDTO { Id = It.IsAny<int>() };

            // act
            rubricService.CreateRubric(Rubric);

            //assert
            rubricRepository.Verify(x => x.Create(It.IsAny<Rubric>()));
        }
        [Test]
        public void GetRubricById_TryToGetValue_ShouldReturnSomeValue()
        {
            var Rubric = new Rubric { Id = It.IsAny<int>() };

            uow.Setup(x => x.Rubrics.Get(It.IsAny<int>())).Returns(Rubric);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(rubricService.GetRubricById(It.IsAny<int>()));
        }
        [Test]
        public void GetAllRubrics_TryToGetSomeList_ShouldRepositoryCallOnce_ShouldReturnNotNullList()
        {
            rubricRepository.Setup(x => x.GetAll()).Returns(new List<Rubric>() { });

            //act & assert
            NUnit.Framework.Assert.IsNotNull(rubricService.GetAllRubrics());
            rubricRepository.Verify(x => x.GetAll());
        }
        [Test]
        public void EditRubric_EditRubric_ShoudRepositoryEditOnce()
        {//
            var Rubric = new RubricDTO { Id = It.IsAny<int>(), Name = It.IsAny<string>() };
            rubricRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Rubric { Id = It.IsAny<int>(), Name = It.IsAny<string>() });

            //act
            rubricService.EditRubric(Rubric);

            //assert
            rubricRepository.Verify(x => x.Update(It.IsAny<Rubric>()), Times.Once);
        }

        [Test]
        public void DeleteRubric_DeleteRepositoryShouldCallsOnce()
        {
            rubricRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Rubric { Id = It.IsAny<int>(), Name = It.IsAny<string>() });

            //act
            rubricService.RemoveRubric(It.IsAny<int>());

            //assert
            rubricRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
        [Test]
        public void GetRubricById_GetNullValue_ShouldThrowException()
        {
            //arrange
            rubricRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Rubric>(null);

            // act & assert
            NUnit.Framework.Assert.IsNotNull(rubricService.GetRubricById(It.IsAny<int>()));
        }


        [Test]
        public void EditRubric_PutInEditNullElement_ShouldThrowException()
        {
            // act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => rubricService.EditRubric(null));
        }
        [Test]
        public void EditRubric_NullElement_ShouldThrowException()
        {
            //arrange
            var Rubric = new RubricDTO { Id = It.IsAny<int>() };

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => rubricService.EditRubric(Rubric));
        }


        [Test]
        public void DeleteRubric_DeleteNullValue()
        {
            //arrange
            rubricRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Rubric>(null);

            //act & assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => rubricService.RemoveRubric(It.IsAny<int>()));


        }
    }
}

