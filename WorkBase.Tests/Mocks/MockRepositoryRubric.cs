using LogicLayer.DTO;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBase.Tests.Mocks
{
    class MockRepositoryRubric:IRubricService
    {
        List<RubricDTO> rubricDTOs = new List<RubricDTO>();
        public MockRepositoryRubric()
        {
            rubricDTOs.Add(new RubricDTO() {Id=0,Name="Vasia" });
            rubricDTOs.Add(new RubricDTO() { Id = 3, Name = "Vasia3" });
            rubricDTOs.Add(new RubricDTO() { Id = 4, Name = "Vasia4" });
        }

        public void CreateRubric(RubricDTO rubricDTO)
        {
            rubricDTOs.Add(rubricDTO);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditRubric(RubricDTO rubricDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RubricDTO> GetAllRubrics()
        {
            return rubricDTOs;
        }

        public RubricDTO GetRubricById(int id)
        {
            return rubricDTOs.Where(R => R.Id == id).FirstOrDefault();
        }

        public void RemoveRubric(RubricDTO rubricDTO)
        {
           rubricDTOs.Remove(rubricDTO);
        }
    }
}
