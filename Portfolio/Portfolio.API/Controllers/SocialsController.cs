using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISocialService _service;

        public SocialsController(ILogger<HomeController> logger, ISocialService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get the 'Social' table's data.
        /// </summary>
        /// <returns>List of models of type 'Social'.</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Social>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Social>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Get the 'Social' table's data that match the specified id.
        /// </summary>
        /// <returns>Model of type 'Social'.</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Social>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Social>> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Insert a new row at 'Social' table.
        /// </summary>
        /// <param name="model">The model of type 'Social' to be inserted.</param>
        /// <returns>string: Social inserted.</returns>
        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Add([FromBody] Social model)
        {
            try
            {
                _service.Add(model);
                return Ok("Social inserted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Update an existing row of 'Social' table.
        /// </summary>
        /// <param name="model">The model of type 'Social' to be updated.</param>
        /// <returns>string: Social with id {x} updated.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Update([FromBody] Social model)
        {
            try
            {
                _service.Update(model);
                return Ok($"Social with id {model.Id} updated.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Delete a row of 'Social' table based on the id.
        /// </summary>
        /// <param name="id">The Id of the register to be deleted.</param>
        /// <returns>Social with id {x} deleted.</returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok($"Social with id {id} deleted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
