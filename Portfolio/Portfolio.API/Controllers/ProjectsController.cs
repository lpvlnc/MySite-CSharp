using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService _service;

        public ProjectsController(ILogger<HomeController> logger, IProjectService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get the 'Project' table's data.
        /// </summary>
        /// <returns>List of models of type 'Project'.</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Project>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Project>> Get()
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
        /// Get the 'Project' table's data that match the specified id.
        /// </summary>
        /// <returns>Model of type 'Project'.</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Project>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Project>> GetById(int id)
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
        /// Insert a new row at 'Project' table.
        /// </summary>
        /// <param name="model">The model of type 'Project' to be inserted.</param>
        /// <returns>string: Project inserted.</returns>
        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<Me> Add([FromBody] Project model)
        {
            try
            {
                _service.Add(model);
                return Ok("Project inserted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Update an existing row of 'Project' table.
        /// </summary>
        /// <param name="model">The model of type 'Project' to be updated.</param>
        /// <returns>string: Project with id {x} updated.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Update([FromBody] Project model)
        {
            try
            {
                _service.Update(model);
                return Ok($"Project with id {model.Id} updated.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Delete a row of 'Project' table based on the id.
        /// </summary>
        /// <param name="id">The Id of the register to be deleted.</param>
        /// <returns>Project with id {x} deleted.</returns>
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
                return Ok($"Project with id {id} deleted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
