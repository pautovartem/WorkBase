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
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            Database = unitOfWork;
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
            Career career = Database.Careers.Get(careerDTO.Id);
            career.Title = careerDTO.Title;
            career.Company = careerDTO.Company;
            career.City = careerDTO.City;
            career.ContactName = careerDTO.ContactName;
            career.ContactPhone = careerDTO.ContactPhone;
            career.Site = careerDTO.Site;
            career.RubricId = careerDTO.RubricId;
            career.Desctiption = careerDTO.Desctiption;
            career.UserId = careerDTO.UserId;

            Database.Careers.Update(career);
            Database.Save();
        }

        public void RemoveCareer(CareerDTO careerDTO)
        {
            Database.Careers.Delete(careerDTO.Id);
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

        public void RemoveCareer(int id)
        {
            Database.Careers.Delete(id);
            Database.Save();
        }

        public IEnumerable<OfferDTO> GetOffers(int careerId)
        {
            if (careerId == 0)
                throw new ArgumentNullException(nameof(careerId));

            Career career = Database.Careers.Get(careerId);

            if (career == null)
                throw new Exception("Not find career");

            return Mapper.Map<IEnumerable<Offer>, List<OfferDTO>>(Database.Careers.Get(careerId).Offers);
        }
    }
}
