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
        [Authorize(Roles = "admin")]
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
            //try
            //{
            CareerViewModel careerView = Mapper.Map<CareerDTO, CareerViewModel>(careerService.GetCareerById(id));

            if (careerView == null)
                return Content(System.Net.HttpStatusCode.NoContent, "Not found career");
            else
                return Ok(careerView);
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    return Content(System.Net.HttpStatusCode.NoContent, ex.ParamName);
            //}
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/{id:int}/minimum")]
        public IHttpActionResult GetCareerMinimum(int id)
        {
            //try
            //{
                CareerMinimumViewModel careerMinimumView = Mapper.Map<CareerDTO, CareerMinimumViewModel>(careerService.GetCareerById(id));

                if (careerMinimumView == null)
                    return Content(System.Net.HttpStatusCode.NoContent, "Not found career");
                else
                    return Ok(careerMinimumView);
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    return Content(System.Net.HttpStatusCode.NoContent, ex.ParamName);
            //}
        }

        [HttpGet]
        [Authorize]
        [Route("api/careers/{id:int}/offers")]
        public IHttpActionResult GetOffers(int id)
        {
            try
            {
                return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferDetailsViewModel>>(careerService.GetOffers(id)));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return Content(System.Net.HttpStatusCode.NoContent, ex.ParamName);
            }
        }

        [HttpGet]
        [Authorize(Roles = "employer")]
        [Route("api/careers/user")]
        public IHttpActionResult GetCurrentUserCareers()
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;

            try
            {
                var careers = Mapper.Map<IEnumerable<CareerDTO>, List<CareerViewModel>>(userService.GetUserCareers(userId));

                return Ok(careers);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }

        [HttpGet]
        [Authorize(Roles = "employer")]
        [Route("api/careers/user/minimum")]
        public IHttpActionResult GetCurrentUserCareersMinimum()
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;

            try
            {
                var careers = Mapper.Map<IEnumerable<CareerDTO>, List<CareerMinimumViewModel>>(userService.GetUserCareers(userId));

                return Ok(careers);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }

        [HttpPost]
        [Authorize(Roles = "employer")]
        [Route("api/careers/add")]
        public IHttpActionResult Add(CareerViewModel careerView)
        {
            CareerDTO careerDTO = Mapper.Map<CareerViewModel, CareerDTO>(careerView);
            careerDTO.UserId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;

            try
            {
                careerService.CreateCareer(careerDTO);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "employer")]
        [Route("api/careers/edit")]
        public IHttpActionResult Edit(CareerViewModel careerView)
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;

            try
            {
                var careerDto = careerService.GetCareerById(careerView.Id);

                if (careerDto.UserId != userId)
                    return BadRequest("No access!");

                careerService.EditCareer(Mapper.Map<CareerViewModel, CareerDTO>(careerView));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Not correct input data");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }


            return Ok("Career is edited");
        }

        [HttpDelete]
        [Authorize(Roles = "employer")]
        [Route("api/careers/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;

            try
            {
                var careerDto = careerService.GetCareerById(id);

                if (careerDto.UserId != userId)
                    return BadRequest("No access!");

                careerService.RemoveCareer(id);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }


            return Ok("Career is deleted");
        }
    }
}