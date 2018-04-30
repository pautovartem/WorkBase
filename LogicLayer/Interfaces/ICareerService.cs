using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface ICareerService
    {
        void CreateCareer(CareerDTO careerDTO);
        void EditCareer(CareerDTO careerDTO);
        void RemoveCareer(CareerDTO careerDTO);
        void Dispose();
    }
}
