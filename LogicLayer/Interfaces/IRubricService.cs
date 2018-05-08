using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IRubricService
    {
        void CreateRubric(RubricDTO rubricDTO);
        void EditRubric(RubricDTO rubricDTO);
        void RemoveRubric(RubricDTO rubricDTO);

        IEnumerable<RubricDTO> GetAllRubrics();
        void Dispose();
    }
}
