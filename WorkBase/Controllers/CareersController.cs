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
    public class CareersController : ApiController
    {
        ICareerService careerService;
        IUserService userService;

        public CareersController(ICareerService careerService, IUserService userService)
        {
            this.careerService = careerService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/")]
        public IHttpActionResult GetCareers()
        {
            return Ok(Mapper.Map<IEnumerable<CareerDTO>, List<CareerViewModel>>(careerService.GetAllCareers()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/minimum")]
        public IHttpActionResult GetCareersMinimum()
        {
            return Ok(Mapper.Map<IEnumerable<CareerDTO>, List<CareerMinimumViewModel>>(careerService.GetAllCareers()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/{id:int}")]
        public IHttpActionResult GetCareer(int id)
        {
            CareerViewModel careerView = Mapper.Map<CareerDTO, CareerViewModel>(careerService.GetCareerById(id));

            if (careerView == null)
                return NotFound();

            return Ok(careerView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/{id:int}/minimum")]
        public IHttpActionResult GetCareerMinimum(int id)
        {
            CareerMinimumViewModel careerMinimumView = Mapper.Map<CareerDTO, CareerMinimumViewModel>(careerService.GetCareerById(id));

            if (careerMinimumView == null)
                return NotFound();

            return Ok(careerMinimumView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/{id:int}/offers")]
        public IHttpActionResult GetOffers(int id)
        {
            return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferViewModel>>(careerService.GetOffers(id)));
        }

        [HttpPost]
        [Authorize]
        [Route("api/careers/add")]
        public IHttpActionResult Add(CareerViewModel careerView)
        {
            CareerDTO careerDTO = Mapper.Map<CareerViewModel, CareerDTO>(careerView);
            careerDTO.User = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            careerDTO.UserId = careerDTO.User.Id;

            careerService.CreateCareer(careerDTO);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("api/careers/edit")]
        public IHttpActionResult Edit(CareerViewModel careerView)
        {
            careerService.EditCareer(Mapper.Map<CareerViewModel, CareerDTO>(careerView));

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("api/careers/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            careerService.RemoveCareer(id);

            return Ok();
        }
    }
}