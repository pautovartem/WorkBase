using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IOfferService
    {
        void CreateOffer(OfferDTO offerDTO);
        void EditOffer(OfferDTO offerDTO);
        void RemoveOffer(OfferDTO offerDTO);
        void Dispose();
    }
}
