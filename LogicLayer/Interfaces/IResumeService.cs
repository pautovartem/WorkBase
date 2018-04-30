using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IResumeService
    {
        void CreateResume(ResumeDTO resumeDTO);
        void EditResume(ResumeDTO resumeDTO);
        void RemoveResume(ResumeDTO resumeDTO);
        void Dispose();
    }
}
