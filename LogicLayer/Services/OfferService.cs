using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class OfferService : IOfferService
    {
        IUnitOfWork Database { get; set; }

        public OfferService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            Database = unitOfWork;
        }

        public void CreateOffer(OfferDTO offerDTO)
        {
            if (offerDTO == null)
                throw new ArgumentNullException(nameof(offerDTO));

            if (offerDTO.Id != 0 && Database.Offers.Get(offerDTO.Id) != null)
                throw new ArgumentOutOfRangeException("Found duplicate id offer");

            Database.Offers.Create(Mapper.Map<OfferDTO, Offer>(offerDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditOffer(OfferDTO offerDTO)
        {
            if (offerDTO == null)
                throw new ArgumentNullException(nameof(offerDTO));

            Resume resume;
            try
            {
                resume = Database.Resumes.Get(offerDTO.ResumeId);
            }
            catch(NullReferenceException)
            {
                throw new ArgumentOutOfRangeException("Invalid argument ResumeId");
            }

            Career career = Database.Careers.Get(offerDTO.CareerId);

            if (career == null)
                throw new ArgumentOutOfRangeException("Invalid argument CareerId");

            Offer offer = Database.Offers.Get(offerDTO.Id);

            if (offer == null)
                throw new ArgumentOutOfRangeException("Not found offer");

            offer.ResumeId = offerDTO.ResumeId;
            offer.CareerId = offerDTO.CareerId;
            offer.DateSend = offerDTO.DateSend;
            offer.Viewed = offerDTO.Viewed;
            offer.Career = career;
            offer.Resume = resume;

            Database.Offers.Update(offer);
            Database.Save();
        }

        public void RemoveOffer(OfferDTO offerDTO)
        {
            if (offerDTO == null)
                throw new ArgumentNullException(nameof(offerDTO));

            if (Database.Offers.Get(offerDTO.Id) == null)
                throw new ArgumentOutOfRangeException("Not found offer");

            Database.Offers.Delete(offerDTO.Id);
            Database.Save();
        }

        public OfferDTO GetOfferById(int id)
        {
            return Mapper.Map<Offer, OfferDTO>(Database.Offers.Get(id));
        }

        public IEnumerable<OfferDTO> GetAllOffers()
        {
            return Mapper.Map<IEnumerable<Offer>, List<OfferDTO>>(Database.Offers.GetAll());
        }

        public void RemoveOffer(int id)
        {
            if (Database.Offers.Get(id) == null)
                throw new ArgumentOutOfRangeException("Not found offer");

            Database.Offers.Delete(id);
            Database.Save();
        }
    }
}
