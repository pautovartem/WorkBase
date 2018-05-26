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
                return NotFound();

            return Ok(resumeView);
        }

        [HttpGet]
        [Authorize]
        [Route("api/resumes/{id:int}/minimum")]
        public IHttpActionResult GetResumeMinimum(int id)
        {
            ResumeMinimumViewModel resumeView = Mapper.Map<ResumeDTO, ResumeMinimumViewModel>(resumeService.GetResumeById(id));

            if (resumeView == null)
                return NotFound();

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
            return Ok(Mapper.Map<IEnumerable<OfferDTO>, List<OfferViewModel>>(resumeService.GetOffers(id)));
        }

        [HttpPost]
        [Authorize]
        [Route("api/resumes/add")]
        public IHttpActionResult Add(ResumeViewModel resumeView)
        {
            ResumeDTO resumeDTO = Mapper.Map<ResumeViewModel, ResumeDTO>(resumeView);
            resumeDTO.User = userService.GetUsers().Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            resumeService.CreateResume(resumeDTO);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("api/resumes/edit")]
        public IHttpActionResult Edit(ResumeViewModel resumeView)
        {
            resumeService.EditResume(Mapper.Map<ResumeViewModel, ResumeDTO>(resumeView));

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("api/resumes/delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            resumeService.RemoveResume(id);

            return Ok();
        }
    }
}