using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.DTO;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [HttpGet]
        [Route("GetMe")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeDto))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<MeDto> GetMe()
        {
            try
            {
                return Ok(_homeService.GetMe());
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        [HttpGet]
        [Route("GetAbout")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeAboutDto))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        public ActionResult<MeAboutDto> GetAbout()
        {
            try
            {
                return Ok(_homeService.GetAbout());
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        //[HttpGet]
        //[Route("GetExperiences")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<List<Experience>> GetExperiences()
        //{
        //    try
        //    {
        //        return Ok(_experienceService.GetAll());
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}

        //[HttpGet]
        //[Route("GetProjects")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<List<ExperienceModel>> GetProjects()
        //{
        //    try
        //    {
        //        return Ok(_projectService.GetAll());
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}

        //[HttpGet]
        //[Route("GetTestimonials")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<List<ExperienceModel>> GetTestimonials()
        //{
        //    try
        //    {
        //        return Ok(_testimonialService.GetAll());
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}

        //[HttpGet]
        //[Route("GetContacts")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<List<ExperienceModel>> GetContacts()
        //{
        //    try
        //    {
        //        return Ok(_contactService.GetAll());
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}

        //[HttpPost]
        //[Route("SendMessage")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<string> SendMessage([FromBody]MessageModel message)
        //{
        //    try
        //    {
        //        return Ok(_contactService.SendMessage(message));
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}

        //[HttpGet]
        //[Route("GetSocials")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CustomExceptionModel))]
        //public ActionResult<string> GetSocials()
        //{
        //    try
        //    {
        //        return Ok(_socialService.GetAll());
        //    }
        //    catch (Exception exception)
        //    {
        //        var error = ExceptionManager.ReturnErrorMessage(exception);
        //        return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
        //    }
        //}
    }
}