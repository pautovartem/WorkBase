using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IExperienceService
    {
        void CreateExperience(ResumesExperienceDTO experienceDTO);
        void EditExperience(ResumesExperienceDTO experienceDTO);
        void RemoveExperience(ResumesExperienceDTO experienceDTO);
        void Dispose();
    }
}
