using System;
using System.Collections.Generic;
using LogicLayer.DTO;
using LogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Tests.Mocks;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class ResumeServiceTest
    {
        static ResumeServiceTest()
        {
            LogicLayer.Infrastructure.AutoMapperConfig.Initialize();
        }
        [TestMethod]
        public void ResumeTestGetAll()
        {
          //  MockAutoMapper.MockInitialize();
            MockUoW mockUoW = new MockUoW();
            ResumeService r = new ResumeService(mockUoW);

            IEnumerable<ResumeDTO> res = r.GetAllResumes();

            Assert.IsNotNull(res);

        }

        [TestMethod]
        public void ResumeTestCreate()
        {
            MockUoW mockUoW = new MockUoW();
            ResumeService r = new ResumeService(mockUoW);

            r.CreateResume(new ResumeDTO() { Id = 1 });

            ResumeDTO rd = r.GetResumeById(1);
            Assert.IsNotNull(rd);

        }
        [TestMethod]
        public void ResumeTestRemove()
        {

            MockUoW mockUoW = new MockUoW();
            ResumeService r = new ResumeService(mockUoW);

            r.RemoveResume(new ResumeDTO() { Id = 1 });

            ResumeDTO rd = r.GetResumeById(1);
            Assert.IsNull(rd);

        }
        [TestMethod]
        public void ResumeTestEdit()
        {
            MockUoW mockUoW = new MockUoW();
            ResumeService r = new ResumeService(mockUoW);

            r.EditResume(new ResumeDTO() { Id = 1 });

            ResumeDTO rd = r.GetResumeById(1);
            Assert.IsNotNull(rd);

        }
    }
}
