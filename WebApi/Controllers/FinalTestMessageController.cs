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
    public class FinalTestMessageController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public FinalTestMessageController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Devuelve la lista de mensajes que se utilizan cuando uno completa el examen
        /// por ej, para los niveles 1 y 2, y para preguntas contestadas entre 1 y 10, el mensaje puede ser estuviste bien, pero deberias esforzarte mas.
        /// para los niveles 3 y 4, y para las preguntas contestadas entre 11 y 20, el mensaje puede ser estuviste genial.
        /// </summary>
        /// <param name="IdDependency">
        /// la dependencia es la agrupacion de un grupo de preguntas
        /// </param>
        /// <returns>
        /// devuelve la lista de mensajes asociados a niveles y valores de contestacion de preguntas.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult List(int IdDependency)
        {
            List<FinalTestMessage> lf = new List<FinalTestMessage>();
            FinalTestMessageBiz finalTestMessageBiz = new FinalTestMessageBiz(_ConectionString);
            try
            {
                lf = finalTestMessageBiz.Find(IdDependency);
            }
            catch (WebException ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new { finaltestmessage = lf }); //OK 200
        }


    }
}
