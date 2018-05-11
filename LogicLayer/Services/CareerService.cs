using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class CareerService : ICareerService
    {
        IUnitOfWork Database { get; set; }

        public CareerService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void CreateCareer(CareerDTO careerDTO)
        {
            Database.Careers.Create(Mapper.Map<CareerDTO, Career>(careerDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditCareer(CareerDTO careerDTO)
        {
            Database.Careers.Update(Mapper.Map<CareerDTO, Career>(careerDTO));
            Database.Save();
        }

        public void RemoveCareer(CareerDTO careerDTO)
        {
            Career career = Mapper.Map<CareerDTO, Career>(careerDTO);
            Database.Careers.Delete(career.Id);
            Database.Save();
        }

        public CareerDTO GetCareerById(int id)
        {
            return Mapper.Map<Career, CareerDTO>(Database.Careers.Get(id));
        }

        public IEnumerable<CareerDTO> GetAllCareers()
        {
            return Mapper.Map<IEnumerable<Career>, List<CareerDTO>>(Database.Careers.GetAll());
        }
    }
}
