using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _service;

        public ContactsController(ILogger<HomeController> logger, IContactService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get the 'Contact' table's data.
        /// </summary>
        /// <returns>List of models of type 'Contact'.</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Contact>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Contact>> Get()
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
        /// Get the 'Contact' table's data that match the specified id.
        /// </summary>
        /// <returns>Model of type 'Contact'.</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Contact>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Contact>> GetById(int id)
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
        /// Insert a new row at 'Contact' table.
        /// </summary>
        /// <param name="model">The model of type 'Contact' to be inserted.</param>
        /// <returns>string: Contact inserted.</returns>
        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Add([FromBody] Contact model)
        {
            try
            {
                _service.Add(model);
                return Ok("Contact inserted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Update an existing row of 'Contact' table.
        /// </summary>
        /// <param name="model">The model of type 'Contact' to be updated.</param>
        /// <returns>string: Contact with id {x} updated.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Update([FromBody] Contact model)
        {
            try
            {
                _service.Update(model);
                return Ok($"Contact with id {model.Id} updated.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Delete a row of 'Contact' table based on the id.
        /// </summary>
        /// <param name="id">The Id of the register to be deleted.</param>
        /// <returns>Contact with id {x} deleted.</returns>
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
                return Ok($"Contact with id {id} deleted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
