using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IExperienceService
    {
        void CreateExperience(ResumesExperienceDTO experienceDTO);
        void EditExperience(ResumesExperienceDTO experienceDTO);
        void RemoveExperience(ResumesExperienceDTO experienceDTO);
        void RemoveExperience(int id);

        ResumesExperienceDTO GetExperienceById(int id);
        IEnumerable<ResumesExperienceDTO> GetAllExperiences();

        void Dispose();
    }
}
