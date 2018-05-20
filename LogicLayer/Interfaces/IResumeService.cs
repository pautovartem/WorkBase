using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IResumeService
    {
        void CreateResume(ResumeDTO resumeDTO);
        void EditResume(ResumeDTO resumeDTO);
        void RemoveResume(ResumeDTO resumeDTO);

        ResumeDTO GetResumeById(int id);
        IEnumerable<ResumeDTO> GetAllResumes(int options = 0);

        void Dispose();
    }
}
