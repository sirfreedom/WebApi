using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System;
using WebApi.Biz;
using WebApi.Entity;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QuestionLevelController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public QuestionLevelController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Lista los niveles de las preguntas
        /// </summary>
        /// <param name="IdDependency">
        /// La dependencia es un valor definido para saber el agrupamiento de las preguntas
        /// </param>
        /// <returns>
        /// devuelve la lista completa de niveles con su codigo descripcion y propiedad de class
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult List(int IdDependency)
        {
            List<QuestionLevel> lq = new List<QuestionLevel>();
            QuestionLevelBiz questionLevelBiz = new QuestionLevelBiz(_ConectionString);
            try
            {
                lq = questionLevelBiz.List(IdDependency);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { questionlevels = lq }); //OK 200
        }


    }
}
