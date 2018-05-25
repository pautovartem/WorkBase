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
            Database.Offers.Create(Mapper.Map<OfferDTO, Offer>(offerDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditOffer(OfferDTO offerDTO)
        {
            Offer offer = Database.Offers.Get(offerDTO.Id);

            offer.ResumeId = offerDTO.ResumeId;
            offer.CareerId = offerDTO.CareerId;
            offer.DateSend = offerDTO.DateSend;
            offer.Viewed = offerDTO.Viewed;
            offer.Career = Database.Careers.Get(offer.CareerId);
            offer.Resume = Database.Resumes.Get(offer.ResumeId);

            Database.Offers.Update(offer);
            Database.Save();
        }

        public void RemoveOffer(OfferDTO offerDTO)
        {
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
            Database.Offers.Delete(id);
            Database.Save();
        }
    }
}
