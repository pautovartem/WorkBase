using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IRubricService
    {
        void CreateRubric(RubricDTO rubricDTO);
        void EditRubric(RubricDTO rubricDTO);
        void RemoveRubric(RubricDTO rubricDTO);
        void Dispose();
    }
}
