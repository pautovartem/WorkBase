using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.Interfaces;
using LogicLayer.DTO;

namespace WorkBase.Controllers
{
    [Authorize]
    public class ResumesController : ApiController
    {
        IResumeService resumeService;

        public ResumesController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }

        // GET api/<controller>
        public IEnumerable<ResumeDTO> Get()
        {
            return resumeService.GetAllResumes();
        }

        // GET api/<controller>/5
        public ResumeDTO Get(int id)
        {
            return resumeService.GetResumeById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}