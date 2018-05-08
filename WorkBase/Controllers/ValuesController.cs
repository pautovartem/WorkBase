using LogicLayer.DTO;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WorkBase.Controllers
{
    public class ValuesController : ApiController
    {
        readonly IRubricService rubricService;

        public ValuesController(IRubricService rubricService)
        {
            this.rubricService = rubricService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            rubricService.CreateRubric(new RubricDTO { Name = "Test1" });
            return new string[] { "value" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
