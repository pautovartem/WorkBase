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
                return Content(System.Net.HttpStatusCode.NoContent, "Not found offer");
            else
                return Ok(offerView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/offers/{id:int}/details")]
        public IHttpActionResult GetOfferDetails(int id)
        {
            OfferDetailsViewModel offerView = Mapper.Map<OfferDTO, OfferDetailsViewModel>(offerService.GetOfferById(id));

            if (offerView == null)
                return Content(System.Net.HttpStatusCode.NoContent, "Not found offer");
            else
                return Ok(offerView);
        }

        [HttpPost]
        [Authorize(Roles = "employer, worker")]
        [Route("api/offers/add")]
        public IHttpActionResult Add(OfferViewModel offerView)
        {
            try
            {
                offerService.CreateOffer(Mapper.Map<OfferViewModel, OfferDTO>(offerView));

                return Ok("Offer is created");
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Not correct input data");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }

        [HttpPut]
        [Authorize(Roles = "employer, worker")]
        [Route("api/offers/edit")]
        public IHttpActionResult Edit(OfferViewModel offerView)
        {
            try
            {
                offerService.EditOffer(Mapper.Map<OfferViewModel, OfferDTO>(offerView));

                return Ok("Offer is edited");
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Not correct input data");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "employer, worker")]
        [Route("api/offers/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                offerService.RemoveOffer(id);

                return Ok("Offer is deleted");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }
    }
}