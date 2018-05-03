﻿using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;

namespace LogicLayer.Services
{
    public class OfferService : IOfferService
    {
        IUnitOfWork Database { get; set; }

        public OfferService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
            Database.Offers.Update(Mapper.Map<OfferDTO, Offer>(offerDTO));
            Database.Save();
        }

        public void RemoveOffer(OfferDTO offerDTO)
        {
            Offer offer = Mapper.Map<OfferDTO, Offer>(offerDTO);
            Database.Offers.Delete(offer.Id);
            Database.Save();
        }
    }
}
