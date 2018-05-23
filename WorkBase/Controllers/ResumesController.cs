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
    //[Authorize]
    public class ResumesController : ApiController
    {
        IResumeService resumeService;

        public ResumesController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }

        // GET api/<controller>
        public string Get()
        {
            return "Get";
        }

        [Route("api/resumes/geta")]
        public string GetA()
        {
            return "A";
        }

        [Route("getb")]
        public string GetB()
        {
            return "B";
        }

        [Route("getc")]
        public string GetC()
        {
            return "C";
        }

        [Route("getd")]
        public string GetD()
        {
            return "D";
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