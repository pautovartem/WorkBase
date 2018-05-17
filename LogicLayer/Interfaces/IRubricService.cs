using LogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IRubricService
    {
        void CreateRubric(RubricDTO rubricDTO);
        void EditRubric(RubricDTO rubricDTO);
        void RemoveRubric(RubricDTO rubricDTO);

        RubricDTO GetRubricById(int id);
        IEnumerable<RubricDTO> GetAllRubrics();

        void Dispose();
    }
}
