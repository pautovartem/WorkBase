using LogicLayer.DTO;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IOfferService
    {
        void CreateOffer(OfferDTO offerDTO);
        void EditOffer(OfferDTO offerDTO);
        void RemoveOffer(OfferDTO offerDTO);

        OfferDTO GetOfferById(int id);
        IEnumerable<OfferDTO> GetAllOffers();

        void Dispose();
    }
}
