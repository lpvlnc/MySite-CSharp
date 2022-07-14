using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestimonialService _service;

        public TestimonialsController(ILogger<HomeController> logger, ITestimonialService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get the 'Testimonial' table's data.
        /// </summary>
        /// <returns>List of models of type 'Testimonial'.</returns>
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Testimonial>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Testimonial>> Get()
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
        /// Get the 'Testimonial' table's data that match the specified id.
        /// </summary>
        /// <returns>Model of type 'Testimonial'.</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Testimonial>))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<List<Testimonial>> GetById(int id)
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
        /// Insert a new row at 'Testimonial' table.
        /// </summary>
        /// <param name="model">The model of type 'Testimonial' to be inserted.</param>
        /// <returns>string: Testimonial inserted.</returns>
        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Add([FromBody] Testimonial model)
        {
            try
            {
                _service.Add(model);
                return Ok("Testimonial inserted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Update an existing row of 'Testimonial' table.
        /// </summary>
        /// <param name="model">The model of type 'Testimonial' to be updated.</param>
        /// <returns>string: Testimonial with id {x} updated.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<string> Update([FromBody] Testimonial model)
        {
            try
            {
                _service.Update(model);
                return Ok($"Testimonial with id {model.Id} updated.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        /// <summary>
        /// Delete a row of 'Testimonial' table based on the id.
        /// </summary>
        /// <param name="id">The Id of the register to be deleted.</param>
        /// <returns>Testimonial with id {x} deleted.</returns>
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
                return Ok($"Testimonial with id {id} deleted.");
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
