using LogicLayer.DTO;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBase.Tests.Mocks
{
    class MockRepositoryResume : IResumeService

    {
        List<ResumeDTO> resumeDTOs = new List<ResumeDTO>();

        public MockRepositoryResume()
        {
            resumeDTOs.Add(new ResumeDTO() { Id = 1, Name = "Vika", Surname = "Pian" });
            resumeDTOs.Add(new ResumeDTO() { Id = 2, Name = "Vika1", Surname = "Pian1" });
            resumeDTOs.Add(new ResumeDTO() { Id = 3, Name = "Vika2", Surname = "Pian2" });
        }
        public void CreateResume(ResumeDTO resumeDTO)
        {
            resumeDTOs.Add(resumeDTO);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditResume(ResumeDTO resumeDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResumeDTO> GetAllResumes()
        {
            return resumeDTOs;
        }

        public ResumeDTO GetResumeById(int id)
        {
            return resumeDTOs.Where(R => R.Id == id).FirstOrDefault();
        }

        public void RemoveResume(ResumeDTO resumeDTO)
        {
            resumeDTOs.Remove(resumeDTO);
        }
    }
}
