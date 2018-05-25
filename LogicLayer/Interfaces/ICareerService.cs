using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface ICareerService
    {
        void CreateCareer(CareerDTO careerDTO);
        void EditCareer(CareerDTO careerDTO);
        void RemoveCareer(CareerDTO careerDTO);
        void RemoveCareer(int id);

        CareerDTO GetCareerById(int id);
        IEnumerable<CareerDTO> GetAllCareers();

        IEnumerable<OfferDTO> GetOffers(int careerId);

        void Dispose();
    }
}
