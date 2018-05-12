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
    public class RubricsController : ApiController
    {
        readonly IRubricService rubricService;

        public RubricsController(IRubricService rubricService)
        {
            this.rubricService = rubricService;
        }

        // GET api/<controller>
        public IEnumerable<RubricDTO> Get()
        {
            return rubricService.GetAllRubrics();
        }

        // GET api/<controller>/5
        public RubricDTO Get(int id)
        {
            return rubricService.GetRubricById(id);
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