using System;
using System.Collections.Generic;
using LogicLayer.DTO;
using LogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkBase.Tests.Mocks;

namespace WorkBase.Tests.LogicTest
{
    [TestClass]
    public class ExperienceServiceTest
    {
        [TestMethod]
        public void ExperienceTestGetAll()
        {
            MockUoW mockUoW = new MockUoW();
            ExperienceService exp = new ExperienceService(mockUoW);

            IEnumerable<ResumesExperienceDTO> exps = exp.GetAllExperiences();

            Assert.IsNotNull(exps);

        }

        [TestMethod]
        public void ExperienceTestCreate()
        {
            MockUoW mockUoW = new MockUoW();
            ExperienceService exp = new ExperienceService(mockUoW);

            exp.CreateExperience(new ResumesExperienceDTO() { Id = 1 });

            ResumesExperienceDTO ca = exp.GetExperienceById(1);
            Assert.IsNotNull(ca);

        }
        [TestMethod]
        public void ExperienceTestRemove()
        {
            MockUoW mockUoW = new MockUoW();
            ExperienceService exp = new ExperienceService(mockUoW);

            exp.RemoveExperience(new ResumesExperienceDTO() { Id = 1 });

            ResumesExperienceDTO ca = exp.GetExperienceById(1);
            Assert.IsNull(ca);

        }
        [TestMethod]
        public void ExperienceTestEdit()
        {
            MockUoW mockUoW = new MockUoW();
            ExperienceService exp = new ExperienceService(mockUoW);

            exp.EditExperience(new ResumesExperienceDTO() { Id = 1 });

            ResumesExperienceDTO ca = exp.GetExperienceById(1);
            Assert.IsNotNull(ca);

        }
    }

}

