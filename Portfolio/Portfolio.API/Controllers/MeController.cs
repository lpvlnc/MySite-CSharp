using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMeService _meService;

        public MeController(ILogger<HomeController> logger, IMeService service)
        {
            _logger = logger;
            _meService = service;
        }

        /// <summary>
        /// Get the 'Me' table's data.
        /// </summary>
        /// <returns>Model of type 'Me'.</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Me))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<Me> Get()
        {
            try
            {
                return Ok(_meService.Get());
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Insert a new row at 'Me' table.
        /// </summary>
        /// <param name="model">The model of type 'Me' to be inserted.</param>
        /// <returns>string: User's information inserted.</returns>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Add([FromBody] Me model)
        {
            try
            {
                _meService.Add(model);
                return Ok("User's information inserted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Update an existing row of 'Me' table.
        /// </summary>
        /// <param name="model">The model of type 'Me' to be updated.</param>
        /// <returns>string: User's information updated.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Update([FromBody] Me model)
        {
            try
            {
                _meService.Update(model);
                return Ok("User's information updated.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Delete a row of 'Me' table based on the id.
        /// </summary>
        /// <returns>User's information deleted.</returns>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Delete()
        {
            try
            {
                _meService.Delete();
                return Ok("User's information deleted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
