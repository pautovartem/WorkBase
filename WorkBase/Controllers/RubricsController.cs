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
    public class RubricsController : ApiController
    {
        readonly IRubricService rubricService;

        public RubricsController(IRubricService rubricService)
        {
            this.rubricService = rubricService;
        }

        [HttpGet]
        [Route("api/rubrics/")]
        public IHttpActionResult GetRubrics()
        {
            return Ok(Mapper.Map<IEnumerable<RubricDTO>, List<RubricViewModel>>(rubricService.GetAllRubrics()));
        }
        
        [HttpGet]
        [Route("api/rubrics/{id:int}")]
        public IHttpActionResult GetRubric(int id)
        {
            RubricViewModel rubricView = Mapper.Map<RubricDTO, RubricViewModel>(rubricService.GetRubricById(id));

            if (rubricView == null)
                return Content(System.Net.HttpStatusCode.NoContent, "Not found rubric");
            else
                return Ok(rubricView);
        }
        
        [HttpPost]
        [Authorize]
        [Route("api/rubrics/add")]
        public IHttpActionResult AddRubric(RubricViewModel rubricView)
        {
            try
            {
                rubricService.CreateRubric(Mapper.Map<RubricViewModel, RubricDTO>(rubricView));

                return Ok("Rubric is created");
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

        [HttpPost]
        [Authorize]
        [Route("api/rubrics/edit")]
        public IHttpActionResult EditRubric(RubricViewModel rubricView)
        {
            try
            {
                rubricService.EditRubric(Mapper.Map<RubricViewModel, RubricDTO>(rubricView));

                return Ok("Rubric is edited");
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

        [HttpPost]
        [Authorize]
        [Route("api/rubrics/delete/{id:int}")]
        public IHttpActionResult DeleteRubric(int id)
        {
            try
            {
                rubricService.RemoveRubric(id);

                return Ok("Rubric is deleted");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.ParamName);
            }
        }
    }
}