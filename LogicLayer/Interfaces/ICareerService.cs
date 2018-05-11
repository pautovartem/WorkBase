using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface ICareerService
    {
        void CreateCareer(CareerDTO careerDTO);
        void EditCareer(CareerDTO careerDTO);
        void RemoveCareer(CareerDTO careerDTO);

        CareerDTO GetCareerById(int id);
        IEnumerable<CareerDTO> GetAllCareers();

        void Dispose();
    }
}
