using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.Interfaces;
using LogicLayer.DTO;
using WorkBase.Models;
using AutoMapper;

namespace WorkBase.Controllers
{
    //[Authorize]
    public class ResumesController : ApiController
    {
        IResumeService resumeService;
        IUserService userService;

        public ResumesController(IResumeService resumeService, IUserService userService)
        {
            this.resumeService = resumeService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/")]
        public IHttpActionResult GetResumes()
        {
            return Ok(Mapper.Map<IEnumerable<ResumeDTO>, List<ResumeViewModel>>(resumeService.GetAllResumes()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/minimum")]
        public IHttpActionResult GetResumesMinimum()
        {
            return Ok(Mapper.Map<IEnumerable<ResumeDTO>, List<ResumeMinimumViewModel>>(resumeService.GetAllResumes()));
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/{id:int}")]
        public IHttpActionResult GetResume(int id)
        {
            ResumeViewModel resumeView = Mapper.Map<ResumeDTO, ResumeViewModel>(resumeService.GetResumeById(id));

            if (resumeView == null)
                return Content(System.Net.HttpStatusCode.NoContent, "Not found resume");
            else
                return Ok(resumeView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/{id:int}/minimum")]
        public IHttpActionResult GetResumeMinimum(int id)
        {
            ResumeMinimumViewModel resumeView = Mapper.Map<ResumeDTO, ResumeMinimumViewModel>(resumeService.GetResumeById(id));

            if (resumeView == null)
                return Content(System.Net.HttpStatusCode.NoContent, "Not found resume");
            else
                return Ok(resumeView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/{id:int}/experience")]
        public IHttpActionResult GetResumeExperience(int id)
        {
            return Ok(Mapper.Map<IEnumerable<ResumesExperienceDTO>, List<ExperienceViewModel>>(resumeService.GetExperiences(id)));
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/{id:int}/offers")]
        public IHttpActionResult GetOffers(int id)
        {
            return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferDetailsViewModel>>(resumeService.GetOffers(id)));
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/user")]
        public IHttpActionResult GetCurrentUserResumes()
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var resumes = Mapper.Map<IEnumerable<ResumeDTO>, List<ResumeViewModel>>(userService.GetUserResumes(userId));

            return Ok(resumes);
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/user/minimum")]
        public IHttpActionResult GetCurrentUserResumesMinimum()
        {
            var userId = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var resumes = Mapper.Map<IEnumerable<ResumeDTO>, List<ResumeMinimumViewModel>>(userService.GetUserResumes(userId));

            return Ok(resumes);
        }

        [HttpPost]
        [Authorize(Roles = "worker")]
        [Route("api/resumes/add")]
        public IHttpActionResult Add(ResumeViewModel resumeView)
        {
            ResumeDTO resumeDTO = Mapper.Map<ResumeViewModel, ResumeDTO>(resumeView);
            resumeDTO.User = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            try
            {
                resumeService.CreateResume(resumeDTO);

                return Ok("Resume is created");
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
        [Authorize(Roles = "worker")]
        [Route("api/resumes/edit")]
        public IHttpActionResult Edit(ResumeViewModel resumeView)
        {
            try
            {
                resumeService.EditResume(Mapper.Map<ResumeViewModel, ResumeDTO>(resumeView));

                return Ok("Resume is edited");
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
        [Authorize(Roles = "worker")]
        [Route("api/resumes/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                resumeService.RemoveResume(id);

                return Ok("Resume is deleted");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }
    }
}