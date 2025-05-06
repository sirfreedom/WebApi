using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using WebApi.Biz;
using WebApi.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public QuestionController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Devueve todas las preguntas y respuestas de una dependencia
        /// </summary>
        /// <param name="IdDependency">
        /// agrupamiento de preguntas
        /// </param>
        /// <param name="CodLevel">
        /// El nivel, es el nivel guardado de las preguntas puede haber varios niveles de preguntas dependiendo de la dependencia solicitada.
        /// </param>
        /// <returns>
        /// La estructura de la pregunta es, la pregunta, un codigo, y posibles respuestas.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult List(int IdDependency, int CodLevel=0)
        {
            List<Question> lq = new List<Question>();
            QuestionBiz questionBiz = new QuestionBiz(_ConectionString);
            try
            {
                lq = questionBiz.List(IdDependency,CodLevel);
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
            return Ok(new { questions = lq }); //OK 200
        }






    }
}
