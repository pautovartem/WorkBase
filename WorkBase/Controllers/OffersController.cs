using AutoMapper;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WorkBase.Models;

namespace WorkBase.Controllers
{
    public class OffersController : ApiController
    {
        IOfferService offerService;

        public OffersController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet]
        [Authorize]
        [Route("api/offers/")]
        public IHttpActionResult GetOffers()
        {
            return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferViewModel>>(offerService.GetAllOffers()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/offers/details")]
        public IHttpActionResult GetOffersDetails()
        {
            return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferDetailsViewModel>>(offerService.GetAllOffers()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/offers/{id:int}")]
        public IHttpActionResult GetOffer(int id)
        {
            OfferViewModel offerView = Mapper.Map<OfferDTO, OfferViewModel>(offerService.GetOfferById(id));

            if (offerView == null)
                return NotFound();

            return Ok(offerView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/offers/{id:int}/details")]
        public IHttpActionResult GetOfferDetails(int id)
        {
            OfferDetailsViewModel offerView = Mapper.Map<OfferDTO, OfferDetailsViewModel>(offerService.GetOfferById(id));

            if (offerView == null)
                return NotFound();

            return Ok(offerView);
        }

        [HttpPost]
        [Authorize]
        [Route("api/offers/add")]
        public IHttpActionResult Add(OfferViewModel offerView)
        {
            offerService.CreateOffer(Mapper.Map<OfferViewModel, OfferDTO>(offerView));

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("api/offers/edit")]
        public IHttpActionResult Edit(OfferViewModel offerView)
        {
            offerService.EditOffer(Mapper.Map<OfferViewModel, OfferDTO>(offerView));

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("api/offers/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            offerService.RemoveOffer(id);

            return Ok();
        }
    }
}