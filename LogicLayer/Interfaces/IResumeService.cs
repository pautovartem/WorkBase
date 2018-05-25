using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IResumeService
    {
        void CreateResume(ResumeDTO resumeDTO);
        void EditResume(ResumeDTO resumeDTO);
        void RemoveResume(ResumeDTO resumeDTO);
        void RemoveResume(int id);

        void AddExperience(ResumesExperienceDTO experienceDTO);
        void RemoveExperience(int resumeId, int experienceId);

        ResumeDTO GetResumeById(int id);
        IEnumerable<ResumeDTO> GetAllResumes();

        IEnumerable<ResumesExperienceDTO> GetExperiences(int resumeId);
        IEnumerable<OfferDTO> GetOffers(int resumeId);

        void Dispose();
    }
}
